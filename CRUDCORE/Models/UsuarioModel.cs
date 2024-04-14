using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        public string? FechaCreacion { get; set; }

        public int IdPerfil { get; set; }

        public string? Usuario { get; set; }

        public string? Password { get; set; }

        public string? Estatus { get; set; }

        public int IdEstatus { get; set; }

    }
}
