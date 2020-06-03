using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GameDatabase1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected string[,] gameLibrary = new string[10000, 6];

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Columns.Add("Game Title", 225, HorizontalAlignment.Left);
            listView1.Columns.Add("Publisher", 225, HorizontalAlignment.Left);
            listView1.Columns.Add("Platform", 225, HorizontalAlignment.Left);
            listView1.Columns.Add("Release Year", 100, HorizontalAlignment.Left);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGame();
        }

        private void addGame()
        {
            Form2 frm2 = new Form2();
            DialogResult r = frm2.ShowDialog();

            if (r == DialogResult.OK)
            { 
                ListViewItem item = new ListViewItem();
                item.Text = Game.gameTitle;
                item.SubItems.Add(Game.gameDeveloper);
                item.SubItems.Add(Game.gamePublisher);
                item.SubItems.Add(Game.platformName);
                item.SubItems.Add(Game.releaseYear);
                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // WIP - Store data in array
        // WIP - Remove item from list and also array
        // WIP - Write to a file
        // WIP - Read file and fill ListView
    }
}
