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
    public class DUsuarios
    {
        CD_Conexion Conect = new CD_Conexion();
        public void Insertar(string Usuario, string Password)
        {
            Conect.Abrir();
            SqlCommand AggUser = new SqlCommand("Agregar_Usuario", CD_Conexion.conectar);
            AggUser.CommandType = CommandType.StoredProcedure;
            AggUser.Parameters.AddWithValue("@Usuario", Usuario);
            AggUser.Parameters.AddWithValue("@Clave", Password);
            AggUser.ExecuteNonQuery();
            Conect.cerrar();
        }

        public void MostarUsuarios(ref DataTable dt)
        {
            try
            {
                Conect.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("ListarUsuarios", CD_Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
            finally { Conect.cerrar(); }
        }


        public string Login(string User)
        {
            string ContraseñaHash = "";
            Conect.Abrir();
            SqlCommand SearchUser = new SqlCommand("BusquedaUsuario", CD_Conexion.conectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            SearchUser.Parameters.AddWithValue("@Usuario", User);
            SqlDataReader LeerDatos = SearchUser.ExecuteReader();
            while (LeerDatos.Read())
            {
                ContraseñaHash = (string)LeerDatos["Clave"];
            }
            Conect.cerrar();
            return ContraseñaHash;
        }

    }
}
