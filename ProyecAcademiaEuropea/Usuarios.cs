using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace ProyecAcademiaEuropea
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }
        NUsuarios Usuario= new NUsuarios();

        public string USUARIO;
        public string CLAVE;

        private void INSERTAR()
        {
            USUARIO= TxtUsuario.Text;
            CLAVE = TxtContra.Text;
            Usuario.AgregarUsuario(USUARIO, CLAVE);

            TxtContra.Clear();
            TxtUsuario.Clear();
            MostrarUsuarios();
            MessageBox.Show("Se realizo el regitro con exito");
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                INSERTAR();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }
        private void MostrarUsuarios()
        {
            DataTable dt = new DataTable();
            NUsuarios funcion = new NUsuarios();
            funcion.MostarUsuarios(dt);
            dtUsuarios.DataSource = dt;
            Bases.DiseñoDtv(ref dtUsuarios);
            dtUsuarios.Columns[3].Visible= false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPrincipal FP = new FormPrincipal();
            FP.Show();
        }
    }
}
