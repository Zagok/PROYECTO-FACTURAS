using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Text.Json.Serialization;
using Org.Apache.Http.Client.Params;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AppAccesoSQLServerAPI
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class MainActivity : AppCompatActivity
    {
        EditText txtRazonSocial, txtCorreo, txtFecha, txtPais, txtMonto, txtMetodoDePago, txtTelefono, txtCiudad, txtCalle, txtNo, txtRFC, txtBuscarRFC;
        string ID;

        HttpClient client = new HttpClient();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activitymain);

            txtRazonSocial = FindViewById<EditText>(Resource.Id.txtrazonsocial);
            txtCorreo = FindViewById<EditText>(Resource.Id.txtcorreo);
            txtFecha = FindViewById<EditText>(Resource.Id.txtfecha);
            txtPais = FindViewById<EditText>(Resource.Id.txtpais);
            txtMonto = FindViewById<EditText>(Resource.Id.txtmonto);
            txtMetodoDePago = FindViewById<EditText>(Resource.Id.txtmetododepago);
            txtTelefono = FindViewById<EditText>(Resource.Id.txttelefono);
            txtCiudad = FindViewById<EditText>(Resource.Id.txtciudad);
            txtCalle = FindViewById<EditText>(Resource.Id.txtcalle);
            txtNo = FindViewById<EditText>(Resource.Id.txtno);
            txtRFC = FindViewById<EditText>(Resource.Id.txtrfc);
            txtBuscarRFC = FindViewById<EditText>(Resource.Id.txtbuscarrfc);
            //var btnAlmacenar = FindViewById<Button>(Resource.Id.btnguardar);
            var btnBuscar = FindViewById<Button>(Resource.Id.btnbuscar);

                btnBuscar.Click += async delegate
                {
                    try
                    {
                        ID = txtBuscarRFC.Text;
                        var API = "https://facturas01.azurewebsites.net/Principal/ConsultarSQLServer?ID=" + ID;
                        var json = await TraerDatos(API);
                        foreach (var r in json)
                        {
                            txtRazonSocial.Text = r.RazonSocial;
                            txtCorreo.Text= r.Correo;
                            txtFecha.Text= r.Fecha;
                            txtPais.Text= r.Pais;
                            txtMonto.Text = r.Monto.ToString();
                            txtMetodoDePago.Text= r.MetodoDePago;
                            txtTelefono.Text= r.Telefono;
                            txtCiudad.Text= r.Ciudad;
                            txtCalle.Text= r.Calle;
                            txtNo.Text= r.No;
                            txtRFC.Text= r.RFC;
                        }
                    }
                    catch (System.Exception ex)
                    {


                        Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    }
                };
            }
            private async Task<List<Datos>>
            TraerDatos(string API)
            {
                client.DefaultRequestHeaders.Accept.Clear();
                var streamTask = client.GetStreamAsync(API);
                var repositories = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Datos>>(await streamTask);
                return repositories;
            }
            public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
            {
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }

        public class Datos
        {
            [JsonPropertyName("razonSocial")]

            public string RazonSocial { get; set; }

            [JsonPropertyName("correo")]

            public string Correo { get; set; }

            [JsonPropertyName("fecha")]

            public string Fecha { get; set; }

            [JsonPropertyName("pais")]

            public string Pais { get; set; }

            [JsonPropertyName("monto")]

            public double Monto { get; set; }

            [JsonPropertyName("metodoDePago")]

            public string MetodoDePago { get; set; }

            [JsonPropertyName("telefono")]

            public string Telefono { get; set; }

            [JsonPropertyName("ciudad")]

            public string Ciudad { get; set; }

            [JsonPropertyName("calle")]

            public string Calle { get; set; }

            [JsonPropertyName("no")]

            public string No { get; set; }

            [JsonPropertyName("rfc")]

            public string RFC { get; set; }
        }
}