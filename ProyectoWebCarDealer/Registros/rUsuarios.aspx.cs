using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Entidades;
using DAL;
using BLL;

namespace ProyectoWebCarDealer.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaRegistros.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
        private void Limpiar()
        {
            IdNumericUpDown.Text = "0";
            NombresTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            usuario.Text = string.Empty;
            ConfirmarClaveTextBox.Text = string.Empty;
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Usuarios LlenarClase()
        {
            Usuarios usuarios = new Usuarios();

            int.TryParse(IdNumericUpDown.Text, out int idx);
            usuarios.Nombre = NombresTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.Usuario = usuario.Text;
            usuarios.Clave = ClaveTextBox.Text;
            return usuarios;
        }

        private void LlenarCampos(Usuarios usuarios)
        {
            IdNumericUpDown.Text = Convert.ToString(usuarios.UsuarioId);
            NombresTextBox.Text = usuarios.Nombre;
            EmailTextBox.Text = usuarios.Email;
            usuario.Text = usuarios.Usuario;
            usuario.Text = usuarios.Clave;
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(IdNumericUpDown.Text) || string.IsNullOrWhiteSpace(NombresTextBox.Text) || string.IsNullOrWhiteSpace(usuario.Text) || string.IsNullOrWhiteSpace(ClaveTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text) || ConfirmarClaveTextBox.Text != ClaveTextBox.Text)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                paso = false;
            }
            return paso;
        }

        public static bool RepetirUser(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuarios.Any(p => p.Usuario.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static bool RepetirEmail(string descripcion)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Usuarios.Any(p => p.Email.Equals(descripcion)))
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool ValidarRepetir()
        {
            bool paso = true;

            if (RepetirUser(usuario.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            if (RepetirEmail(EmailTextBox.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Repeticion()", true);
                paso = false;
            }
            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = Repositorio.Buscar(Convert.ToInt32(IdNumericUpDown.Text));
            return (usuarios != null);
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            Usuarios usuarios;

            bool paso = false;
            if (!Validar())
                return;

            usuarios = LlenarClase();

            int.TryParse(IdNumericUpDown.Text, out int idx);
            if (idx == 0)
            {
                if (!ValidarRepetir())
                    return;

                paso = db.Guardar(usuarios);
                Limpiar();
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
                    return;
                }
                paso = db.Modificar(usuarios);
                Limpiar();
            }

            if (paso)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                return;
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }

        protected void buscarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> db = new RepositorioBase<Usuarios>();
            int id;
            Usuarios usuarios = new Usuarios();
            int.TryParse(IdNumericUpDown.Text, out int idx);

            usuarios = db.Buscar(idx);
            if (usuarios != null)
                LlenarCampos(usuarios);
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }


        protected void Eliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> Repositorio = new RepositorioBase<Usuarios>();
            int idx;
            int.TryParse(IdNumericUpDown.Text, out idx);

            var usuario = Repositorio.Buscar(idx);
            if (usuario != null)
            {
                if (Repositorio.Eliminar(idx))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Exito()", true);
                    Limpiar();
                }
                else
                    ClientScript.RegisterStartupScript(this.GetType(), "Pop", "Validacion()", true);
            }
            else
                ClientScript.RegisterStartupScript(this.GetType(), "Pop", "SinExito()", true);
        }
    }
}