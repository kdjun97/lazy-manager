using System.Drawing;
using lazy_manager.Model;

namespace lazy_manager.Position
{
    /// <summary>
    /// 마우스의 좌표 관련 클래스
    /// </summary>
    class MousePosition
    {
        DisplayResolutionModel displayResolutionModel = DisplayResolutionModel.Instance();

        /// <summary>
        /// 마우스 x,y좌표를 얻는 함수
        /// </summary>
        /// <returns></returns>
        public Size GetMousePosition(string command)
        {
            string[] commandSubstring = command.Split(',');

            int x = int.Parse(commandSubstring[0].Substring(3));
            int y = int.Parse(commandSubstring[1].Substring(0, commandSubstring[1].Length - 1));

            int mouseX = (65535 * x / displayResolutionModel.displaySize.Width);
            int mouseY = (65535 * y / displayResolutionModel.displaySize.Height);

            return new Size(mouseX, mouseY);
        }
    }
}
