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
    public partial class Form2 : Form
    {
        public delegate void SetValueDelegate(string value);
        public SetValueDelegate SetValueCallback;

        public Form2(Form1 form1)
        {
            InitializeComponent();

            this.SetValueCallback += new SetValueDelegate(form1.SetValueFunction);
        }

        public void SetValueFunction(string value)
        {
            textBox2.Text = value;
        }

        private void btnSendToForm1_Click(object sender, EventArgs e)
        {
            SetValueCallback(textBox1.Text);
        }
    }
}
