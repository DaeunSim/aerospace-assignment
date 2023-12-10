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
    public partial class CustomForm : Form
    {
        public bool SetBorderLine { get; set; }

        public CustomForm()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // This is for RouteForm's border line.
            // New features to customize color, width, and style are needed.
            if (this.SetBorderLine)
            {
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle
                    , Color.LightSlateGray, 3, ButtonBorderStyle.Solid
                    , Color.LightSlateGray, 3, ButtonBorderStyle.Solid
                    , Color.LightSlateGray, 3, ButtonBorderStyle.Solid
                    , Color.LightSlateGray, 3, ButtonBorderStyle.Solid);
            }
        }
    }
}
