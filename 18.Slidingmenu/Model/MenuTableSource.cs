using System;
using _18.Slidingmenu.ViewControllers;
using UIKit;

namespace _18.Slidingmenu.Model
{
    public class MenuTableSource : UITableViewSource
    {

        readonly string[] arrMenuText;
        readonly string[] arrMenuIcon;
        internal event Action<string> MenuSelected;

        public MenuTableSource()
        {
            Console.WriteLine("N0rf3n - MenuTableSource - MenuTableSource - Begin");
            arrMenuText = Constants.arrMenuText;
            arrMenuIcon = Constants.arrMenuIcon;
            Console.WriteLine("N0rf3n - MenuTableSource - MenuTableSource - End");
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            Console.WriteLine("N0rf3n - MenuTableSource - UITableViewCell - Begin");
            MenuTableViewController cell = (MenuTableViewController)tableView.DequeueReusableCell("MenuTableViewController");
            Console.WriteLine("N0rf3n - MenuTableSource - UITableViewCell - arrMenuText[indexPath.Row] : "+ arrMenuText[indexPath.Row]);
            Console.WriteLine("N0rf3n - MenuTableSource - UITableViewCell - arrMenuIcon[indexPath.Row] : "+ arrMenuIcon[indexPath.Row]);
            cell.BindData(arrMenuText[indexPath.Row], arrMenuIcon[indexPath.Row]);
            Console.WriteLine("N0rf3n - MenuTableSource - UITableViewCell - End");
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            Console.WriteLine("N0rf3n - MenuTableSource - RowsInSection - arrMenuText.Length : "+ arrMenuText.Length);
            return arrMenuText.Length;
           
        }

        public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            Console.WriteLine("N0rf3n - MenuTableSource - RowSelected - Begin");
            if (MenuSelected != null)
                MenuSelected(arrMenuText[indexPath.Row]);

            tableView.DeselectRow(indexPath, true);
            Console.WriteLine("N0rf3n - MenuTableSource - RowSelected - End");
        }

        public override UIView GetViewForFooter(UITableView tableView, nint section)
        {
            Console.WriteLine("N0rf3n - MenuTableSource - GetViewForFooter");
            return new UIView();
        }
    }
}
