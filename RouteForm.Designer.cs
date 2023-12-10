namespace HomeTest
{
    partial class RouteForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteForm));
            this.saveBtn = new System.Windows.Forms.Button();
            this.mainGbx = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectedLbx = new System.Windows.Forms.ListBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.destLbx = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(279, 278);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(70, 25);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "SAVE";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // mainGbx
            // 
            this.mainGbx.BackColor = System.Drawing.SystemColors.Control;
            this.mainGbx.Controls.Add(this.label2);
            this.mainGbx.Controls.Add(this.selectedLbx);
            this.mainGbx.Controls.Add(this.deleteBtn);
            this.mainGbx.Controls.Add(this.addBtn);
            this.mainGbx.Controls.Add(this.destLbx);
            this.mainGbx.Controls.Add(this.label1);
            this.mainGbx.Location = new System.Drawing.Point(12, 13);
            this.mainGbx.Name = "mainGbx";
            this.mainGbx.Size = new System.Drawing.Size(336, 255);
            this.mainGbx.TabIndex = 15;
            this.mainGbx.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "PLANETS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectedLbx
            // 
            this.selectedLbx.FormattingEnabled = true;
            this.selectedLbx.Location = new System.Drawing.Point(209, 32);
            this.selectedLbx.Name = "selectedLbx";
            this.selectedLbx.Size = new System.Drawing.Size(119, 212);
            this.selectedLbx.TabIndex = 18;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(132, 127);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(70, 25);
            this.deleteBtn.TabIndex = 17;
            this.deleteBtn.Text = "DELETE";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(132, 96);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(70, 25);
            this.addBtn.TabIndex = 16;
            this.addBtn.Text = "ADD";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // destLbx
            // 
            this.destLbx.FormattingEnabled = true;
            this.destLbx.Location = new System.Drawing.Point(7, 32);
            this.destLbx.Name = "destLbx";
            this.destLbx.Size = new System.Drawing.Size(119, 212);
            this.destLbx.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECTED\r\nDESTINATIONS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(201, 278);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(70, 25);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // RouteForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(360, 320);
            this.Controls.Add(this.mainGbx);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RouteForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RouteForm";
            this.Load += new System.EventHandler(this.RouteForm_Load);
            this.mainGbx.ResumeLayout(false);
            this.mainGbx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.GroupBox mainGbx;
        private System.Windows.Forms.ListBox destLbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ListBox selectedLbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip;
    }
}