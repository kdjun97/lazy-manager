using lazy_manager.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using lazy_manager.Event;

namespace lazy_manager.Command
{
    class CommandHandle
    {
        KeyboardEvent keyboardEvent = new KeyboardEvent();

        /// <summary>
        /// 핫키의 명령어들을 핸들해줌.
        /// </summary>
        /// <param name="hotkeyModel"></param>
        public async void HotkeyCommandHandle(HotkeyModel hotkeyModel)
        {
            try
            {
                foreach (Tuple<char, string> command in hotkeyModel.GetCommand())
                {
                    switch (command.Item1) {
                        case 'k': // keybd_event
                            keyboardEvent.KeyboardEventHandle(command.Item2);
                            break;
                        case 'm': // mouse_event
                            break;
                        case 's': // sleep
                            await Task.Delay(int.Parse(command.Item2));
                            break;
                        case 'q': // 명령어의 끝
                            break;
                        default:
                            throw new Exception("예외: 등록되지 않은 명령어");
                    }
                }

            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }

        }
    }
}
