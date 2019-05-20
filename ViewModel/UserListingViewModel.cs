using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessON.Common;
using FitnessON.Infra;
using FitnessON.Logic;
using FitnessON.Model;
using Excel = Microsoft.Office.Interop.Excel;
using NsExcel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Controls;
using System.ComponentModel;
using System.Diagnostics;

namespace FitnessON.ViewModel
{
    public class UserListingViewModel : NotificationClass, Microsoft.Office.Interop.Excel.Window,IUserListingContent
    {
        public List<User> users=new List<User>();
        public string Header => "Ügyfél keresés";
        public User selectedUser;

        public UserListingViewModel()
        {
            GetUsers();
            this.RefreshUsers = new RelayCommand(this.RefreshUsersExecute);
            this.ExportData = new RelayCommand(this.Export);
            this.DeleteUserCommand = new RelayCommand(this.DeleteUserExecute);
        }

        public void DeleteUserExecute()
        {
            if(this.SelectedUser != null)
            {
                Data.Controller.DeleteUser(SelectedUser);
                GetUsers();
            }
        }
        public RelayCommand DeleteUserCommand
        {
            get;
            set;
        }
        public User SelectedUser
        {
            get
            {
                return this.selectedUser;
            }
            set
            {
                this.selectedUser = value;
                this.OnProprtyChanged();
            }
        }

        public List<User> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
                this.OnProprtyChanged();
            }
        }

        public void GetUsers()
        {
            this.Users = Data.Controller.GetUsers();
        }

        public RelayCommand ExportData
        {
            get;
            set;
        }

        
        public RelayCommand RefreshUsers
        {
            get;
            set;
        }
        public void Export()
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet = (Worksheet)workbook.Sheets[1];
            string[] headers = new string[] { "Id", "Name", "Phone number", "Email address", "Card Id", "Image link", "Permission" };
            int[] columnWidth = new int[] { 7, 20, 15, 25, 12, 20, 10 };
            int row = 2;
            for (int j = 0; j < headers.Count(); j++)
            {
                Range myRange = (Range)sheet.Cells[1, j + 1];
                sheet.Cells[1, j + 1].Font.Bold = true;
                sheet.Columns[j + 1].ColumnWidth = columnWidth[j];
                myRange.Value2 = headers[j];
            }
            for (int i = 0; i < users.Count(); i++)
            {
                string[] line = new string[] {
                    users.ElementAt(i).Id.ToString(),
                    users.ElementAt(i).Name.ToString(),
                    users.ElementAt(i).Phone.ToString(),
                    users.ElementAt(i).Email.ToString(),
                    users.ElementAt(i).Card_Id.ToString(),
                    users.ElementAt(i).Picture.ToString(),
                    users.ElementAt(i).Permission.ToString()};
                for(int j = 0; j < line.Count(); j++)
                {
                    Range myRange = (Range)sheet.Cells[i+2, j + 1];
                    myRange.Value2 = line[j];
                }
            }

        }

        private void DG_Hyperlink_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Hyperlink link = (Hyperlink)e.OriginalSource;
            Process.Start(link.Address);
        }

        public void RefreshUsersExecute()
        {
            GetUsers();
        }

        public dynamic Activate()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public Application Application => throw new NotImplementedException();

        public XlCreator Creator => throw new NotImplementedException();

        public dynamic Parent => throw new NotImplementedException();

        public Range ActiveCell => throw new NotImplementedException();

        public Chart ActiveChart => throw new NotImplementedException();

        public Pane ActivePane => throw new NotImplementedException();

        public dynamic ActiveSheet => throw new NotImplementedException();

        public dynamic Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayFormulas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayGridlines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHeadings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHorizontalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayOutline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool _DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayVerticalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWorkbookTabs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayZeros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableResize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FreezePanes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GridlineColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlColorIndex GridlineColorIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Index => throw new NotImplementedException();

        public double Left { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string OnWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Panes Panes => throw new NotImplementedException();

        public Range RangeSelection => throw new NotImplementedException();

        public int ScrollColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScrollRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Sheets SelectedSheets => throw new NotImplementedException();

        public dynamic Selection => throw new NotImplementedException();

        public bool Split { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitHorizontal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitVertical { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TabRatio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Top { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public XlWindowType Type => throw new NotImplementedException();

        public double UsableHeight => throw new NotImplementedException();

        public double UsableWidth => throw new NotImplementedException();

        public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Range VisibleRange => throw new NotImplementedException();

        public double Width { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int WindowNumber => throw new NotImplementedException();

        public XlWindowState WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic Zoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlWindowView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SheetViews SheetViews => throw new NotImplementedException();

        public dynamic ActiveSheetView => throw new NotImplementedException();

        public bool DisplayRuler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoFilterDateGrouping { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWhitespace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Hwnd => throw new NotImplementedException();
    }
}
