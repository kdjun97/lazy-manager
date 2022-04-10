using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using lazy_manager.Model;
using lazy_manager.Enums;

namespace lazy_manager.Event
{
    /// <summary>
    /// 키보드 이벤트 관련 클래스
    /// </summary>
    class KeyboardEvent
    {
        #region DLLImport For Keyboard Event
        /// <summary>
        /// keybd_event 날려주는 함수
        /// </summary>
        /// <param name="bVk">가상키코드</param>
        /// <param name="bScan">하드웨어 스캔코드</param>
        /// <param name="dwFlags">동작 지정 Flag</param>
        /// <param name="dwExtraInfo">추가정보</param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        #endregion
        

        // for byte bVk (virtual key)
        VirtualKeyModel virtualKeyModel = new VirtualKeyModel();

        /// <summary>
        /// 들어오는 command param에 대한 처리 후, keybd_event를 날려주는 함수
        /// </summary>
        /// <param name="command">D30같은 명령어</param>
        public void KeyboardEventHandle(string command)
        {
            try
            {
                Debug.Print(command.ToString());
                switch (command[0])
                {
                    case 'D': // KEY DOWN
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, (int)KeyboardEnum.KEY_DOWN, (UIntPtr)0);
                        break;
                    case 'U': // KEY UP
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, (int)KeyboardEnum.KEY_UP, (UIntPtr)0);
                        break;
                    case 'K': // KEY DOWN and KEY UP
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, (int)KeyboardEnum.KEY_DOWN, (UIntPtr)0);
                        keybd_event(virtualKeyModel.GetVirtualKeyModel()[command.Substring(1)], 0, (int)KeyboardEnum.KEY_UP, (UIntPtr)0);
                        break;
                    default:
                        throw new Exception("예외: 등록되지 않은 키보드 명령");
                }
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
        }
    }
}
