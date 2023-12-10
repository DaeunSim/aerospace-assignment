using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTest
{
    public partial class InitUserControl : CustomUserControl
    {
        public InitUserControl()
        {
            InitializeComponent();
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            if (this.ParentForm is MainForm form)
            {
                form.ChangeToMainUserControl();
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            // Load a configured route file
            // Change to the main user control
            // Send loaded data
            if (this.ParentForm is MainForm form)
            {
                form.ChangeToMainUserControl();
            }
        }
    }
}
