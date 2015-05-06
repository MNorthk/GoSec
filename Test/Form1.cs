using Bll;
using studentModle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            GetLoginPsw p = GetLoginPsw.GetLoginPswClass(textBox1.Text.Trim(), textBox2.Text.Trim());
            StudentInfo student = p.getInfo();

            if(student==null)
            {
                MessageBox.Show("f");
            }
            else
            {
                MessageBox.Show(student.Id);
            }
        }
    }
}
