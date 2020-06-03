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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.Columns.Add("Game Title", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Publisher", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Platform", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Release Year", 100, HorizontalAlignment.Left);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGame();
        }

        private void addGame()
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    ListViewItem x = new ListViewItem();
            //    x.Text = "test";
            //    x.SubItems.Add(i.ToString());
            //    listView1.Items.Add(x);
            //}

            Game game = new Game();
            Form2 frm2 = new Form2();

            frm2.ShowDialog();

            bool isEmpty = false;

            while (isEmpty == false)
            {
                game.GameTitle = Microsoft.VisualBasic.Interaction.InputBox("Please Type in Full Game Title", "Enter Name of Game");
                isEmpty = checkForEmpty(game.GameTitle);
                if (isEmpty == true)
                {
                    break;
                }
                string developerName = Microsoft.VisualBasic.Interaction.InputBox("Please type in Full Game Developer", "Enter Name of the Developer");
                isEmpty = checkForEmpty(developerName);
                if (isEmpty == true)
                {
                    break;
                }

                string publisherName = Microsoft.VisualBasic.Interaction.InputBox("Please type in Full Game Publisher", "Enter Name of the Developer");
                isEmpty = checkForEmpty(publisherName);
                if (isEmpty == true)
                {
                    break;
                }

                string platformName = Microsoft.VisualBasic.Interaction.InputBox("Please type in Full Game Publisher", "Enter Name of the Developer");
                isEmpty = checkForEmpty(platformName);
                if (isEmpty == true)
                {
                    break;
                }

            }

            MessageBox.Show("Left while loop.");
            string releaseYear = Microsoft.VisualBasic.Interaction.InputBox("Please Enter Year", "Enter Year of Release (Ex. 1999");
        }

        private bool checkForEmpty (string entry)
        {
            bool isEmpty = false;
            if (entry == "")
            {
                isEmpty = true;
                return isEmpty;
            }

            return isEmpty = false;
        }
    }
}
