using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
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

        VirtualKeyModel virtualKeyModel = new VirtualKeyModel();

        public async void KeyboardEventHandle(HotkeyModel hotkeyModel)
        {
            try
            {
                foreach(Tuple<char, string> command in hotkeyModel.GetCommand())
                {
                    Debug.Print(command.ToString());
                    switch (command.Item1) {
                        case 'k':
                            if (command.Item2[0] == 'D') // KEY DOWN
                            {
                                // TODO: Map<string, byte> 를 가지고 hard coding 후, 
                                // command 배열 들어오는걸 mapping시켜 배열을 다시 만듦
                                Debug.Print("Target:" + command.Item2.Substring(1));
                                virtualKeyModel.GetVirtualKeyModel().ContainsKey(command.Item2.Substring(1));
                                keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Item2.Substring(1)], 0, 0x00, (UIntPtr)0);
                            }
                            else if (command.Item2[0] == 'U') // KEY UP
                            {
                                virtualKeyModel.GetVirtualKeyModel().ContainsKey(command.Item2.Substring(1));
                                keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Item2.Substring(1)], 0, 0x02, (UIntPtr)0);
                            }
                            break;
                        case 's':
                            await Task.Delay(int.Parse(command.Item2));
                            //Thread.Sleep(int.Parse(command.Item2));
                            break;
                        case 'q':
                            break;
                        default:
                            throw new Exception("지금 단계에선 구현x");
                    }
                    
                }
                Debug.Print("");
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
        }


    }
}
