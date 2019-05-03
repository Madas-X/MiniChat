using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MiniChitHatChat
{
    public partial class Form3 : Form
    {
        public Form3(string user_nickname)
        {
            InitializeComponent();
            label2.Text = user_nickname;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private string getDate(string datetime)
        {

           // DateTime GETdate = DateTime.Today;
            string data = "00";
            if (datetime == "date")
            {
                data = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else if (datetime == "time")
            {
                data = DateTime.Now.ToString("HH:mm:ss");
            }
            return data;
        }
        private string Str_from_Sql(MySqlCommand SqlCommand)
        {
            string data = "x";
            string ConnectionMySQL_login = "datasource=127.0.0.1;port=3306;username=root;password=;database=minichat;";
            using (MySqlConnection databaseConnection_login = new MySqlConnection(ConnectionMySQL_login))
            {
                databaseConnection_login.Open();
                MySqlDataReader userIdRead = SqlCommand.ExecuteReader();
                try
                {
                    while (userIdRead.Read())
                    {
                        data = String.Format("{0}", userIdRead[0]);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    userIdRead.Close();
                }
            }
            return data;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string ConnectionMySQL_login = "datasource=127.0.0.1;port=3306;username=root;password=;database=minichat;";
            using (MySqlConnection databaseConnection_login = new MySqlConnection(ConnectionMySQL_login))
            {
                string userID = @"select minichat.users.user_id from minichat.users where minichat.users.user_nickname='" + label2.Text + "';";
                MySqlCommand SqlCommand = new MySqlCommand(userID, databaseConnection_login);
                databaseConnection_login.Open();
                string user_id = Str_from_Sql(SqlCommand);
                string todayDate = getDate("date");
                string hour = getDate("time");
                if (e.KeyCode == Keys.Enter)
                {
                    string sendMSG = @"INSERT INTO `messages` (`message_id`, `user_id`, `reciver_id`, `message_date`, `message_time`, `message`) VALUES (NULL, '"+user_id+"', NULL, '"+todayDate+"', '"+ hour + "', '"+textBox1.Text+"');";
                    MySqlCommand sendMSG_db = new MySqlCommand(sendMSG, databaseConnection_login);
                    var s = sendMSG_db.ExecuteNonQuery();
                    listBox1.Items.Clear();
                    print_messages();
                    textBox1.Text = "";
                    
                }
            }
        }
        

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }
        private void print_messages() {
            string ConnectionMySQL_login = "datasource=127.0.0.1;port=3306;username=root;password=;database=minichat;";
            using (MySqlConnection databaseConnection_login = new MySqlConnection(ConnectionMySQL_login))
            {
                // string messagers_from_db = @"select minichat.users.user_nickname, minichat.messages.message, minichat.messages.message_date, minichat.messages.message_time from minichat.users INNER JOIN users ON messeges.user_id = users.user_id;";
                string messagers_from_db = @"SELECT messages.message, messages.message_time,messages.message_date,users.user_nickname from messages INNER JOIN users ON messages.user_id = users.user_id ORDER BY messages.message_date,messages.message_time;";
                MySqlCommand getMSG_db = new MySqlCommand(messagers_from_db, databaseConnection_login);
                MySqlDataAdapter SqlDataAdapter = new MySqlDataAdapter(messagers_from_db, databaseConnection_login);
                DataSet SqlDataSet = new DataSet();
                using (DataTable SqlDataTable = new DataTable())
                {
                    SqlDataAdapter.Fill(SqlDataTable);
                    string[][] db_data = new string[4][];
                    int x = 0;
                    try
                    {
                        foreach (DataRow DR in SqlDataTable.Rows)
                        {

                            listBox1.Items.Add(DR["user_nickname"].ToString() + ": " + DR["message"].ToString());
                            listBox1.Items.Add("");
                        }
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Clear();
                        listBox1.Items.Add("Error!");
                    }
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            print_messages();
        }
    }
}
