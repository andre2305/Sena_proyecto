using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Informacion.Models
{
    public class Usuario
    {
        public int  usu_ID { get; set; }

        [Required(ErrorMessage = "El documento es obligatorio")]
        public string usu_Documento { get; set; }

        [Required(ErrorMessage = "El tipo documento es obligatorio")]
        public string usu_TipoDocumento { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string usu_Nombre { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        public string usu_Celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string usu_Email { get; set; }

        [Required(ErrorMessage = "El genero es obligatorio")]
        public string usu_Genero { get; set; }

        [Required(ErrorMessage = "El aprendiz es obligatorio")]
        public int usu_Aprendiz { get; set; }

        [Required(ErrorMessage = "El egresado es obligatorio")]
        public int usu_Egresado { get; set; }

        [Required(ErrorMessage = "El Area de formacion es obligatorio")]
        public string usu_AreaFormacion { get; set; }

        public DateTime usu_FechaEgresado { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria")]

        public string usu_Direccion { get; set; }

        [Required(ErrorMessage = "El Barrio es obligatorio")]

        public string usu_Barrio { get; set; }

        [Required(ErrorMessage = "El Ciudad es obligatorio")]

        public string usu_Ciudad { get; set; }

        [Required(ErrorMessage = "El Departamento es obligatorio")]
        public string usu_Departamento { get; set; }

        [Required(ErrorMessage = "El Fecha Registro es obligatorio")]
        public DateTime usu_FechaRegistro { get; set; }

    }
}