using System;
using Foundation;
using UIKit;

namespace _19.TableViewExpandible
{
    public partial class TableCell : UITableViewCell
    {

        public static readonly NSString Key = new NSString("TableCell");
        public static readonly UINib Nib;

        public TableCell(IntPtr handle) : base(handle)
        {
        }

        static TableCell()
        {
            Nib = UINib.FromName("TableCell", NSBundle.MainBundle);
        }

    

    }
}

