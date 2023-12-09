namespace HomeTest
{
    partial class InitUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initLbl = new System.Windows.Forms.Label();
            this.newBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // initLbl
            // 
            this.initLbl.AutoSize = true;
            this.initLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initLbl.Location = new System.Drawing.Point(13, 50);
            this.initLbl.Name = "initLbl";
            this.initLbl.Size = new System.Drawing.Size(296, 13);
            this.initLbl.TabIndex = 0;
            this.initLbl.Text = "Would you like to create a new route or load an existing one?";
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(66, 98);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(190, 30);
            this.newBtn.TabIndex = 1;
            this.newBtn.Text = "NEW";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(66, 134);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(190, 30);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "LOAD";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // InitUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.initLbl);
            this.Name = "InitUserControl";
            this.Size = new System.Drawing.Size(320, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label initLbl;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button loadBtn;
    }
}
