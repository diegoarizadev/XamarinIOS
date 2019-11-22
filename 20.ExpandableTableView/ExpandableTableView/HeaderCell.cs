using System;
using Foundation;
using UIKit;

namespace ExpandableTableView
{
	public partial class HeaderCell : UITableViewHeaderFooterView
	{
		public static readonly NSString Key = new NSString("HeaderCell");
		public static readonly UINib Nib;

        protected HeaderCell(IntPtr handle) : base(handle)
        {
        }

        static HeaderCell()
		{
			Nib = UINib.FromName("HeaderCell", NSBundle.MainBundle);
		}

	
	}
}
