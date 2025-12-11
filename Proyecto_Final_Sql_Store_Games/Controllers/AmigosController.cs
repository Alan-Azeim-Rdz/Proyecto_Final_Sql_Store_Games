using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Sql_Store_Games.Models;
using Proyecto_Final_Sql_Store_Games.Models.ViewModel;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Final_Sql_Store_Games.Controllers
{
    [Authorize] // Solo los usuarios logeados pueden ver sus amigos
    public class AmigosController : Controller
    {
        private readonly Db_Contexto _context;

        public AmigosController(Db_Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            // 0. Obtener el ID del usuario logueado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int idUsuarioLogeado = int.Parse(userIdClaim.Value);

            // 1. Buscar amigos del usuario logeado (bidireccional)
            var amigos = _context.Amigos
                .Where(a =>
                    (a.IdUsuario1 == idUsuarioLogeado || a.IdUsuario2 == idUsuarioLogeado) && a.Status == true)
                .Select(a => new ViewAmigo
                {
                    // Determinar quién es el amigo (dependiendo si es IdUsuario1 o IdUsuario2)
                    IdAmigo = a.IdUsuario1 == idUsuarioLogeado ? a.IdUsuario2 : a.IdUsuario1,
                    Nombre = a.IdUsuario1 == idUsuarioLogeado
                        ? a.IdUsuario2Navigation.Nombre
                        : a.IdUsuario1Navigation.Nombre,
                    Correo = a.IdUsuario1 == idUsuarioLogeado
                        ? a.IdUsuario2Navigation.Correo
                        : a.IdUsuario1Navigation.Correo,
                    EsAmigo = true
                })
                .AsQueryable();

            // 2. Búsqueda de amigos por nombre o correo
            if (!string.IsNullOrEmpty(searchString))
            {
                amigos = amigos.Where(a => a.Nombre.Contains(searchString) || a.Correo.Contains(searchString));
            }

            // 3. Ejecutar consulta
            var listaAmigos = await amigos.ToListAsync();

            return View(listaAmigos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarAmigo(int idAmigo)
        {
            // 0. Obtener el ID del usuario logueado
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int idUsuarioLogeado = int.Parse(userIdClaim.Value);

            // 1. Buscar la relación de amistad entre los usuarios
            var amistad = await _context.Amigos
                .FirstOrDefaultAsync(a =>
                    (a.IdUsuario1 == idUsuarioLogeado && a.IdUsuario2 == idAmigo) ||
                    (a.IdUsuario2 == idUsuarioLogeado && a.IdUsuario1 == idAmigo));

            if (amistad != null)
            {
                // 2. Marcar la relación como eliminada (Status = false)
                amistad.Status = false;
                amistad.DateDelete = DateTime.Now; // Fecha de eliminación
                amistad.IdUserDelete = idUsuarioLogeado; // Usuario que eliminó la amistad

                // 3. Guardar los cambios en la base de datos
                _context.Amigos.Update(amistad);
                await _context.SaveChangesAsync();
            }

            // Redirigir a la vista de amigos después de eliminar
            return RedirectToAction("Index");
        }

    }
}
