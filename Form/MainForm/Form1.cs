﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using lazy_manager.hook;
using System.IO;
using lazy_manager.Model;
using lazy_manager.Script;
using lazy_manager.Display;
using System.Drawing;

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

        // New File
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editBox.Text.Length != 0)
                SaveFile(true);
            editBox.Text = "";
        }

        // Load Event
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        // Load File
        private void LoadFile()
        {
            try
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = ".ini|*.ini|.txt|*.txt|All|*.*";
                openFileDialog1.ShowDialog();
                string fileData = File.ReadAllText(openFileDialog1.FileName);
                editBox.Text = fileData;
            } catch (FileNotFoundException eMsg) // 파일 선택 없이 나갈때
            {
                Debug.Print(eMsg.Message);
            } catch (ArgumentException eMsg) // 빈 경로일 때,
            {
                Debug.Print(eMsg.Message);
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
        }

        // Save Event
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
            /* 무조건 save as 기능만 넣음
            else
                SaveFile(false);
            */
        }

        // Save As File
        private void SaveFile(bool isSavingAs)
        {
            if (isSavingAs == true) // Save As
            {
                try
                {
                    saveFileDialog1.Filter = ".ini|*.ini|.txt|*.txt|All|*.*";
                    saveFileDialog1.ShowDialog();
                    File.WriteAllText(saveFileDialog1.FileName, editBox.Text);
                } catch (FileNotFoundException eMsg) // 파일 선택 없이 나갈때
                {
                    Debug.Print(eMsg.Message);
                } catch (ArgumentException eMsg) // 빈 경로일 때,
                {
                    Debug.Print(eMsg.Message);
                } catch (Exception eMsg)
                {
                    Debug.Print(eMsg.Message);
                }
                
            }
            else // Save (현재 파일명 동일)
            {
                File.WriteAllText(saveFileDialog1.FileName, editBox.Text);
            }
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Virtual Key Code
        private void virtualKeyCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VirtualKeyCodeForm virtualKeyCodeForm = new VirtualKeyCodeForm();
            virtualKeyCodeForm.Show();
            // 창 고정 필요함.
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
            if (!displayResolutionModel.isDisplayResolution)
                DisplayResolution.SetDisplayResolution(); // setting display resolution
            MessageBox.Show("해상도 배율 :" + displayResolutionModel.displayScale.ToString());
        }

        // History
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm();
            historyForm.Show();
        }

        // Usage
        private void usageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("사용법 구현중");
        }
    }
}