namespace BibliotecaApi.Models;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    // Representa un usuario dentro del sistema de biblioteca
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El email no es válido.")]
    public string Email { get; set; }
    // Lista de préstamos asociados a este usuario (relación uno a muchos)

    public ICollection<Prestamo>? Prestamos { get; set; }
}


