using System;
using System.Windows.Forms;

namespace lazy_manager
{
    public partial class VirtualKeyCodeForm : Form
    {
        public VirtualKeyCodeForm()
        {
            InitializeComponent();
        }

        private void VirtualKeyCodeForm_Load(object sender, EventArgs e)
        {

        }

        // Virtual Key Code Form Close
        private void VirtualKeyCodeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
