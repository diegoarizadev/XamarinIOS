using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
namespace _16.AccesoAzureIcloud
{
    public class OrigenTabla : UITableViewSource
    {
        List<Pasajeros> pasajero;
        public OrigenTabla(List<Pasajeros> Pasajeros)
        {
            pasajero = Pasajeros;
        }
        public override UITableViewCell GetCell(UITableView tableView,
                                                NSIndexPath indexPath)
        {
            var Celda = (CeldaController)tableView.DequeueReusableCell
                                                  ("IDCelda", indexPath);
            var asistente = pasajero[indexPath.Row];
            Celda.ActualizarCelda(asistente);
            return Celda;
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return pasajero.Count;
        }
    }
}
