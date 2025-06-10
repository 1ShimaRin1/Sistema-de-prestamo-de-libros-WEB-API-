namespace BibliotecaApi.Models;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El email es obligatorio.")]
    [EmailAddress(ErrorMessage = "El email no es válido.")]
    public string Email { get; set; }

    public ICollection<Prestamo> Prestamos { get; set; }
}


