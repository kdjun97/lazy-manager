using System;
using System.Windows.Forms;

namespace lazy_manager.FormMenu.FileMenu
{
    class NewFileHandle : IDisposable
    {
        public void Dispose() {}

        // New File
        public void NewFile(bool isSavingAs, SaveFileDialog saveFileDialog1, TextBox editBox)
        {
            if (editBox.Text.Length != 0)
            {
                using (SaveAsFileHandle saveAsFileHandle = new SaveAsFileHandle())
                    saveAsFileHandle.SaveFile(true, saveFileDialog1, editBox);
            }
            editBox.Text = "";
            saveFileDialog1.Dispose();
        }
    }
}
