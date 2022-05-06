using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using lazy_manager.hook;
using lazy_manager.Model;
using lazy_manager.Script;
using lazy_manager.Display;
using System.Drawing;
using lazy_manager.FormMenu.FileMenu;
using lazy_manager.FormMenu.InfoMenu;
using lazy_manager.FormMenu.SettingMenu;

namespace lazy_manager
{
    public partial class Form1 : Form
    {
        GlobalKeyBoardHook globalKeyBoardHook = new GlobalKeyBoardHook();
        DisplayResolutionModel displayResolutionModel = DisplayResolutionModel.Instance(); // singleton pattern

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Form Close
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Close();
        }

        // New File
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewFileHandle newFileHandle = new NewFileHandle())
                newFileHandle.NewFile(true, saveFileDialog1, editBox);
        }

        // Load Event
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (LoadFileHandle loadFileHandle = new LoadFileHandle())
                loadFileHandle.LoadFile(openFileDialog1, editBox);
        }

        // Save Event
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 무조건 Save As 기능만 넣음
            using (SaveAsFileHandle saveAsFileHandle = new SaveAsFileHandle())
                saveAsFileHandle.SaveFile(true, saveFileDialog1, editBox);
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        // Virtual Key Code
        private void virtualKeyCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (VirtualKeyCodeShowHandle virtualKeyCodeShowHandle = new VirtualKeyCodeShowHandle())
                virtualKeyCodeShowHandle.VirtualKeyCodeShow();
        }

        // Read Script
        private void readScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!displayResolutionModel.isDisplayResolution)
                DisplayResolution.SetDisplayResolution(); // setting display resolution
            
            ReadScript readScript = new ReadScript();
            HotkeySetting hotkeySetting = new HotkeySetting();
            HotkeyModelListSetting hotkeyModelListSetting = new HotkeyModelListSetting();
            
            List<Tuple<char, string>> list = readScript.ReadScriptLine(editBox.Text);
            Debug.Print("----------readScript 끝-----------");

            List<HotkeyModel> hotkeyModel = hotkeyModelListSetting.SetHotkeyModelList(list);
            Debug.Print("Hotkey Model Length = " + hotkeyModel.Count());
            for (int i=0; i<hotkeyModel.Count(); i++)
            {
                Debug.Print("****" + (i + 1) + "번째 모델****");

                Debug.Print("핫키:"+hotkeyModel[i].GetHotkey() + ", 명령어 갯수:"+ hotkeyModel[i].GetCommand().Count());
                for (int j=0; j<hotkeyModel[i].GetCommand().Count(); j++)
                    Debug.Write("["+ hotkeyModel[i].GetCommand()[j].Item1.ToString() + "]" + hotkeyModel[i].GetCommand()[j].Item2.ToString() + " ");
                Debug.Print("");
            }

            Debug.Print("-----------hotkey model list setting 끝----------");

            List<Keys> hookedKeys = new List<Keys>();
            hookedKeys = hotkeySetting.SetHotkey(hotkeyModel);

            globalKeyBoardHook.hook(hookedKeys, hotkeyModel);

            if (globalKeyBoardHook.hhook != IntPtr.Zero)
            {
                toolStripStatusLabel2.Text = "Hooking";
                toolStripStatusLabel2.ForeColor = Color.Red;
            }

            Debug.Print(displayResolutionModel.displayScale.ToString());
            
        }

        // unhook
        private void unhookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            globalKeyBoardHook.unhook();
            toolStripStatusLabel2.Text = "None";
            toolStripStatusLabel2.ForeColor = Color.Black;
        }

        // Check Display Resolution
        private void checkDisplayResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CheckDisplayResolutionHandle checkDisplayResolutionHandle = new CheckDisplayResolutionHandle())
                checkDisplayResolutionHandle.CheckDisplayResolutionShow();
        }

        // History
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HistoryShowHandle historyShowHandle = new HistoryShowHandle())
                historyShowHandle.HistoryShow();
        }

        // Usage
        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UsageHandle usageHandle = new UsageHandle())
                usageHandle.UsageShow();
        }
    }
}