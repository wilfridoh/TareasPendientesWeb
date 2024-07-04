using System.ComponentModel.DataAnnotations;

namespace TareasPendientesWeb.Models
{
    public class TareasPendientes
    {
        [Display(Name = "ID Tarea")]
        public int id { get; set; }
        [Display(Name = "Descripción de la Tarea")]
        public string descripcion { get; set; }
        [Display(Name = "Fecha de Creacion")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaCreacion { get; set; }
        [Display(Name = "Fecha de Vencimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime fechaVencimiento { get; set; }
        [Display(Name = "Completada")]
        public bool completada { get; set; }
    }
}
