using lazy_manager.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using lazy_manager.Event;

namespace lazy_manager.Command
{
    /// <summary>
    /// 각 핫키들의 command를 처리해주는 클래스
    /// </summary>
    class CommandHandle
    {
        KeyboardEvent keyboardEvent = new KeyboardEvent();

        /// <summary>
        /// 핫키 모델의 특수 명령들을 처리해줌 ex)k,m,s,q
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
