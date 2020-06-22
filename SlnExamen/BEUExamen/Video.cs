//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUExamen
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Video
    {
        [ScaffoldColumn(false)]
        public int id_video { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(55)]
        [Display(Name = "Titulo de video")]
        public string titulo_video { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public string fecha_publicacion_video { get; set; }
        public Nullable<int> id_categoria { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(55)]
        [Display(Name = "Formato de video")]
        public string formato { get; set; }

        [DataType(DataType.Duration)]
        [Display(Name = "Duracion de video")]
        public Nullable<int> duracion { get; set; }
    
        public virtual Categoria Categoria { get; set; }
    }
}
