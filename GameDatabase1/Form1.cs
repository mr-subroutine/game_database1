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

        static bool appCreatedFile = false;
        static string StartupPath;
        static string fileLocation = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            // sets up columns for list view programatically.
            listView1.Clear();
            listView1.Columns.Add("Title", 230, HorizontalAlignment.Left);
            listView1.Columns.Add("Developer", 215, HorizontalAlignment.Left);
            listView1.Columns.Add("Publisher", 215, HorizontalAlignment.Left);
            listView1.Columns.Add("Platform", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Release Year", 80, HorizontalAlignment.Left);

            // needs to set initial file location for opening dialog to check if it exists
            StartupPath = Application.StartupPath;
            fileLocation = StartupPath + @"\game_list.txt";

            startUpDialog();
        }

        public static void setFileLocation(bool appCreatedFile)
        {
            // sets the location that the application will use
            if (appCreatedFile == false)
            {
                // user file location needed here
            }

            else if (appCreatedFile == true)
            {
                StartupPath = Application.StartupPath;
                fileLocation = StartupPath + @"\game_list.txt";
            }
        }

        public static void createFile()
        {
            File.Create(fileLocation).Close();
        }

        private void startUpDialog()
        {
            appCreatedFile = false;
            Form3 startUpBox = new Form3();
            DialogResult r = startUpBox.ShowDialog();

            if (r == DialogResult.OK)
            {
                // checks if file exists after selecting create new, confirmation for a destructive action
                if (File.Exists(fileLocation))
                {
                    DialogResult dialogResult = MessageBox.Show("A database file already exists. Do you want to delete it and create a new one?",
                        "Yes or No", MessageBoxButtons.YesNo);

                    // YES - create new file and app creates new file
                    if (dialogResult == DialogResult.Yes)
                    {
                        appCreatedFile = true;
                        setFileLocation(appCreatedFile);
                        createFile();
                    }

                    // NO - loads the file already onhand, needs to check if one exists and if so creates a new one anyway.
                    else if (dialogResult == DialogResult.No)
                    {
                        readFile();
                    }
                }

                else if (!File.Exists(fileLocation))
                {
                    appCreatedFile = true;
                    setFileLocation(appCreatedFile);
                    createFile();
                }
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

                // Call to write the added game to file
                writeFile(Game.gameTitle, Game.gameDeveloper, Game.gamePublisher, Game.platformName, Game.releaseYear);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void readFile()
        {
            string[] dataArr = System.IO.File.ReadAllLines(@fileLocation);

            using (StreamReader read = new StreamReader(fileLocation))
            {
                // read line add to ListView

                for (int j = 0; j < dataArr.Length; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = read.ReadLine();
                    item.SubItems.Add(read.ReadLine());
                    item.SubItems.Add(read.ReadLine());
                    item.SubItems.Add(read.ReadLine());
                    item.SubItems.Add(read.ReadLine());
                    listView1.Items.Add(item);
                }
                read.Close();
            }
        }

        private void writeFile(string gTitle, string gDev, string gPublish, string gPlat, string gYear)
        {
            // Write this data to a file(append)
            using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(fileLocation, true))
            {
                file.WriteLine(gTitle);
                file.WriteLine(gDev);
                file.WriteLine(gPublish);
                file.WriteLine(gPlat);
                file.WriteLine(gYear);
            }
        }
    }
}
