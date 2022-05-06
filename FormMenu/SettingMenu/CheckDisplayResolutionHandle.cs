using lazy_manager.Display;
using lazy_manager.Model;
using System;
using System.Windows.Forms;

namespace lazy_manager.FormMenu.SettingMenu
{
    class CheckDisplayResolutionHandle : IDisposable
    {
        public void Dispose() {}

        // 화면 해상도 배율 메시지 박스
        public void CheckDisplayResolutionShow()
        {
            DisplayResolutionModel displayResolutionModel = DisplayResolutionModel.Instance(); // singleton pattern

            if (!displayResolutionModel.isDisplayResolution)
                DisplayResolution.SetDisplayResolution(); // setting display resolution
            MessageBox.Show("해상도 배율 :" + displayResolutionModel.displayScale.ToString());
        }

    }
}
