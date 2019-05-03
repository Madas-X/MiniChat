using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniChitHatChat
{
    public partial class Form2 : Form
    {
        String clear = "";
        String[] registerData = {"Nickname","Password","Repeat password","e-mail"};
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(registerData[0]))
            {
                textBox1.Text = clear;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(clear))
            {
                textBox1.Text = registerData[0];
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(registerData[1]))
            {
                textBox2.Text = clear;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(clear))
            {
                textBox2.Text = registerData[1];
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(registerData[2]))
            {
                textBox3.Text = clear;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(clear))
            {
                textBox3.Text = registerData[2];
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(registerData[3]))
            {
                textBox4.Text = clear;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(clear))
            {
                textBox4.Text = registerData[3];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new Form1();
            newForm.Show();
            Hide();
        }
    }
}
