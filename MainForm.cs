﻿using System;
using System.Drawing;
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

        public void ChangeToMainUserControl(bool selectedNewData = true, string file = null)
        {
            MainUserControl mainUC = new MainUserControl();
            mainUC.InitData();

            if (!selectedNewData && file != null) 
            {
                var result = mainUC.SetDataToControls(FileHandler.ReadDataFromTextFile(file));
                if (!result)
                {
                    MessageBox.Show("Failed to load the route file."
                        , "Error"
                        , MessageBoxButtons.OK
                        , MessageBoxIcon.Error);
                    return;
                }
            }

            this.Controls.Clear();
            this.Controls.Add(mainUC);
            this.Size = new Size(this.Width, 430);
            mainUC.Parent = this;
            mainUC.Location = new Point(20, 0);
            mainUC.Show();
        }
    }
}
