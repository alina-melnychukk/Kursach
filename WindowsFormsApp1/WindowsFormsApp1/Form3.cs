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
    public partial class Form3 : Form
    {
        public string login;
        public string password;
        private string repeatedPassword;
        SerializationUtil serializationUtil = new SerializationUtil();

        public Form3()
        {
            InitializeComponent();
            InitializeTextboxControl();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(password != repeatedPassword)
            {
                MessageBox.Show("Паролі не збігаються!");
            }
            else
            {
                User user = new User(login, password, 0);
                Users users = serializationUtil.DeserializeXML();
                foreach(User item in users.UserList)
                {
                    if (login == item.Name)
                    {
                        MessageBox.Show("Користувач з таким логіном вже зареєстрований!");
                        Form1 newForm1 = new Form1(login, password);
                        this.Hide();
                        newForm1.ShowDialog();
                    }
                }
                
                users.UserList.Add(user);  
                serializationUtil.SerializeXML(users);
                Form4 fm4 = new Form4();
                fm4.calories = "Загалом спалених калорій: 0";
                fm4.name = login.ToString();
                this.Hide();
                fm4.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            login = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text;
        }

        private void InitializeTextboxControl()
        {
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 14;
            textBox3.PasswordChar = '*';
            textBox3.MaxLength = 14;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            repeatedPassword = textBox3.Text;
        }
        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
