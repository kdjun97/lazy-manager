using System;

namespace lazy_manager.FormMenu.InfoMenu
{
    class VirtualKeyCodeShowHandle : IDisposable
    {
        public void Dispose() {}

        public void VirtualKeyCodeShow()
        {
            VirtualKeyCodeForm virtualKeyCodeForm = new VirtualKeyCodeForm();
            virtualKeyCodeForm.Show();
        }
    }
}
