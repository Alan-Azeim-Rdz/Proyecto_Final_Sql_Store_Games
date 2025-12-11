using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal; // Asegúrate de incluir System para DateTime

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly Db_Contexto _context;

        public UsuariosController(Db_Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // Obtener ID del usuario logueado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int idUsuarioLogeado))
            {
                // Manejo de usuario no logueado/claim inválido
                return RedirectToAction("Login", "Account");
            }

            // 1. Obtener la lista de amigos activos (Status == true)
            var amigosActivosIds = _context.Amigos
                .Where(a => (a.IdUsuario1 == idUsuarioLogeado || a.IdUsuario2 == idUsuarioLogeado) && a.Status == true)
                .Select(a => a.IdUsuario1 == idUsuarioLogeado ? a.IdUsuario2 : a.IdUsuario1)
                .ToList();

            // 2. Consulta base de usuarios activos (Status == true) excluyendo a los amigos activos
            var usuariosQuery = _context.Usuarios
                .Where(u => u.Status == true && !amigosActivosIds.Contains(u.Id)) // Excluir amigos activos
                .AsQueryable();

            // 3. Aplicar filtro de búsqueda
            if (!string.IsNullOrEmpty(searchString))
            {
                // Intenta parsear el string a int para buscar por IdUsuario
                if (int.TryParse(searchString, out int searchId))
                {
                    usuariosQuery = usuariosQuery.Where(u => u.Nombre.Contains(searchString) || u.Id == searchId);
                }
                else
                {
                    usuariosQuery = usuariosQuery.Where(u => u.Nombre.Contains(searchString));
                }
            }

            // 4. Proyección eficiente con subconsultas que usan propiedades de navegación
            var usuarios = await usuariosQuery
                .Select(u => new ViewUsuario
                {
                    IdUsuario = u.Id,
                    Nombre = u.Nombre,
                    // Calcular CantidadJuegos (Categoría 1: Juegos, 2: DLC)
                    CantidadJuegos = _context.DetalleVenta
                        .Where(dv => dv.IdVentaNavigation.IdUsuario == u.Id && dv.Status == true)
                        .Count(dv => dv.IdProductoNavigation.IdCategoria == 1 || dv.IdProductoNavigation.IdCategoria == 2), // Juegos y DLCs

                    // Calcular CantidadItems (Categoría 3: Ítems)
                    CantidadItems = _context.DetalleVenta
                        .Where(dv => dv.IdVentaNavigation.IdUsuario == u.Id && dv.Status == true)
                        .Count(dv => dv.IdProductoNavigation.IdCategoria == 3) // Ítems
                })
                .ToListAsync();

            return View(usuarios);
        }




        // El método AgregarAmigo se mantiene igual de la corrección anterior
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AgregarAmigo(int idUsuario)
        {
            // Obtener el ID del usuario logueado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int idUsuarioLogeado))
            {
                return RedirectToAction("Login", "Account");
            }

            // Verificar si el usuario está intentando agregarse a sí mismo
            if (idUsuarioLogeado == idUsuario)
            {
                TempData["ErrorMessage"] = "No puedes agregarte a ti mismo como amigo.";
                return RedirectToAction("Index");
            }

            // Buscar la relación de amistad
            var amistadExistente = await _context.Amigos
                .FirstOrDefaultAsync(a =>
                    (a.IdUsuario1 == idUsuarioLogeado && a.IdUsuario2 == idUsuario) ||
                    (a.IdUsuario2 == idUsuarioLogeado && a.IdUsuario1 == idUsuario));

            if (amistadExistente == null)
            {
                // Si no existe, crear una nueva relación de amistad
                var nuevaAmistad = new Amigo
                {
                    IdUsuario1 = idUsuarioLogeado,
                    IdUsuario2 = idUsuario,
                    Status = true,
                    DateCreate = DateTime.Now,
                    Fecha = DateTime.Now,
                    IdUserCreate = idUsuarioLogeado // El usuario logueado es quien agrega la amistad
                };

                _context.Amigos.Add(nuevaAmistad);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Amigo agregado con éxito.";
            }
            else
            {
                // Si ya existe la relación y el Status es false (eliminado), reactiva la amistad
                if (amistadExistente.Status == false)
                {
                    amistadExistente.Status = true; // Reactivamos la amistad
                    amistadExistente.DateUpdate = DateTime.Now; // Fecha de actualización
                    amistadExistente.IdUserUpdate = idUsuarioLogeado; // Quién actualiza la relación

                    _context.Update(amistadExistente);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Amistad reactivada con éxito.";
                }
                else
                {
                    TempData["InfoMessage"] = "Ya eres amigo de este usuario o la solicitud está pendiente.";
                }
            }

            return RedirectToAction("Index");
        }



    }
}