using System;
using Foundation;
using UIKit;

namespace _18.Slidingmenu.ViewControllers
{
    public partial class MenuTableViewController : UITableViewCell
    {
        public static readonly NSString Key = new NSString("MenuTableViewController");
        public static readonly UINib Nib;

        public MenuTableViewController(IntPtr handle) : base(handle)
        {
            Console.WriteLine("N0rf3n - MenuTableViewController - MenuTableViewController");
        }

        static MenuTableViewController()
        {
            Console.WriteLine("N0rf3n - MenuTableViewController - Begin");
            Nib = UINib.FromName("MenuTableViewController", NSBundle.MainBundle);
            Console.WriteLine("N0rf3n - MenuTableViewController -  End");
        }

        internal void BindData(String strLabel, String strIconPath)
        {
            Console.WriteLine("N0rf3n - MenuTableViewController - BindData - Begin ");
            Console.WriteLine("N0rf3n - MenuTableViewController - BindData - strLabel :  "+ strLabel);
            Console.WriteLine("N0rf3n - MenuTableViewController - BindData - strIconPath :  " + strIconPath);
            lblTexto.Text = strLabel;
            imagen.Image = UIImage.FromBundle(strIconPath);
            Console.WriteLine("N0rf3n - MenuTableViewController - BindData - End ");
        }
    }
}

