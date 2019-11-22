using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace _19.TableViewExpandible
{
    public class MyTableSource : UITableViewSource
    {

        readonly public List<Datos> Data;

        public MyTableSource()
        {
        }

        public MyTableSource(List<Datos> data)
        {
            this.Data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            MyTableViewCell cell = (MyTableViewCell)tableView.DequeueReusableCell("CellCustom");
            cell.SetupCell(this.Data[indexPath.Row]);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Data.Count;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 100;
        }
    }
}
