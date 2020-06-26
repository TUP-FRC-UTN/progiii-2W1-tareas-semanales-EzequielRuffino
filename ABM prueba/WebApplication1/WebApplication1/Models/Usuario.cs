using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuario
    {
        [Required] //con esto hacemos que sea obligatorio el nombre de usuario y pass
        public string nombreUsuario { get; set; }
        [Required]
        public string password { get; set; }
    }
}