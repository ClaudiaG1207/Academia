using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DEstudiantescs
    {
        CD_Conexion Conect = new CD_Conexion();

        public void InseeEtudiantes(string ced, string NomA, string direc, int Edad, int cel, string correo, string nacionalidad )
        {
            Conect.Abrir();
            SqlCommand AggUser = new SqlCommand("AgregarEstudiante", CD_Conexion.conectar);
            AggUser.CommandType = CommandType.StoredProcedure;
            AggUser.Parameters.AddWithValue("@Cedula", ced);
            AggUser.Parameters.AddWithValue("@NomAp", NomA);
            AggUser.Parameters.AddWithValue("@Direccion", direc);
            AggUser.Parameters.AddWithValue("@Edad", Edad);
            AggUser.Parameters.AddWithValue("@cel", cel);
            AggUser.Parameters.AddWithValue("@Correo", correo);
            AggUser.Parameters.AddWithValue("@Nacionalidad", nacionalidad);
            AggUser.ExecuteNonQuery();
            Conect.cerrar();

        }
        public void MostarEstudiante(ref DataTable dt)
        {
            try
            {
                Conect.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ListarEstudiantes", CD_Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally { Conect.cerrar(); }
        }


    }
}
