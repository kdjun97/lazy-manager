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
        MouseEvent mouseEvent = new MouseEvent();

        /// <summary>
        /// 핫키 모델의 특수 명령들을 처리해줌 ex)k,m,s,q
        /// </summary>
        /// <param name="hotkeyModel">셋팅된 핫키 모델</param>
        public async void HotkeyCommandHandle(HotkeyModel hotkeyModel)
        {            
            try
            {
                Debug.Print(hotkeyModel.GetHotkey().ToString() + "시작지점");
                // TODO: 여기를 while로 감싸서 r 특수명령 구현하기
                foreach (Tuple<char, string> command in hotkeyModel.GetCommand())
                {
                    switch (command.Item1) {
                        case 'k': // keybd_event
                            keyboardEvent.KeyboardEventHandle(command.Item2);
                            break;
                        case 'm': // mouse_event
                            mouseEvent.MouseEventHandle(command.Item2);
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
                Debug.Print(hotkeyModel.GetHotkey().ToString() + "끝지점");
            }
            catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }

        }
    }
}
