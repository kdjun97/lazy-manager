using System;
using System.Windows.Forms;

namespace lazy_manager.FormMenu.InfoMenu
{
    class UsageHandle : IDisposable
    {
        public void Dispose() {}

        public void UsageShow()
        {
            MessageBox.Show("사용법 구현중");
        }
    }
}
