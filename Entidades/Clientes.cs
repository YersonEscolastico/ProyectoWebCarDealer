using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        [Key]

        public int ClienteId { get; set; }
        public String Nombres { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public String Cedula { get; set; }
        public String Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombres = string.Empty;
            Sexo = string.Empty;
            Email = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            UsuarioId = 0;
            FechaRegistro = DateTime.Now;
        }
    }
}
