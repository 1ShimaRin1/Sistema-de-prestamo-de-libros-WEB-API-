using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaApi.Models
{
    // Modelo que representa un préstamo de libro a un usuario.
    public class Prestamo
    {
        public int PrestamoId { get; set; }

        [Required]
        public int LibroId { get; set; }
        // Propiedad de navegación hacia el libro relacionado.
        // Marcada como nullable (?) para evitar ciclos y problemas de serialización.
        public Libro? Libro { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        // Propiedad de navegación hacia el usuario relacionado.
        // También nullable para evitar ciclos durante la serialización.
        public Usuario? Usuario { get; set; }

        public DateTime FechaPrestamo { get; set; }
        // Fecha en que se devuelve el libro. Es opcional (nullable) para préstamos aún activos.
        public DateTime? FechaDevolucion { get; set; }
    }
}



