using System;
using System.IO;
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
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    string app = Application.StartupPath;
                    string dir = Path.Combine(app, "Route");
                    if (!FileHandler.CheckDirectoryExists(dir))
                        throw new Exception("There is no saved file.");

                    openFileDialog.InitialDirectory = dir;
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string file = openFileDialog.FileName;
                        if (!FileHandler.CheckFileExists(file))
                            throw new Exception("Selected file does not exist.");

                        if (this.ParentForm is MainForm form)
                        {
                            form.ChangeToMainUserControl(false, file);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Cannot load the travel route.\n" +
                    ex.Message
                    , "Error"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }
        }
    }
}
