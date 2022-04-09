using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using lazy_manager.Model;

namespace lazy_manager.Event
{
    class KeyboardEvent
    {
        #region DLLImport For Keyboard Event

        // bVk : 가상키코드, bScan : 하드웨어 스캔코드, dwFlags : 동작 지정 Flag, dwExtraInfo : 추가정보
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        #endregion

        #region const value
        const int KEY_DOWN = 0x00;
        const int KEY_UP = 0x02;
        #endregion 

        // for byte bVk (virtual key)
        VirtualKeyModel virtualKeyModel = new VirtualKeyModel();

        public void KeyboardEventHandle(string command)
        {
            try
            {
                Debug.Print(command.ToString());
                switch (command[0])
                {
                    case 'D': // KEY DOWN
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, KEY_DOWN, (UIntPtr)0);
                        break;
                    case 'U': // KEY UP
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, KEY_UP, (UIntPtr)0);
                        break;
                    case 'K': // KEY DOWN and KEY UP
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, KEY_DOWN, (UIntPtr)0);
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, KEY_UP, (UIntPtr)0);
                        break;
                }
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
        }
    }
}
