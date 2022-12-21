using System;
using System.Data;
using System.Data.SqlClient;

namespace API_SQLSERVER
{
    public class StorageSQL
    {
        public List<Datos> ListaFactura;

        public bool Almacenar(string RazonSocial, string RFC, string Telefono, string Pais, string Ciudad, string Calle, string No, string Correo, double Monto, string Fecha, string MetodoDePago)
        {
            //var connect = new SqlConnection("Data Source=HEGO-C\\SQLEXPRESS; Initial Catalog=Facturas; User ID=sa; Password=Mexico2022;");
            var connect = new SqlConnection("Server=tcp:svrcarlos.database.windows.net,1433;Initial Catalog=Facturas;Persist Security Info=False;User ID=Cadmin;Password=011A2001#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var query = new SqlCommand("INSERT INTO Datos (RazonSocial, RFC, Telefono, Pais, Ciudad, Calle, No, Correo, Monto, Fecha, MetodoDePago) VALUES " +
                "('" + RazonSocial + "','" + RFC + "','" + Telefono + "','" + Pais + "','" + Ciudad + "','" + Calle + "','" + No + "','" + Correo + "','" + Monto + "','" + Fecha + "','" + MetodoDePago + "')", connect);

            try
            {
                connect.Open();
                query.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception ex)
            {
                connect.Close();
                return false;
            }
        }

        public List<Datos> Consulta(int ID)
        {
            var dt = new DataTable();
            //var connect = new SqlConnection("Data Source=HEGO-C\\SQLEXPRESS; Initial Catalog=Facturas; User ID=sa; Password=Mexico2022;");
            var connect = new SqlConnection("Server=tcp:svrcarlos.database.windows.net,1433;Initial Catalog=Facturas;Persist Security Info=False;User ID=Cadmin;Password=011A2001#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            var cmd = new SqlCommand("SELECT * FROM Datos WHERE " +
                "ID='" + ID + "'", connect);

            try
            {
                ListaFactura = new List<Datos>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Datos fac = new Datos();
                    fac.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    fac.RazonSocial = dt.Rows[i]["RazonSocial"].ToString();
                    fac.RFC = dt.Rows[i]["RFC"].ToString();
                    fac.Telefono = dt.Rows[i]["Telefono"].ToString();
                    fac.Pais = dt.Rows[i]["Pais"].ToString();
                    fac.Ciudad = dt.Rows[i]["Ciudad"].ToString();
                    fac.Calle = dt.Rows[i]["Calle"].ToString();
                    fac.No = dt.Rows[i]["NO"].ToString();
                    fac.Correo = dt.Rows[i]["Correo"].ToString();
                    fac.Monto = double.Parse(dt.Rows[i]["Monto"].ToString());
                    fac.Fecha = dt.Rows[i]["Fecha"].ToString();
                    fac.MetodoDePago = dt.Rows[i]["MetodoDePago"].ToString();
                    ListaFactura.Add(fac);
                }
                return ListaFactura;

            }
            catch (Exception)
            {
                connect.Close();
                return ListaFactura;
            }
        }


        public List<Datos> ConsultaTodo()
        {
            var dt = new DataTable();
            //var connect = new SqlConnection("Data Source=HEGO-C\\SQLEXPRESS; Initial Catalog=Facturas; User ID=sa; Password=Mexico2022;");
            var connect = new SqlConnection("Server=tcp:svrcarlos.database.windows.net,1433;Initial Catalog=Facturas;Persist Security Info=False;User ID=Cadmin;Password=011A2001#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            var cmd = new SqlCommand("SELECT * FROM Datos", connect);

            try
            {
                ListaFactura = new List<Datos>();
                connect.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                connect.Close();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Datos fac = new Datos();
                    fac.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                    fac.RazonSocial = dt.Rows[i]["RazonSocial"].ToString();
                    fac.RFC = dt.Rows[i]["RFC"].ToString();
                    fac.Telefono = dt.Rows[i]["Telefono"].ToString();
                    fac.Pais = dt.Rows[i]["Pais"].ToString();
                    fac.Ciudad = dt.Rows[i]["Ciudad"].ToString();
                    fac.Calle = dt.Rows[i]["Calle"].ToString();
                    fac.No = dt.Rows[i]["NO"].ToString();
                    fac.Correo = dt.Rows[i]["Correo"].ToString();
                    fac.Monto = double.Parse(dt.Rows[i]["Calle"].ToString());
                    fac.Fecha = dt.Rows[i]["Fecha"].ToString();
                    fac.MetodoDePago = dt.Rows[i]["MetodoDePago"].ToString();
                    ListaFactura.Add(fac);
                }
                return ListaFactura;

            }
            catch (Exception)
            {
                connect.Close();
                return ListaFactura;
            }
        }
    }


}