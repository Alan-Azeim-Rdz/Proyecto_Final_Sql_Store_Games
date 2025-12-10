using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using System.Security.Claims;
using System.Security.Cryptography; // Necesario para hashing
using System.Text; // Necesario para manejar cadenas y bytes
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System.Linq;

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    public class AccountController : Controller
    {
        private readonly Db_Contexto _context;
        private readonly ILogger<AccountController> _logger;
        private readonly IWebHostEnvironment _env;

        public AccountController(Db_Contexto context, IWebHostEnvironment env, ILogger<AccountController> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }

        // --- ACCIONES GET (MOSTRAR VISTAS) ---
        [HttpGet]
        public IActionResult Register() => View();

        [HttpGet]
        public IActionResult Login(string? returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        // ---------------------------------------------
        // --- ACCIÓN POST: INICIO DE SESIÓN (LOGIN) ---
        // ---------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var email = model.Correo?.Trim().ToLowerInvariant();

                if (string.IsNullOrEmpty(email))
                {
                    ModelState.AddModelError(string.Empty, "Correo inválido.");
                    ViewData["ReturnUrl"] = returnUrl;
                    return View(model);
                }

                var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo.ToLower() == email);

                bool passwordVerified = false;
                bool storedIsHexSha256 = false;

                if (user != null)
                {
                    storedIsHexSha256 = IsHexSha256(user.Contraseña);

                    if (storedIsHexSha256)
                    {
                        var enteredHex = ComputeSha256Hex(model.Contraseña);
                        if (string.Equals(enteredHex, user.Contraseña, StringComparison.OrdinalIgnoreCase))
                        {
                            passwordVerified = true;
                        }
                    }

                    // Logging diagnóstico solo en Development
                    if (_env.IsDevelopment())
                    {
                        _logger.LogInformation("Login attempt for email={Email}. UserFound={UserFound}, StoredIsHexSha256={IsHex}, PasswordVerified={Verified}",
                            email,
                            user != null,
                            storedIsHexSha256,
                            passwordVerified);
                    }
                }
                else
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogInformation("Login attempt for email={Email}. User not found.", email);
                    }
                }

                if (user != null && passwordVerified)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Nombre),
                        new Claim(ClaimTypes.Role, GetUserRole(user.IdTipoUsuario))
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                    await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ViewData["ReturnUrl"] = returnUrl;
                ModelState.AddModelError(string.Empty, "Credenciales inválidas (correo o contraseña incorrectos).");
            }
            return View(model);
        }

        // ------------------------------------------------
        // --- ACCIÓN POST: REGISTRO DE CUENTA (REGISTER) ---
        // ------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Limpia el ChangeTracker para evitar duplicados o estados inconsistentes
                _context.ChangeTracker.Clear();

                // Validar que todos los campos requeridos estén presentes
                var camposObligatorios = new[] {
                    model.Nombre, model.ApellidoP, model.ApellidoM, model.Correo, model.Contraseña, model.ConfirmarContraseña,
                    model.Telefono, model.Calle, model.Colonia, model.Ciudad, model.CodigoPostal, model.Estado, model.Pais
                };
                if (camposObligatorios.Any(string.IsNullOrWhiteSpace))
                {
                    ModelState.AddModelError(string.Empty, "Todos los campos son obligatorios.");
                    return View(model);
                }

                var email = model.Correo?.Trim().ToLowerInvariant();
                if (string.IsNullOrEmpty(email))
                {
                    ModelState.AddModelError("Correo", "El correo es inválido.");
                    return View(model);
                }
                if (_context.Usuarios.Any(u => u.Correo.ToLower() == email))
                {
                    ModelState.AddModelError("Correo", "Este correo ya está registrado.");
                    return View(model);
                }

                // Buscar o crear País
                var pais = _context.Pais.FirstOrDefault(p => p.Nombre.ToLower() == model.Pais.Trim().ToLower());
                if (pais == null)
                {
                    pais = new Pai { Nombre = model.Pais.Trim(), Status = true, DateCreate = DateTime.Now };
                    _context.Pais.Add(pais);
                    await _context.SaveChangesAsync();
                }

                // Buscar o crear Estado
                var estado = _context.Estados.FirstOrDefault(e => e.Nombre.ToLower() == model.Estado.Trim().ToLower() && e.IdPais == pais.Id);
                if (estado == null)
                {
                    estado = new Estado { Nombre = model.Estado.Trim(), IdPais = pais.Id, Status = true, DateCreate = DateTime.Now };
                    _context.Estados.Add(estado);
                    await _context.SaveChangesAsync();
                }

                // Buscar o crear Ciudad
                var ciudad = _context.Ciudads.FirstOrDefault(c => c.Nombre.ToLower() == model.Ciudad.Trim().ToLower() && c.IdEstado == estado.Id);
                if (ciudad == null)
                {
                    ciudad = new Ciudad { Nombre = model.Ciudad.Trim(), IdEstado = estado.Id, Status = true, DateCreate = DateTime.Now };
                    _context.Ciudads.Add(ciudad);
                    await _context.SaveChangesAsync();
                }

                // Buscar o crear CP
                var cp = _context.CPs.FirstOrDefault(cp => cp.Nombre == model.CodigoPostal.Trim() && cp.IdCiudad == ciudad.Id);
                if (cp == null)
                {
                    cp = new CP { Nombre = model.CodigoPostal.Trim(), IdCiudad = ciudad.Id, Status = true, DateCreate = DateTime.Now };
                    _context.CPs.Add(cp);
                    await _context.SaveChangesAsync();
                }

                // Buscar o crear Dirección
                var direccion = _context.Direccions.FirstOrDefault(d =>
                    d.Calle.ToLower() == model.Calle.Trim().ToLower() &&
                    d.Colonia.ToLower() == model.Colonia.Trim().ToLower() &&
                    d.IdCP == cp.Id &&
                    d.IdCiudad == ciudad.Id &&
                    d.IdEstado == estado.Id &&
                    d.IdPais == pais.Id
                );
                if (direccion == null)
                {
                    direccion = new Direccion
                    {
                        Calle = model.Calle,
                        Colonia = model.Colonia,
                        IdCP = cp.Id,
                        IdCiudad = ciudad.Id,
                        IdEstado = estado.Id,
                        IdPais = pais.Id,
                        Status = true,
                        DateCreate = DateTime.Now
                    };
                    _context.Direccions.Add(direccion);
                    await _context.SaveChangesAsync();
                }

                var newUserIdTipoUsuario = 1;
                var nuevoUsuario = new Usuario
                {
                    Nombre = model.Nombre,
                    ApellidoP = model.ApellidoP,
                    ApellidoM = model.ApellidoM,
                    Correo = email,
                    Contraseña = HashPasswordSha256(model.Contraseña),
                    Telefono = model.Telefono,
                    IdDireccion = direccion.Id,
                    IdTipoUsuario = newUserIdTipoUsuario,
                    Status = true,
                    DateCreate = DateTime.Now
                };
                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, nuevoUsuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, nuevoUsuario.Nombre),
                    new Claim(ClaimTypes.Role, GetUserRole(newUserIdTipoUsuario))
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // ------------------------------------------
        // --- FUNCIONES DE HASHING (SHA256 SALTED) ---
        // ------------------------------------------

        private string HashPasswordSha256(string password)
        {
            const int SaltSize = 16;
            const int HashSize = 20;
            const int Iterations = 10000;

            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Usamos SHA256 con PBKDF2 para hacer el proceso lento y seguro.
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }


        // --- FUNCIONES AUXILIARES PARA SHA256 HEX ---
        private static bool IsHexSha256(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (s.Length != 64) return false;
            return Regex.IsMatch(s, @"\A\b[0-9a-fA-F]+\b\z");
        }

        private static string ComputeSha256Hex(string input)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input ?? string.Empty);
            var hash = sha.ComputeHash(bytes);
            var sb = new StringBuilder(hash.Length * 2);
            foreach (var b in hash) sb.Append(b.ToString("x2"));
            return sb.ToString().ToUpperInvariant();
        }

        // --- FUNCIÓN AUXILIAR DE ROL ---
        private string GetUserRole(int idTipoUsuario)
        {
            return idTipoUsuario switch
            {
                1 => "Admin",
                2 => "Estandar",
                _ => "Desconocido",
            };
        }
    }
}
