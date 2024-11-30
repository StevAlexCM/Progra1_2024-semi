using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sistema_academico.Models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly MyDbContext _context;

    public AuthController(MyDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest(new { message = "Usuario y contraseña son requeridos." });
        }

        // Validar usuario en la base de datos
        var usuarioDb = await _context.usuarios
            .FirstOrDefaultAsync(u => u.NombreUsuario == model.Username && u.Contraseña == model.Password);

        if (usuarioDb == null)
        {
            return Unauthorized(new { message = "Usuario o contraseña incorrectos" });
        }

        // Mensaje de éxito
        return Ok(new { message = "Login exitoso", usuario = model.Username });
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
