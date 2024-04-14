using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ContactoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Concentracion es obligatorio")]
        public string? Concentracion { get; set; }

        public int IdFormaFarmaceutica { get; set; }

        public string? FormasFarmaceuticas { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public string? Precio { get; set; }

        [Required(ErrorMessage = "El campo Stock es obligatorio")]
        public string? Stock { get; set; }

        [Required(ErrorMessage = "El campo Presentacion es obligatorio")]
        public string? Presentacion { get; set; }

        public string? Estatus { get; set; }

        public int IdEstatus { get; set; }

    }
}
