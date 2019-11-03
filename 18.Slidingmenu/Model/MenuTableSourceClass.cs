using System;
using _18.Slidingmenu.ViewControllers;
using Foundation;
using UIKit;

namespace _18.Slidingmenu.Model
{
    public class MenuTableSourceClass : UITableViewSource
    {

        readonly string[] arrMenuText;
        readonly string[] arrMenuIcon;
        internal event Action<string> MenuSelected;


        public MenuTableSourceClass()
        {
            arrMenuText = Constants.arrMenuText;
            arrMenuIcon = Constants.arrMenuIcon;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return arrMenuText.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            MenuTableViewController cell = tableView.DequeueReusableCell(MenuTableViewController.Key) as MenuTableViewController ?? MenuTableViewController.Create();
            cell.BindData(arrMenuText[indexPath.Row], arrMenuIcon[indexPath.Row]);
            return cell;
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            if (MenuSelected != null)
                MenuSelected(arrMenuText[indexPath.Row]);

            tableView.DeselectRow(indexPath, true);
        }

        public override UIView GetViewForFooter(UITableView tableView, nint section)
        {
            return new UIView();
        }
    }
}
