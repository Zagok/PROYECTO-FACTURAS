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
        EditText txtRazonSocial, txtCorreo, txtFecha, txtPais, txtMonto, txtMetodoDePago, txtTelefono, txtCiudad, txtCalle, txtNo, txtRFC;
        string RazonSocial, Correo, Fecha, Pais, MetodoDePago, Telefono, Ciudad, Calle, No, RFC;
        double Monto;

        HttpClient client = new HttpClient();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

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
            var btnAlmacenar = FindViewById<Button>(Resource.Id.btnguardar);
            //var btnBuscar = FindViewById<Button>(Resource.Id.btnbuscar);


            btnAlmacenar.Click += delegate
            {
                try
                {
                    RazonSocial = txtRazonSocial.Text;
                    Correo = txtCorreo.Text;
                    Fecha = txtFecha.Text;
                    Pais = txtPais.Text;
                    Monto = double.Parse(txtMonto.Text);
                    MetodoDePago = txtMetodoDePago.Text;
                    Telefono = txtTelefono.Text;
                    Ciudad = txtCiudad.Text;
                    Calle = txtCalle.Text;
                    No = txtNo.Text;
                    RFC = txtRFC.Text;
                    var API = "https://facturas01.azurewebsites.net/Principal/AlmacenarSQLServer?RazonSocial=" +
                    RazonSocial + "&Correo= " + Correo + "&Fecha= " + Fecha + "&Pais= " + Pais + "&Monto= " + Monto + "&MetodoDePago= " +
                    MetodoDePago + "&Telefono=" + Telefono + "&Ciudad=" + Ciudad + "&Calle=" + Calle + "&No=" + No + "&RFC=" + RFC;

                    HttpResponseMessage response =
                    client.GetAsync(API).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var products = response.Content.ReadAsStringAsync().Result;
                        Toast.MakeText(this, products.ToString(), ToastLength.Long).Show();
                    }
                    txtRazonSocial.Text = "";
                    txtCorreo.Text = "";
                    txtFecha.Text = "";
                    txtPais.Text = "";
                    txtMonto.Text = "";
                    txtMetodoDePago.Text = "";
                    txtTelefono.Text = "";
                    txtCiudad.Text = "";
                    txtCalle.Text = "";
                    txtNo.Text = "";
                    txtRFC.Text = "";
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };
        }
    }
}