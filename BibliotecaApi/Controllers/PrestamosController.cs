using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaApi.Data;
using BibliotecaApi.Models;

namespace BibliotecaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosApiController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public PrestamosApiController(BibliotecaContext context)
        {
            _context = context;
        }

        // POST: api/PrestamosApi
        [HttpPost]
        public async Task<IActionResult> RegistrarPrestamo([FromBody] Prestamo prestamo)
        {
            var libro = await _context.Libros.FindAsync(prestamo.LibroId);
            if (libro == null || libro.Prestado)
                return BadRequest("El libro no está disponible");

            libro.Prestado = true;
            prestamo.FechaPrestamo = DateTime.Now;

            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            return Ok(prestamo);
        }

        // POST: api/PrestamosApi/devoluciones
        [HttpPost("devoluciones")]
        public async Task<IActionResult> RegistrarDevolucion([FromBody] int prestamoId)
        {
            var prestamo = await _context.Prestamos
                .Include(p => p.Libro)
                .FirstOrDefaultAsync(p => p.PrestamoId == prestamoId);

            if (prestamo == null || prestamo.FechaDevolucion != null)
                return BadRequest("Préstamo inválido o ya devuelto");

            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Libro.Prestado = false;

            await _context.SaveChangesAsync();
            return Ok(prestamo);
        }
    }
}
