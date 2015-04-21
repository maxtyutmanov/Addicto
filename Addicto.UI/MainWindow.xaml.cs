using Addicto.UI.Utils;
using Addicto.UI.VM;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Addicto.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainVM _vm;

        public MainWindow()
        {
            InitializeComponent();

            var ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Main.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    this.Show();
                    this._vm.Visible = false;
                };
            this._vm = new MainVM();
            this.DataContext = this._vm;
            this.Deactivated += MainWindow_Deactivated;
            this._vm.VisibleChanged += _vm_VisibleChanged;

            this.UpdateVisibility();
        }

        private void _vm_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisibility();
        }

        private void UpdateVisibility()
        {
            if (this._vm.Visible)
            {
                this.Show();
                Point mousePos = GetMousePosition();
                this.Left = mousePos.X;
                this.Top = mousePos.Y;
            }
            else
            {
                this.Hide();
            }
        }

        private void MainWindow_Deactivated(object sender, EventArgs e)
        {
            this._vm.Visible = false;
        }

        private Point GetMousePosition()
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new Point(point.X, point.Y);
        }
    }
}
