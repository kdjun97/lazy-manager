using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace lazy_manager.FormMenu.FileMenu
{
    class LoadFileHandle : IDisposable // IDisposable interface
    {
        // Dispose 메소드 구현
        public void Dispose(){}

        // Load File
        public void LoadFile(OpenFileDialog openFileDialog1, TextBox editBox)
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = ".ini|*.ini|.txt|*.txt|All|*.*";
                openFileDialog1.ShowDialog();
                string fileData = File.ReadAllText(openFileDialog1.FileName);
                editBox.Text = fileData;
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
            finally
            {
                openFileDialog1.Dispose();
            }
        }
    }
}