namespace BibliotecaApi.Models;
using System.ComponentModel.DataAnnotations;

// Modelo que representa un Libro dentro del sistema de biblioteca.
public class Libro
{
    public int LibroId { get; set; }

    [Required(ErrorMessage = "El título es obligatorio.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "El autor es obligatorio.")]
    public string Autor { get; set; }
    public bool Prestado { get; set; }

    // Relación uno-a-muchos: un libro puede tener múltiples préstamos.
    // El símbolo "?" permite que esta propiedad sea null (opcional).
    public List<Prestamo>? Prestamos { get; set; }  // Nota: El '?' evita errores al crear el libro sin lista de préstamos
}

