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
        private PopupWindowVM _popupWindowVM;
        private readonly KeyboardListener _kbListener;

        public MainWindow()
        {
            InitializeComponent();
            _popupWindowVM = new PopupWindowVM();
            PopupWindow.DataContext = _popupWindowVM;

            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Main.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };

            _kbListener = new KeyboardListener();
            _kbListener.MagicCombinationPressed += _kbListener_MagicCombinationPressed;
        }

        private async void _kbListener_MagicCombinationPressed(object sender, EventArgs e)
        {
            string txt = TxtFetcherFacade.FetchSelectedText();

            var proxy = new DataService.Client.Proxies.Clients.ArticlesDsProxy();

            var response = await proxy.GetAsync(txt);
            var result = await response.Content.ReadAsStringAsync();

            if (!String.IsNullOrEmpty(result))
            {
                _popupWindowVM.Visible = true;
                _popupWindowVM.FoundText = result;
            }
            else
            {
                _popupWindowVM.Visible = false;
                _popupWindowVM.FoundText = String.Empty;
            }
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }
    }
}
