using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace _19.TableViewExpandible
{
    public partial class MyTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("CellCustom");
        public static readonly UINib Nib;

        static MyTableViewCell()
        {
            Nib = UINib.FromName("CellCustom", NSBundle.MainBundle);
        }

        protected MyTableViewCell(IntPtr handle) : base(handle)
        {
        }

        public void SetupCell(Datos info)
        {

            lblDescription.Text = info.Description;
            lblTitle.Text = info.Name;

        }

    }
}
