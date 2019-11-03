using System;
using Foundation;
using UIKit;

namespace _18.Slidingmenu.ViewControllers
{
    public partial class MenuTableViewController : UITableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("MenuTableViewController", NSBundle.MainBundle);

        public static readonly NSString Key = new NSString("MenuTableViewController");

        public MenuTableViewController(IntPtr handle) : base(handle)
        {
            Console.WriteLine("N0rf3n - MenuTableViewController - MenuTableViewController");
        }

        public static MenuTableViewController Create()
        {
            Console.WriteLine("N0rf3n - MenuTableViewController - MenuTableViewController - Create");
            return (MenuTableViewController)Nib.Instantiate(null, null)[0];
           
        }

        internal void BindData(string strLabel, string strIconPath)
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

