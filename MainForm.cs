using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeTest
{
    public partial class MainForm : CustomForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ChangeToInitUserControl();
        }

        public void ChangeToInitUserControl()
        {
            InitUserControl initUC = new InitUserControl();
            this.Controls.Clear();
            this.Controls.Add(initUC);
            this.Size = new Size(this.Width, 300);
            initUC.Parent = this;
            initUC.Location = new Point(0, 0);
            initUC.Show();
        }

        public void ChangeToMainUserControl()
        {
            MainUserControl mainUC = new MainUserControl();
            this.Controls.Clear();
            this.Controls.Add(mainUC);
            this.Size = new Size(this.Width, 430);
            mainUC.Parent = this;
            mainUC.Location = new Point(20, 0);
            mainUC.Show();
        }
    }
}
