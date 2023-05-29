using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        int steps; float weight; float length;
        SerializationUtil serializationUtil = new SerializationUtil();
        public string name{
            get{ return label5.Text;}
            set{ label5.Text = value ;}
        }
        public string calories
        {
            get { return label4.Text; }
            set { label4.Text = value; }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result1 = int.TryParse(textBox1.Text, out steps);
            if (!result1)
            {
                MessageBox.Show("Потрібно ввести число!");
            }
            else if (steps < 0)
            {
                MessageBox.Show("Кількість кроків не може бути від'ємною!");
            }
            bool result2 = float.TryParse(textBox2.Text, out weight);
            if (!result2)
            {
                MessageBox.Show("Потрібно ввести число!");
            }
            else if (weight <= 0)
            {
                MessageBox.Show("Ваша вага не може бути від'ємною!");
            }
            bool result3 = float.TryParse(textBox3.Text, out length);
            if (!result3)
            {
                MessageBox.Show("Потрібно ввести число!");
            }
            else if (length <= 0)
            {
                MessageBox.Show("Довжина кроку не може бути від'ємною!");
            }
            double kkal = 1.15 * steps * weight * length / 100000;
            double roundedCalories = Math.Round(kkal, 2);
            textBox4.Text =roundedCalories.ToString();
            Users users = serializationUtil.DeserializeXML();
            foreach (User item in users.UserList)
            {
                if(name == item.Name)
                {
                    item.Calories += roundedCalories;
                    label4.Text = $"Загалом спалених калорій: {item.Calories}";
                }
            }
            serializationUtil.SerializeXML(users);
        }

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
