using CapaNegocio;
using ProyecAcademiaEuropea;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyecAcademiaEuropea
{
    public partial class RegistroEstudiantes : Form
    {
        public RegistroEstudiantes()
        {
            InitializeComponent();
            MostrarEstudiante();
        }

        NEstudiantes Estudiante = new NEstudiantes();
        public string FCedula;
        public string FNomAp;
        public string FDirec;
        public int FEdad;
        public int FCel;
        public string FCorreo;
        public string FNacionalidad;

        private void INSERTAR()

        {
            FCedula = TxtCedEstu.Text;
            FNomAp = TxtNomEstu.Text;
            FDirec= TxtDirecEstu.Text;
            FEdad = int.Parse(TxtEdadEStu.Text);
            FCel = int.Parse(TxtCelEstu.Text);
            FCorreo = TxtCorreoEstu.Text;
            FNacionalidad = CBNacionalidad.Text;

            TxtCedEstu.Clear();
            TxtNomEstu.Clear();
            TxtDirecEstu.Clear();
            TxtEdadEStu.Clear();
            TxtCelEstu.Clear();
            TxtCorreoEstu.Clear();
            CBNacionalidad.Text = "";
            Estudiante.AgregarEstudiante(FCedula, FNomAp, FDirec, FEdad,FCel, FCorreo, FNacionalidad);
            MostrarEstudiante();
            MessageBox.Show("Se realizo el regitro con exito");
        }

        private void MostrarEstudiante()
        {
            DataTable dt = new DataTable();
            NEstudiantes funcion = new NEstudiantes();
            funcion.MostarEstudiante(dt);
            dtEstudiantes.DataSource = dt;
            Bases.DiseñoDtv(ref dtEstudiantes);
            dtEstudiantes.Columns[7].Visible = false;
        }
        private void TxtDirecEstu_TextChanged(object sender, EventArgs e)
        {

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

        private void RegistroEstudiantes_Load(object sender, EventArgs e)
        {

        }
        
        private void dtEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
