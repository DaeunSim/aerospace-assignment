namespace HomeTest
{
    partial class MainUserControl
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
            this.craftLbl = new System.Windows.Forms.Label();
            this.craftCbx = new System.Windows.Forms.ComboBox();
            this.routeLbx = new System.Windows.Forms.ListBox();
            this.routeGbx = new System.Windows.Forms.GroupBox();
            this.destBtn = new System.Windows.Forms.Button();
            this.paxGbx = new System.Windows.Forms.GroupBox();
            this.numBtn = new System.Windows.Forms.Button();
            this.upBtn = new System.Windows.Forms.Button();
            this.downBtn = new System.Windows.Forms.Button();
            this.craftGbx = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.routeGbx.SuspendLayout();
            this.paxGbx.SuspendLayout();
            this.craftGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // craftLbl
            // 
            this.craftLbl.AutoSize = true;
            this.craftLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.craftLbl.Location = new System.Drawing.Point(15, 15);
            this.craftLbl.Name = "craftLbl";
            this.craftLbl.Size = new System.Drawing.Size(0, 13);
            this.craftLbl.TabIndex = 1;
            // 
            // craftCbx
            // 
            this.craftCbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.craftCbx.FormattingEnabled = true;
            this.craftCbx.Location = new System.Drawing.Point(7, 19);
            this.craftCbx.Name = "craftCbx";
            this.craftCbx.Size = new System.Drawing.Size(233, 24);
            this.craftCbx.TabIndex = 2;
            // 
            // routeLbx
            // 
            this.routeLbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.routeLbx.FormattingEnabled = true;
            this.routeLbx.Location = new System.Drawing.Point(9, 54);
            this.routeLbx.Name = "routeLbx";
            this.routeLbx.Size = new System.Drawing.Size(228, 104);
            this.routeLbx.TabIndex = 6;
            // 
            // routeGbx
            // 
            this.routeGbx.Controls.Add(this.destBtn);
            this.routeGbx.Controls.Add(this.routeLbx);
            this.routeGbx.Location = new System.Drawing.Point(15, 154);
            this.routeGbx.Name = "routeGbx";
            this.routeGbx.Size = new System.Drawing.Size(248, 172);
            this.routeGbx.TabIndex = 7;
            this.routeGbx.TabStop = false;
            this.routeGbx.Text = "ROUTE";
            // 
            // destBtn
            // 
            this.destBtn.Location = new System.Drawing.Point(6, 21);
            this.destBtn.Name = "destBtn";
            this.destBtn.Size = new System.Drawing.Size(233, 25);
            this.destBtn.TabIndex = 7;
            this.destBtn.Text = "Select Destinations";
            this.destBtn.UseVisualStyleBackColor = true;
            // 
            // paxGbx
            // 
            this.paxGbx.Controls.Add(this.numBtn);
            this.paxGbx.Controls.Add(this.upBtn);
            this.paxGbx.Controls.Add(this.downBtn);
            this.paxGbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paxGbx.Location = new System.Drawing.Point(15, 84);
            this.paxGbx.Name = "paxGbx";
            this.paxGbx.Size = new System.Drawing.Size(248, 56);
            this.paxGbx.TabIndex = 8;
            this.paxGbx.TabStop = false;
            this.paxGbx.Text = "PASSENGERS";
            // 
            // numBtn
            // 
            this.numBtn.Enabled = false;
            this.numBtn.FlatAppearance.BorderSize = 0;
            this.numBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numBtn.Location = new System.Drawing.Point(88, 20);
            this.numBtn.Name = "numBtn";
            this.numBtn.Size = new System.Drawing.Size(70, 25);
            this.numBtn.TabIndex = 12;
            this.numBtn.Text = "0";
            this.numBtn.UseVisualStyleBackColor = true;
            // 
            // upBtn
            // 
            this.upBtn.Location = new System.Drawing.Point(165, 20);
            this.upBtn.Name = "upBtn";
            this.upBtn.Size = new System.Drawing.Size(75, 25);
            this.upBtn.TabIndex = 2;
            this.upBtn.Text = "+";
            this.upBtn.UseVisualStyleBackColor = true;
            // 
            // downBtn
            // 
            this.downBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downBtn.Location = new System.Drawing.Point(6, 20);
            this.downBtn.Name = "downBtn";
            this.downBtn.Size = new System.Drawing.Size(75, 25);
            this.downBtn.TabIndex = 1;
            this.downBtn.Text = "-";
            this.downBtn.UseVisualStyleBackColor = true;
            // 
            // craftGbx
            // 
            this.craftGbx.Controls.Add(this.craftCbx);
            this.craftGbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.craftGbx.Location = new System.Drawing.Point(15, 15);
            this.craftGbx.Name = "craftGbx";
            this.craftGbx.Size = new System.Drawing.Size(248, 56);
            this.craftGbx.TabIndex = 9;
            this.craftGbx.TabStop = false;
            this.craftGbx.Text = "SPACECRAFT";
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(194, 341);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(70, 25);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "SAVE";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(116, 341);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(70, 25);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // MainUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.craftGbx);
            this.Controls.Add(this.paxGbx);
            this.Controls.Add(this.routeGbx);
            this.Controls.Add(this.craftLbl);
            this.Name = "MainUserControl";
            this.Size = new System.Drawing.Size(280, 380);
            this.routeGbx.ResumeLayout(false);
            this.paxGbx.ResumeLayout(false);
            this.craftGbx.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label craftLbl;
        private System.Windows.Forms.ComboBox craftCbx;
        private System.Windows.Forms.ListBox routeLbx;
        private System.Windows.Forms.GroupBox routeGbx;
        private System.Windows.Forms.Button destBtn;
        private System.Windows.Forms.GroupBox paxGbx;
        private System.Windows.Forms.Button upBtn;
        private System.Windows.Forms.Button downBtn;
        private System.Windows.Forms.GroupBox craftGbx;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button numBtn;
    }
}
