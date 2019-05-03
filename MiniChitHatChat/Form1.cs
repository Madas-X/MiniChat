using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace MiniChitHatChat
{
    public partial class Form1 : Form
    {
        private string user_nickname;
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        String clear = "";
        String[] registerData = { "Nickname", "Password" };
        public Form1()
        {
            InitializeComponent();
            connectionCheck();
            timer1.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  
            _start_point = new Point(e.X, e.Y);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
        //register
        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new Form2();
            newForm.Show();
            Hide();
        }
        //login
        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionMySQL_login = "datasource=127.0.0.1;port=3306;username=root;password=;database=minichat;";
            using (MySqlConnection databaseConnection_login = new MySqlConnection(ConnectionMySQL_login)) {
                string userData = @"select minichat.users.user_nickname, minichat.users.user_password from minichat.users where minichat.users.user_nickname='" + Convert.ToString(textBox1.Text) + "' AND minichat.users.user_password='" + Convert.ToString(textBox2.Text) + "';";
                MySqlCommand SqlCommand = new MySqlCommand(userData);
                MySqlDataAdapter SqlDataAdapter = new MySqlDataAdapter(userData, databaseConnection_login);
                DataSet SqlDataSet = new DataSet();
                using (DataTable SqlDataTable = new DataTable())
                {
                    SqlDataTable.Clear();
                    SqlDataAdapter.Fill(SqlDataTable);
                    if (SqlDataTable.Rows.Count > 0)
                    {
                        user_nickname = textBox1.Text;
                        var openAppForm = new Form3(user_nickname);
                        openAppForm.Show();
                        Hide();
                    }
                    else {
                        MessageBox.Show("Niepoprawne hasło lub login!");
                    }
                }
               
            }

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
        private void connectionCheck()
        {
            string ConnectionMySQL = "datasource=127.0.0.1;port=3306;username=root;password=;database=minichat;";
            MySqlConnection databaseConnection = new MySqlConnection(ConnectionMySQL);
            try{
                databaseConnection.Open();
                label5.Text = "O";
                label5.ForeColor = Color.Chartreuse;
            }
            catch(Exception ex){
                label5.Text = "X";
                label5.ForeColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            connectionCheck();
        }
    }
}
