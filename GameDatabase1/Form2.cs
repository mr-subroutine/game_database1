using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDatabase1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox5.Items.Add("--");
            for (int i = 1970; i < 2099; i++)
            {
                comboBox5.Items.Add(i);
            }
            comboBox5.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game.gameTitle = textBox1.Text;
            Game.gameDeveloper = comboBox1.Text;
            Game.gamePublisher = comboBox2.Text;
            Game.platformName = comboBox3.Text;
            Game.releaseYear = comboBox5.Text;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Game.gameTitle == "" || Game.gameDeveloper == "" || Game.gamePublisher == "" || Game.platformName == ""
                || Game.releaseYear == "--")
            {
                MessageBox.Show("Please make sure all fields are filled in.");
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }
    }
}
