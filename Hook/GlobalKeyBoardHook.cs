using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using lazy_manager.Model;
using lazy_manager.Command;
using lazy_manager.Enums;
using lazy_manager.Struct;

namespace lazy_manager.hook
{
    /// <summary>
    /// Global Keyboard Hooking class
    /// </summary>
    class GlobalKeyBoardHook
    {   
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

        // 핫키 모델이 들어갈 모델
        List<HotkeyModel> hotkeyModel;

        // 명령어를 처리하기 위한 constructor
        CommandHandle commandHandle = new CommandHandle();

        // When hooked key pressed
        public event KeyEventHandler KeyDown;

        // When hooked key released
        public event KeyEventHandler KeyUp;

        // 후킹된 키가 들어갈 list
        public List<Keys> HookedKeys = new List<Keys>();
        public IntPtr hhook = IntPtr.Zero;

        // constructor
        public GlobalKeyBoardHook()
        {

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
        public void hook(List<Keys> hookedKeys, List<HotkeyModel> hotkeyModel)
        {
            if (callbackDelegate != null)
                callbackDelegate = null; // only one hook

            this.hotkeyModel = hotkeyModel;
            HookedKeys = hookedKeys;
            KeyDown += new KeyEventHandler(KeyDownEvent);
            KeyUp += new KeyEventHandler(KeyUpEvent);

            IntPtr hInstance = LoadLibrary("User32");
            callbackDelegate = new keyboardHookProc(hookProc);
            hhook = SetWindowsHookEx((int)HookEnum.WH_KEYBOARD_LL, callbackDelegate, hInstance, 0);

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
                if (HookedKeys.Contains(key))
                {
                    KeyEventArgs eventKey = new KeyEventArgs(key);
                    if ((wParam == (int)HookEnum.WM_KEYDOWN || wParam == (int)HookEnum.WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        Debug.Print("["+ key.ToString() + "]키가 눌렸습니다");
                        
                        KeyDown(this, eventKey);
                        commandHandle.HotkeyCommandHandle(hotkeyModel[HookedKeys.IndexOf(key)]);
                    }
                    else if ((wParam == (int)HookEnum.WM_KEYUP || wParam == (int)HookEnum.WM_SYSKEYUP) && (KeyUp != null))
                    {
                        KeyUp(this, eventKey);
                    }
                    if (eventKey.Handled)
                        return 1; // return 1값을 주게 되면 해당키가 잠김
                }
            }
            return CallNextHookEx(hhook, code, wParam, ref lParam); // -> 프로세스에도 메세지를 보냄.
        }
    }
}
