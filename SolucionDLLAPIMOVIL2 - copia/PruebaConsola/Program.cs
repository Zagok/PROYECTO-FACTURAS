// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var dll = new DLLConexion.ClaseConexion();
if (dll.Conexion())
{
    Console.WriteLine("Conexion Exitosa");
    Console.ReadLine();
}
else
{
    Console.WriteLine("Conexion No Exitosa");
    Console.ReadLine();
}