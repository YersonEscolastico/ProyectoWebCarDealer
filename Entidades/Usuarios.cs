﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {

        [Key]

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public DateTime Fecha { get; set; }


        public Usuarios()
        {
            UsuarioId = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Usuario = string.Empty;
            Clave = string.Empty;
            Fecha = DateTime.Now;
        }
    }
}
