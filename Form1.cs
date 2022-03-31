using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void UnHookButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("UnHook Button Clicked");
        }
    }
}
