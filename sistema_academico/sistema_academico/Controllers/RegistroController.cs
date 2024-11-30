using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema_academico.Models;
using System.Threading.Tasks;

namespace sistema_academico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly MyDbContext _context;

        public RegistroController(MyDbContext context)
        {
            _context = context;
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CrearUsuario([FromBody] usuario nuevoUsuario)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el usuario ya existe
                var existeUsuario = await _context.usuarios
                    .AnyAsync(u => u.NombreUsuario == nuevoUsuario.NombreUsuario);

                if (existeUsuario)
                    return BadRequest(new { message = "El nombre de usuario ya está en uso." });

                // Crear nuevo usuario
                await _context.usuarios.AddAsync(nuevoUsuario);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Usuario creado exitosamente." });
            }

            return BadRequest(ModelState);
        }
    }
}
