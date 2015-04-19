using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI.Utils
{
    public class KeyboardListener : IKeyboardListener
    {
        private readonly KeyboardHookListener _kbListener;
        private bool _magicCombination;

        public event EventHandler MagicCombinationPressed;

        public KeyboardListener()
        {
            _kbListener = new KeyboardHookListener(new GlobalHooker());
            _kbListener.Enabled = true;
            _kbListener.KeyDown += _kbListener_KeyDown;
            _kbListener.KeyUp += _kbListener_KeyUp;
        }

        private void _kbListener_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

        private void _kbListener_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.LWin && _magicCombination)
            {
                OnMagicCombinationPressed();
            }
        }

        protected void OnMagicCombinationPressed()
        {
            var handler = MagicCombinationPressed;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
