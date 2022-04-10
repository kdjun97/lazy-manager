using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using lazy_manager.Enums;
using lazy_manager.Display;

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

        DisplayResolution displayResolution = new DisplayResolution();
        
        
        /// <summary>
        /// 들어오는 파라미터 명령어에 따른 마우스 이벤트 날리는 함수
        /// </summary>
        /// <param name="command">mouse_event command (Ex: MouseMove, click)</param>
        public void MouseEventHandle(string command)
        {
            Debug.Print("x=" + displayResolution.GetDisplayResolution().Width + "y" + displayResolution.GetDisplayResolution().Height);
            try
            {
                // Display 해상도 값을 가져올 시, 배율 문제 (배율은 100%로 설정해야함)
                switch (command.Substring(0,2))
                {
                    case "MV": // Mouse Move
                        string[] commandSubstring = command.Split(',');

                        int x = int.Parse(commandSubstring[0].Substring(3));
                        int y = int.Parse(commandSubstring[1].Substring(0, commandSubstring[1].Length-1));
                        Debug.Print("x="+x+"y="+y);

                        Rectangle rtScreen = Screen.PrimaryScreen.Bounds;
                        int nX = (65535 * x / rtScreen.Width);
                        int nY = (65535 * y / rtScreen.Height);
                        mouse_event((uint)MouseEnum.ABSOLUTE | (uint)MouseEnum.MOUSEMOVE, nX, nY, 0, 0);

                        //mouse_event(ABSOLUTE | MOUSEMOVE, (65535 / 1920) * x, (65535 / 1080) * y, 0, 0);
                        break;
                    case "LC": // Mouse Left Click
                        //mouse_event(ABSOLUTE | MOVE | LEFTDOWN, (65535/1080) * 20, (65535/1024) * 20, 0, 0);
                        Debug.Print("LClick");
                        break;
                    case "RC": // Mouse Right Click
                        Debug.Print("Right Click");
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
