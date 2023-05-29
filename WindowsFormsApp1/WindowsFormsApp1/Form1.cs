using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public string login;
        public string password;
        SerializationUtil serializationUtil = new SerializationUtil();
        public Form1()
        {
            InitializeComponent();
            InitializeTextboxControl();
        }
        public Form1(string login, string password)
        {
            InitializeComponent();
            InitializeTextboxControl();
            this.login = login;
            this.password = password;
            textBox1.Text = login;
            textBox2.Text = password;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            login = textBox1.Text;
        }

        private void InitializeTextboxControl()
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users users = serializationUtil.DeserializeXML();
            if (login != null)
            {
                foreach (User user in users.UserList)
                { 
                    if (login == user.Name)
                    {
                        if (password == user.Password)
                        {
                            Form4 fm4 = new Form4();
                            fm4.calories = "Загалом спалених калорій: " + Math.Round(user.Calories).ToString();
                            fm4.name = login.ToString();
                            this.Hide();
                            fm4.ShowDialog();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Ви ввели невірний пароль!");
                            this.textBox2.Text = null;
                            Form1 newForm1 = new Form1(login, password);
                            this.Hide();
                            newForm1.ShowDialog();
                        }
                    }
                }
                this.Hide();
                Form2 messageBox = new Form2();
                messageBox.ShowDialog();
            }
            else
            {
                MessageBox.Show("Поле логіну не може бути пустим!");
                Form1 newForm = new Form1(login, password);
                this.Hide();
                newForm.ShowDialog();
            }
        }
    }
}
