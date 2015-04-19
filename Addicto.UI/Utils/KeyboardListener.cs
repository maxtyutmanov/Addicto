using Gma.UserActivityMonitor;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Addicto.UI.Utils
{
    public class KeyboardListener : IKeyboardListener
    {
        private class MagicCombination
        {
            private IDictionary<Keys, bool> _keyCodes;
            public bool WasComplete { get; set; }

            public MagicCombination(params Keys[] keyCodes)
            {
                _keyCodes = new Dictionary<Keys, bool>();
                foreach (Keys oneKey in keyCodes)
                {
                    _keyCodes.Add(oneKey, false);
                }
            }

            public bool IsComplete
            {
                get
                {
                    return _keyCodes.All(x => x.Value == true);
                }
            }

            public void OnKeyDown(Keys key)
            {
                if (_keyCodes.ContainsKey(key))
                {
                    _keyCodes[key] = true;
                }

                if (IsComplete)
                {
                    WasComplete = true;
                }
            }

            public void OnKeyUp(Keys key)
            {
                if (_keyCodes.ContainsKey(key))
                {
                    _keyCodes[key] = false;
                }
            }

            public bool Empty
            {
                get
                {
                    return _keyCodes.All(x => x.Value == false);
                }
            }

            public void Reset()
            {
                foreach (Keys oneKeyCode in _keyCodes.Keys.ToList())    //calling ToList(), otherwise we'll get runtime error
                {
                    _keyCodes[oneKeyCode] = false;
                }
            }
        }

        private readonly MagicCombination _magicCombination;

        public event EventHandler MagicCombinationPressed;

        public KeyboardListener()
        {
            _magicCombination = new MagicCombination(Keys.LMenu, Keys.LWin);

            HookManager.KeyDown += HookManager_KeyDown;
            HookManager.KeyUp += HookManager_KeyUp;
        }

        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            _magicCombination.OnKeyDown(e.KeyCode);
        }

        private void HookManager_KeyUp(object sender, KeyEventArgs e)
        {
            _magicCombination.OnKeyUp(e.KeyCode);

            if (_magicCombination.WasComplete && _magicCombination.Empty)
            {
                _magicCombination.WasComplete = false;
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
