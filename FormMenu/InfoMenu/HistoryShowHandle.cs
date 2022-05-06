using System;

namespace lazy_manager.FormMenu.InfoMenu
{
    class HistoryShowHandle : IDisposable
    {
        public void Dispose() {} // dispose method 구현해야함

        public void HistoryShow()
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.Show();
        }
    }
}
