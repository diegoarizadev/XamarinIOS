using System;
using Microsoft.WindowsAzure.Storage.Table;
namespace _16.AccesoAzureIcloud
{
    public class Pasajeros : TableEntity
    {
        public Pasajeros(string Registros, string Nombre)
        {
            PartitionKey = Registros; //Clave de particion 
            RowKey = Nombre; //Clave de registros
        }
        public Pasajeros() { }
        public string Puesto { get; set; }
        public string Correo { get; set; }
        public string Empresa { get; set; }
        public string Fotografia { get; set; }
    }
}
