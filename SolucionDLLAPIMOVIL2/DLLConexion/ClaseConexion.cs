using System.Data;
using System.Data.SqlClient;
namespace DLLConexion
{
    public class ClaseConexion
    {
        public bool Conexion()
        {
            var con = new SqlConnection("Data Source=HEGO-C\\SQLEXPRESS; Initial Catalog=Informacion2; User ID=sa; Password=Mexico2022;");
            try
            {
                con.Open();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                con.Close();
                return false;
            }
        }
    }
}