namespace lazy_manager
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unhookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virtualKeyCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.editBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkDisplayResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kdjun97gmailcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.version01ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.제작자김동준ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.funcToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(413, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.loadFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.newFileToolStripMenuItem.Text = "New File";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.newFileToolStripMenuItem_Click);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.loadFileToolStripMenuItem.Text = "Load";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.saveToolStripMenuItem.Text = "Save As";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // funcToolStripMenuItem
            // 
            this.funcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readScriptToolStripMenuItem,
            this.unhookToolStripMenuItem});
            this.funcToolStripMenuItem.Name = "funcToolStripMenuItem";
            this.funcToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.funcToolStripMenuItem.Text = "Func";
            // 
            // readScriptToolStripMenuItem
            // 
            this.readScriptToolStripMenuItem.Name = "readScriptToolStripMenuItem";
            this.readScriptToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.readScriptToolStripMenuItem.Text = "Read Script";
            this.readScriptToolStripMenuItem.Click += new System.EventHandler(this.readScriptToolStripMenuItem_Click);
            // 
            // unhookToolStripMenuItem
            // 
            this.unhookToolStripMenuItem.Name = "unhookToolStripMenuItem";
            this.unhookToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.unhookToolStripMenuItem.Text = "unhook";
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingToolStripMenuItem,
            this.checkDisplayResolutionToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // ingToolStripMenuItem
            // 
            this.ingToolStripMenuItem.Name = "ingToolStripMenuItem";
            this.ingToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.ingToolStripMenuItem.Text = "~ing";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.virtualKeyCodeToolStripMenuItem,
            this.programInfoToolStripMenuItem,
            this.emailToToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(48, 24);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // programInfoToolStripMenuItem
            // 
            this.programInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.version01ToolStripMenuItem,
            this.제작자김동준ToolStripMenuItem});
            this.programInfoToolStripMenuItem.Name = "programInfoToolStripMenuItem";
            this.programInfoToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.programInfoToolStripMenuItem.Text = "Program Info";
            // 
            // virtualKeyCodeToolStripMenuItem
            // 
            this.virtualKeyCodeToolStripMenuItem.Name = "virtualKeyCodeToolStripMenuItem";
            this.virtualKeyCodeToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.virtualKeyCodeToolStripMenuItem.Text = "Virtual KeyCode";
            this.virtualKeyCodeToolStripMenuItem.Click += new System.EventHandler(this.virtualKeyCodeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(413, 25);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 20);
            this.toolStripStatusLabel1.Text = "Status :";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(46, 20);
            this.toolStripStatusLabel2.Text = "None";
            // 
            // editBox
            // 
            this.editBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBox.Location = new System.Drawing.Point(0, 28);
            this.editBox.Multiline = true;
            this.editBox.Name = "editBox";
            this.editBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.editBox.Size = new System.Drawing.Size(413, 323);
            this.editBox.TabIndex = 7;
            this.editBox.WordWrap = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(112, 20);
            this.toolStripStatusLabel3.Text = "제작자 : 김동준";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(143, 20);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "Version 0.1";
            // 
            // checkDisplayResolutionToolStripMenuItem
            // 
            this.checkDisplayResolutionToolStripMenuItem.Name = "checkDisplayResolutionToolStripMenuItem";
            this.checkDisplayResolutionToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.checkDisplayResolutionToolStripMenuItem.Text = "Check Display Resolution";
            // 
            // emailToToolStripMenuItem
            // 
            this.emailToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kdjun97gmailcomToolStripMenuItem});
            this.emailToToolStripMenuItem.Name = "emailToToolStripMenuItem";
            this.emailToToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.emailToToolStripMenuItem.Text = "Email to";
            // 
            // kdjun97gmailcomToolStripMenuItem
            // 
            this.kdjun97gmailcomToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.kdjun97gmailcomToolStripMenuItem.Name = "kdjun97gmailcomToolStripMenuItem";
            this.kdjun97gmailcomToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.kdjun97gmailcomToolStripMenuItem.Text = "kdjun97@gmail.com";
            // 
            // version01ToolStripMenuItem
            // 
            this.version01ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.version01ToolStripMenuItem.Name = "version01ToolStripMenuItem";
            this.version01ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.version01ToolStripMenuItem.Text = "Version 0.1";
            // 
            // 제작자김동준ToolStripMenuItem
            // 
            this.제작자김동준ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.제작자김동준ToolStripMenuItem.Name = "제작자김동준ToolStripMenuItem";
            this.제작자김동준ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.제작자김동준ToolStripMenuItem.Text = "제작자@김동준";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 376);
            this.Controls.Add(this.editBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Lazy Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unhookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem virtualKeyCodeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox editBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem readScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem checkDisplayResolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem version01ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 제작자김동준ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kdjun97gmailcomToolStripMenuItem;
    }
}

