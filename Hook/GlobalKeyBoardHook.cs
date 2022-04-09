using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using lazy_manager.Model;
using lazy_manager.Command;

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
        private static keyboardHookProc callbackDelegate;

        List<HotkeyModel> hotkeyModel;

        // 명령어를 처리하기 위한 constructor
        CommandHandle commandHandle = new CommandHandle();

        // When hooked key pressed
        public event KeyEventHandler KeyDown;

        // When hooked key released
        public event KeyEventHandler KeyUp;

        public List<Keys> HookedKeys = new List<Keys>();
        IntPtr hhook = IntPtr.Zero;

        // CallbackOnCollectedDelegate 예외 처리를 위해서 생성함.
        // keyboardHookProc handler;

        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        // constructor
        public GlobalKeyBoardHook(List<Keys> hookedKeys, List<HotkeyModel> hotkeyModel)
        {
            this.hotkeyModel = hotkeyModel;
            HookedKeys = hookedKeys;
            KeyDown += new KeyEventHandler(KeyDownEvent);
            KeyUp += new KeyEventHandler(KeyUpEvent);

            hook();
        }

        public void KeyDownEvent(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        public void KeyUpEvent(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        // destructor
        ~GlobalKeyBoardHook()
        {
            unhook();
        }
        
        // global hook install
        public void hook()
        {
            if (callbackDelegate != null)
                callbackDelegate = null; // only one hook

            IntPtr hInstance = LoadLibrary("User32");
            callbackDelegate = new keyboardHookProc(hookProc);
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, callbackDelegate, hInstance, 0);
            if (hhook == IntPtr.Zero)
                throw new Exception();
           
            MessageBox.Show("훅 걸림");
        }

        // global hook uninstall
        public void unhook()
        {
            if (callbackDelegate == null)
                return;

            if (!UnhookWindowsHookEx(hhook))
                throw new Exception("unhook exception");
            callbackDelegate = null;
            MessageBox.Show("훅 풀림");
        }

        public int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                //Debug.Print(key.ToString());
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs eventKey = new KeyEventArgs(key);
                    if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        Debug.Print("["+ key.ToString() + "]키가 눌렸습니다");

                        Debug.Print("Index:" + HookedKeys.IndexOf(key));
                        
                        KeyDown(this, eventKey);
                        commandHandle.HotkeyCommandHandle(hotkeyModel[HookedKeys.IndexOf(key)]);
                        //keyboardEvent.KeyboardEventHandle(hotkeyModel[HookedKeys.IndexOf(key)]);
                        //MessageBox.Show("Key Pressed :" + key.ToString());
                    }
                    else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                    {
                        //MessageBox.Show("방금 떼진건 " + key.ToString());
                        KeyUp(this, eventKey);
                    }
                    if (eventKey.Handled)
                        return 1; // return 1값을 주게 되면 해당키가 잠김
                }
            }
            // return 0; // 1값도 아니고 CallNextHookEx 도 쓰지 않음. -> 이로써 그 프로세스에 키값을 보내지 않음.
            return CallNextHookEx(hhook, code, wParam, ref lParam); // -> 프로세스에도 메세지를 보냄.
        }
    }
}
