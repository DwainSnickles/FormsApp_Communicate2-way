using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp_Communicate2_way
{
    public partial class Form1 : Form
    {
        public delegate void SetValueDelegate(string value);
        public SetValueDelegate SetValueCallback;

        public Form1()
        {
            InitializeComponent();

            //this will allow form 1 to pass variable to form 2
            Form2 frm = new Form2(this);
            frm.Show();
            this.SetValueCallback += new SetValueDelegate(frm.SetValueFunction);
            //frm.SetDesktopLocation(this.Location.X + this.Size.Width, this.Location.Y + Size.Height);
            frm.Left = this.Right + SystemInformation.BorderSize.Width + frm.Width;
        }

        public void SetValueFunction(string value)
        {
            textBox2.Text = value;
        }

        private void btnSendToForm2_Click(object sender, EventArgs e)
        {
            SetValueCallback(textBox1.Text);
        }
    }
}
