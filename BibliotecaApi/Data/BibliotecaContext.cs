// Importa los modelos definidos en la aplicación
using BibliotecaApi.Models;

// Importa Entity Framework Core para trabajar con bases de datos
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApi.Data
{
    // Clase que representa el contexto de la base de datos
    public class BibliotecaContext : DbContext
    {
        // Constructor que recibe las opciones de configuración del contexto (como cadena de conexión)
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        // Representa la tabla de libros en la base de datos
        public DbSet<Libro> Libros { get; set; }

        // Representa la tabla de usuarios en la base de datos
        public DbSet<Usuario> Usuarios { get; set; }

        // Representa la tabla de préstamos en la base de datos
        public DbSet<Prestamo> Prestamos { get; set; }

        // Configura relaciones entre entidades al momento de crear el modelo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a muchos: un libro puede tener muchos préstamos
            modelBuilder.Entity<Libro>()
                .HasMany(l => l.Prestamos)         // Un libro tiene muchos préstamos
                .WithOne(p => p.Libro)             // Cada préstamo está asociado a un libro
                .HasForeignKey(p => p.LibroId);    // Clave foránea en la entidad Prestamo

            // Relación uno a muchos: un usuario puede tener muchos préstamos
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Prestamos)         // Un usuario tiene muchos préstamos
                .WithOne(p => p.Usuario)           // Cada préstamo está asociado a un usuario
                .HasForeignKey(p => p.UsuarioId);  // Clave foránea en la entidad Prestamo
        }
    }
}