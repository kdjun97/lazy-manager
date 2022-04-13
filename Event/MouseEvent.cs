using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using lazy_manager.Enums;
using lazy_manager.Position;

namespace lazy_manager.Event
{
    /// <summary>
    /// Mouse Event 제어 클래스
    /// </summary>
    class MouseEvent
    {
        #region DllImport For Mouse Event

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, int dwExtaInfo);

        #endregion

        MousePosition mousePosition = new MousePosition();

        /// <summary>
        /// 들어오는 파라미터 명령어에 따른 마우스 이벤트 날리는 함수
        /// </summary>
        /// <param name="command">mouse_event command (Ex: MouseMove, click)</param>
        public void MouseEventHandle(string command)
        {
            try
            {
                switch (command.Substring(0,2))
                {
                    case "MV": // Mouse Move
                        Size mouseXY = mousePosition.GetMousePosition(command);
                        mouse_event((uint)MouseEnum.ABSOLUTE | (uint)MouseEnum.MOUSEMOVE, mouseXY.Width, mouseXY.Height, 0, 0);
                        break;
                    case "LC": // Mouse Left Click
                        mouse_event((uint)MouseEnum.ABSOLUTE | (uint)MouseEnum.LEFTDOWN, 0, 0, 0, 0);
                        mouse_event((uint)MouseEnum.ABSOLUTE | (uint)MouseEnum.LEFTUP, 0, 0, 0, 0);
                        break;
                    case "RC": // Mouse Right Click
                        mouse_event((uint)MouseEnum.ABSOLUTE | (uint)MouseEnum.RIGHTDOWN, 0, 0, 0, 0);
                        mouse_event((uint)MouseEnum.ABSOLUTE | (uint)MouseEnum.RIGHTUP, 0, 0, 0, 0);
                        break;
                    default: // Exception
                        throw new Exception("예외: 등록되지 않은 마우스 명령");

                }
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
        }
    }
}
