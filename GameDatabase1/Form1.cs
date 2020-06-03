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
            // sets up columns for list view programatically.
            listView1.Clear();
            listView1.Columns.Add("Title", 230, HorizontalAlignment.Left);
            listView1.Columns.Add("Developer", 215, HorizontalAlignment.Left);
            listView1.Columns.Add("Publisher", 215, HorizontalAlignment.Left);
            listView1.Columns.Add("Platform", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Release Year", 100, HorizontalAlignment.Left);

            // disables form until user makes decision from opening dialog
            listView1.Enabled = false;

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            // opens dialog that allows user to choose new or load
            startUpDialog();
        }

        private void startUpDialog()
        {
            Form3 startUpBox = new Form3();
            DialogResult r = startUpBox.ShowDialog();

            if (r == DialogResult.OK)
            {
                listView1.Enabled = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGame();
        }

        private void addGame()
        {
            Form2 frm2 = new Form2();
            DialogResult r = frm2.ShowDialog();

            // if this returns properly it will write all object data
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

        public void writeDatatoFile()
        {
            string StartupPath = Application.StartupPath;
            string fileLocation = StartupPath + @"\game_list.txt";

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(fileLocation, true))
            {
                file.WriteLine(Game.gameTitle);
                file.WriteLine(Game.gameDeveloper);
                file.WriteLine(Game.gamePublisher);
                file.WriteLine(Game.platformName);
                file.WriteLine(Game.releaseYear);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            writeDatatoFile();
        }

        // WIP - Store data in array

        // WIP - Remove item from list and also array
        // WIP - Write to a file
        // WIP - Read file and fill ListView
    }
}
