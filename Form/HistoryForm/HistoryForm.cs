using System.Windows.Forms;

namespace lazy_manager
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        // History Form Close
        private void HistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }
    }
}
