using API_SQLSERVER;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_SQLServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {

        [HttpGet("AlmacenarSQLServer")]
        public string Almacenar(string RazonSocial, string RFC, string Telefono, string Pais, string Ciudad, string Calle, string No, string Correo, double Monto, string Fecha, string MetodoDePago)
        {
            var Almacena = new StorageSQL();
            bool resultado = Almacena.Almacenar(RazonSocial, RFC, Telefono, Pais, Ciudad, Calle, No, Correo, Monto, Fecha, MetodoDePago);
            if (resultado == true)
            {
                return "Almacenado en SQL Server " +
                    "desde API en .NET";
            }
            else
            {
                return "No almacenado";
            }
        }

        [HttpGet("ConsultarSQLServer")]
        public JsonResult Consultar(int ID)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.Consulta(ID);
            return new JsonResult(Lista);
        }

        [HttpGet("ConsultarTodo")]
        public JsonResult ConsultarTodo()
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.ConsultaTodo();
            return new JsonResult(Lista);
        }
    }
}