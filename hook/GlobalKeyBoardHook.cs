using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace lazy_manager.hook
{
    class GlobalKeyBoardHook
    {
        # region const value
        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;
        #endregion
        
        #region DLL imports
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        #endregion

        public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);

        // When hooked key pressed
        public event KeyEventHandler KeyDown;

        // When hooked key released
        public event KeyEventHandler KeyUp;

        public List<Keys> HookedKeys = new List<Keys>();
        IntPtr hhook = IntPtr.Zero;

        // CallbackOnCollectedDelegate 예외 처리를 위해서 생성함.
        keyboardHookProc handler;

        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }
        
        // constructor
        public GlobalKeyBoardHook()
        {
            HookedKeys.Add(Keys.F1);
            KeyDown += new KeyEventHandler(KeyDownEvent);
            hook();
        }

        public void KeyDownEvent(object sender, KeyEventArgs e)
        {
            e.Handled = false;
        }

        // destructor
        ~GlobalKeyBoardHook()
        {
            unhook();
        }
        
        // global hook install
        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");

            this.handler = new keyboardHookProc(hookProc); // 핸들러를 설정해주었고, 그걸 hookProc에 두번 일하게했음.
            // 이걸 파라미터 2번째에 넣음. 일을 두번한거지만 그렇게 됨으로 CallbackOnCollectedDelegate 예외를 처리해줄수있음.
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, this.handler, hInstance, 0); // 계속 참조값을 가지고 있기 때문에 예외에 안걸릴 수 있음.
            MessageBox.Show("훅 걸림");
        }

        // global hook uninstall
        public void unhook()
        {
            UnhookWindowsHookEx(hhook);
            MessageBox.Show("훅 풀림");
        }

        public int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                Debug.Print(key.ToString());
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs eventKey = new KeyEventArgs(key);
                    if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        if (key == Keys.F1 || key == Keys.F2 || key == Keys.F3 || key == Keys.F4)
                        {
                            MessageBox.Show("Key Pressed :" + key.ToString());
                            KeyDown(this, eventKey);
                        }
                    }
                    else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                    {
                        //MessageBox.Show("방금 떼진건 " + key.ToString());
                        if (key == Keys.F1 || key == Keys.F3)
                            KeyUp(this, eventKey);
                    }
                    if (eventKey.Handled)
                        return (Int32)1; // return 1값을 주게 되면 해당키가 잠김
                }
            }
            return (Int32)0; // 1값도 아니고 CallNextHookEx 도 쓰지 않음. -> 이로써 그 프로세스에 키값을 보내지 않음.
            // return CallNextHookEx(hhook, code, wParam, ref lParam); -> 프로세스에도 메세지를 보냄.
        }
    }
}
