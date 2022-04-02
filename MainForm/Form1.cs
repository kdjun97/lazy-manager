﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using lazy_manager.hook;
using System.IO;


namespace lazy_manager
{
    public partial class Form1 : Form
    {
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
                Debug.Print(eMsg.ToString());
            } catch (ArgumentException eMsg) // 빈 경로일 때,
            {
                Debug.Print(eMsg.ToString());
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
                    Debug.Print(eMsg.ToString());
                } catch (ArgumentException eMsg) // 빈 경로일 때,
                {
                    Debug.Print(eMsg.ToString());
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
            virtualKeyCodeForm.ShowDialog();
            // 창 고정 필요함.
        }

        // Read Script
        private void readScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Script.ReadScript readScript = new Script.ReadScript();
            List<Tuple<char, string>> list = readScript.ReadScriptLine(editBox.Text);
            Debug.Print(list.Count.ToString());
            for (int index = 0; index < list.Count(); index++)
                Debug.Print(list[index].Item1 + " " + list[index].Item2);
        }
    }
}