using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace lazy_manager.FormMenu.FileMenu
{
    class SaveAsFileHandle : IDisposable
    {
        public void Dispose(){} // interface method 구현

        // Save As File
        public void SaveFile(bool isSavingAs, SaveFileDialog saveFileDialog1, TextBox editBox)
        {
            if (isSavingAs == true) // Save As
            {
                try
                {
                    saveFileDialog1.Filter = ".ini|*.ini|.txt|*.txt|All|*.*";
                    saveFileDialog1.ShowDialog();
                    File.WriteAllText(saveFileDialog1.FileName, editBox.Text);
                }
                catch (FileNotFoundException eMsg) // 파일 선택 없이 나갈때
                {
                    Debug.Print(eMsg.Message);
                }
                catch (ArgumentException eMsg) // 빈 경로일 때,
                {
                    Debug.Print(eMsg.Message);
                }
                catch (Exception eMsg)
                {
                    Debug.Print(eMsg.Message);
                }
            }
            else // Save (현재 파일명 동일)
            {
                File.WriteAllText(saveFileDialog1.FileName, editBox.Text);
            }
            saveFileDialog1.Dispose();
        }
    }
}
