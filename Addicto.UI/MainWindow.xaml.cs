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
        private readonly IKeyboardListener _kbListener;
        private readonly ITextFetcher _textFetcher;
        private readonly IDataServiceFacade _dataServiceFacade;

        public MainWindow()
            : this(new KeyboardListener(), new TextFetcher(), new DataServiceFacade()) //poor man's injection
        {
        }

        public MainWindow(IKeyboardListener kbListener, ITextFetcher textFetcher, IDataServiceFacade dataServiceFacade)
        {
            InitializeComponent();

            _kbListener = kbListener;
            _textFetcher = textFetcher;
            _dataServiceFacade = dataServiceFacade;

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
            
            _kbListener.MagicCombinationPressed += _kbListener_MagicCombinationPressed;
        }

        private async void _kbListener_MagicCombinationPressed(object sender, EventArgs e)
        {
            string selectedTxt = _textFetcher.FetchSelectedText();
            string foundTxt = await _dataServiceFacade.FindArticleAsync(selectedTxt);

            if (!String.IsNullOrEmpty(foundTxt))
            {
                _popupWindowVM.Visible = true;
                _popupWindowVM.FoundText = foundTxt;
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
