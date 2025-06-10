namespace BibliotecaApi.Models;
using System.ComponentModel.DataAnnotations;


    public class Libro
    {
        public int LibroId { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio.")]
        public string Autor { get; set; }
        public bool Prestado { get; set; }

    public List<Prestamo>? Prestamos { get; set; }  // nota el "?"
}

