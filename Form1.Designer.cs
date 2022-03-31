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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hookButton = new System.Windows.Forms.Button();
            this.unHookButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.currentStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(389, 243);
            this.textBox1.TabIndex = 0;
            // 
            // hookButton
            // 
            this.hookButton.Location = new System.Drawing.Point(12, 269);
            this.hookButton.Name = "hookButton";
            this.hookButton.Size = new System.Drawing.Size(80, 31);
            this.hookButton.TabIndex = 1;
            this.hookButton.Text = "hook";
            this.hookButton.UseVisualStyleBackColor = true;
            this.hookButton.Click += new System.EventHandler(this.HookButtonClick);
            // 
            // unHookButton
            // 
            this.unHookButton.Location = new System.Drawing.Point(114, 269);
            this.unHookButton.Name = "unHookButton";
            this.unHookButton.Size = new System.Drawing.Size(80, 31);
            this.unHookButton.TabIndex = 2;
            this.unHookButton.Text = "unHook";
            this.unHookButton.UseVisualStyleBackColor = true;
            this.unHookButton.Click += new System.EventHandler(this.UnHookButtonClick);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(217, 279);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(119, 18);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Current Status :";
            // 
            // currentStatus
            // 
            this.currentStatus.BackColor = System.Drawing.SystemColors.Control;
            this.currentStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentStatus.Location = new System.Drawing.Point(329, 279);
            this.currentStatus.Name = "currentStatus";
            this.currentStatus.Size = new System.Drawing.Size(60, 18);
            this.currentStatus.TabIndex = 4;
            this.currentStatus.Text = "None";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 323);
            this.Controls.Add(this.currentStatus);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.unHookButton);
            this.Controls.Add(this.hookButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button hookButton;
        private System.Windows.Forms.Button unHookButton;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox currentStatus;
    }
}

