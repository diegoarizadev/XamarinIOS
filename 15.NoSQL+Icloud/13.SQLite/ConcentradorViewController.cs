using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Foundation;
using SQLite;
using UIKit;

namespace _13.SQLite
{
    public partial class ConcentradorViewController : UIViewController
    {
        List<Pasajeros> Lista = new List<Pasajeros>();
        UIAlertController Alerta;

        public ConcentradorViewController() : base("ConcentradorViewController", null)
        {
        }

        protected ConcentradorViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
          
        }

       

    }
}

