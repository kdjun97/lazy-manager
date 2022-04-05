using lazy_manager.Model;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;

namespace lazy_manager.Event
{
    class KeyboardEvent
    {
        #region DLLImport For Keyboard Event

        // bVk : 가상키코드, bScan : 하드웨어 스캔코드, dwFlags : 동작 지정 Flag, dwExtraInfo : 추가정보
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        #endregion

        public void KeyboardEventHandle(HotkeyModel hotkeyModel)
        {
            try
            {
                foreach(Tuple<char, string> command in hotkeyModel.GetCommand())
                {
                    switch (command.Item1) {
                        case 'k':
                            if (command.Item2[0] == 'D') // KEY DOWN

                                //keybd_event(byte(command.Item2), 0, 0x00, 0);

                            break;
                        case 's':
                            Thread.Sleep(int.Parse(command.Item2));
                            break;
                        case 'q':
                            break;
                        default:
                            throw new Exception("지금 단계에선 구현x");
                    }
                    Debug.Write("[" + command.Item1 + "]" + command.Item2);
                }
                Debug.Print("");
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
        }


    }
}
