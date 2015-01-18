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
        private KeyboardHookListener _kbListener;
        private bool _magicCombination;

        public MainWindow()
        {
            InitializeComponent();

            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Main.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };

            _kbListener = new KeyboardHookListener(new GlobalHooker());
            _kbListener.Enabled = true;
            _kbListener.KeyDown += _kbListener_KeyDown;
            _kbListener.KeyUp += _kbListener_KeyUp;
        }

        void _kbListener_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == System.Windows.Forms.Keys.LWin)
            {
                _magicCombination = true;
            }
            else
            {
                _magicCombination = false;
            }
        }

        async void _kbListener_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.LWin && _magicCombination)
            {
                string txt = TxtFetcherFacade.FetchSelectedText();
                DataService.Client.Proxies.Clients.ArticlesDsProxy proxy = new DataService.Client.Proxies.Clients.ArticlesDsProxy();

                var response = await proxy.GetAsync(txt);
                var result = await response.Content.ReadAsStringAsync();

                MessageBox.Show(result);
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
