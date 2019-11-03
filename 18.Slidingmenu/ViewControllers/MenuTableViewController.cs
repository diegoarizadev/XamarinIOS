using System;
using Foundation;
using UIKit;

namespace _18.Slidingmenu.ViewControllers
{
    public partial class MenuTableViewController : UITableViewCell
    {
        public static readonly UINib Nib = UINib.FromName("MenuTableViewCell", NSBundle.MainBundle);

        public static readonly NSString Key = new NSString("MenuTableViewCell");

        public MenuTableViewController(IntPtr handle) : base(handle)
        {
        }

        public static MenuTableViewController Create()
        {
            return (MenuTableViewController)Nib.Instantiate(null, null)[0];
        }

        internal void BindData(string strLabel, string strIconPath)
        {
            lblTexto.Text = strLabel;
            image.Image = UIImage.FromBundle(strIconPath);
        }
    }
}

