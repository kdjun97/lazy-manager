using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lazy_manager.hook;

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

        // hook button
        private void HookButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hook Button Clicked");
            new GlobalKeyBoardHook();
        }

        private void UnHookButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("UnHook Button Clicked");
        }

        // New File
        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO 
            // 1. editBox의 길이가 0이 아니라면
            // 2. 경고 문구
            // 3. 그 후 (혹은 길이가 0이면)
            // 4. editBox.Text 초기화
            if (editBox.Text.Length != 0)
            {

            }
            editBox.Text = "";
        }

        // Load File
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            // 1. 유저가 경로 설정
            // 2. 경로의 파일을 읽음
            // 3. editBox에 적용
        }

        // Save File
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            // 1. 유저가 경로 지정
            // 2. file name 입력받음
            // 3. 저장
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO
            // 1. 프로그램 종료
        }
    }
}
