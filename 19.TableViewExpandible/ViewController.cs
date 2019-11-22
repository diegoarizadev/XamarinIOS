using System;
using System.Collections.Generic;
using Foundation;
using UIKit;
using CoreGraphics;

namespace _19.TableViewExpandible
{
    public partial class ViewController : UIViewController
    {

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //Se construye el diccionario con la información
            var Diccionario = new Dictionary<string, List<string>>
            {
                { "Header1", new List<string> { "\ud83d\ude01", "\ud83d\ude02"  } },
                { "Header2", new List<string> { "\ud83d\udc2f"  } }
            };

            //construcción de la data para la tabla
            var lista = new List<ExpandableTableModel<string>>();
            foreach (var section in Diccionario)
            {
                var Secciones = new ExpandableTableModel<string>()
                {
                    Titulo = section.Key //Se asigna la sección dependiendo del arreglo.

                };

                foreach (var row in section.Value)
                {
                    Secciones.Add(row);
                }

                lista.Add(Secciones);
            }

            MyTable.RowHeight = 300; //Altura de la celda.
            MyTable.Source = new ExpandableTableSource<string>(lista, MyTable);
        }

        //Data Source custom para la tabla.
        public class ExpandableTableSource<T> : UITableViewSource
        {

            List<ExpandableTableModel<T>> ItemsTabla;
            private bool[] _isSectionOpen;
            private EventHandler _headerButtonCommand; //Acción del header.!

            //Constructor
            public ExpandableTableSource(List<ExpandableTableModel<T>> items, UITableView tableView)
            {

                ItemsTabla = items;
                _isSectionOpen = new bool[items.Count];

                //Inscripción de la de la celda y el header
                tableView.RegisterNibForCellReuse(UINib.FromName(TableCell.Key, NSBundle.MainBundle), TableCell.Key);
                tableView.RegisterNibForHeaderFooterViewReuse(UINib.FromName(HeaderCell.Key, NSBundle.MainBundle), HeaderCell.Key);


                //Acción del header
                _headerButtonCommand = (sender, e) =>
                {
                    var button = sender as UIButton;
                    var section = button.Tag;
                    _isSectionOpen[(int)section] = !_isSectionOpen[(int)section];
                    tableView.ReloadData();

                    //Animación para la seccion de las celdas.
                    var paths = new NSIndexPath[RowsInSection(tableView, section)];
                    for (int i = 0; i < paths.Length; i++)
                    {
                        paths[i] = NSIndexPath.FromItemSection(i, section);
                    }

                    //recagar de la celda
                    tableView.ReloadRows(paths, UITableViewRowAnimation.Automatic);

                };

            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(TableCell.Key, indexPath) as TableCell; //obtiene la celda.

                if (typeof(T) == typeof(string))
                {
                    var rowData = ItemsTabla[indexPath.Section][indexPath.Row] as string;
                    if (rowData != null)
                    {
                        cell.lblCell.Text = rowData;
                    }
                }

                return cell;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.CellAt(indexPath) as TableCell;
            }

            public override nint NumberOfSections(UITableView tableView) //Numero de secciones.
            {
                return ItemsTabla.Count;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return _isSectionOpen[(int)section] ? ItemsTabla[(int)section].Count : 0;
            }
            public override nfloat GetHeightForHeader(UITableView tableView, nint section) //altura para los header.
            {
                return 80f;
            }

            public override nfloat EstimatedHeightForHeader(UITableView tableView, nint section) //Altura estimada para el header..
            {
                return 80f;
            }

            public override nfloat EstimatedHeight(UITableView tableView, NSIndexPath indexPath)
            {
                return 200;
            }

            public override UIView GetViewForHeader(UITableView tableView, nint section) //Obteiene la vista del header.
            {
                HeaderCell header = tableView.DequeueReusableHeaderFooterView(HeaderCell.Key) as HeaderCell; //registro del header
                
                header.lblHeader.Text = ((ExpandableTableModel<T>)ItemsTabla[(int)section]).Titulo;
                foreach (var view in header.Subviews)
                {
                    if (view is HiddenHeaderButton)
                    {
                        view.RemoveFromSuperview();
                    }
                }
                var hiddenButton = CreateHiddenHeaderButton(header.Bounds, section);
                header.AddSubview(hiddenButton);

                return header;
            }

            //Asignación el boton y la acción del mismo.
            private HiddenHeaderButton CreateHiddenHeaderButton(CGRect frame, nint tag)
            {
                var button = new HiddenHeaderButton(frame);
                button.Tag = tag;
                button.TouchUpInside += _headerButtonCommand;
                return button;
            }

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
     
        }


        //subclase para el evento del header.
        public class HiddenHeaderButton : UIButton
        {
            public HiddenHeaderButton(CGRect frame) : base(frame)
            {

            }
        }

        //clase para el tipo de datos.
        public class ExpandableTableModel<T> : List<T>
        {
            public string Titulo { get; set; }
            public ExpandableTableModel(IEnumerable<T> collection) : base(collection) { }
            public ExpandableTableModel() : base() { }
        }

    }
}