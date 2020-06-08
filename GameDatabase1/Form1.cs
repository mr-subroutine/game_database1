using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
// written by: Darryl

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
                // copy loaded file to gamelist file the program accepts
                File.Delete(fileLocation);
                File.Copy(Form3.filePath, fileLocation);
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
            Form3 startUpBox = new Form3();
            DialogResult r = startUpBox.ShowDialog();

            if (r == DialogResult.OK)
            {
                // checks if file exists after selecting create new, confirmation for a destructive action
                if (File.Exists(fileLocation))
                {
                    DialogResult dialogResult = MessageBox.Show("Use Current Database? YES | New File? NO?",
                        "Yes or No", MessageBoxButtons.YesNo);

                    // YES - Loads current file for new additions
                    if (dialogResult == DialogResult.Yes)
                    {
                        readFile();
                    }

                    // NO - create new file 
                    else if (dialogResult == DialogResult.No)
                    {
                        appCreatedFile = true;
                        setFileLocation(appCreatedFile);
                        createFile();
                    }
                }

                else if (!File.Exists(fileLocation))
                {
                    appCreatedFile = true;
                    setFileLocation(appCreatedFile);
                    createFile();
                }
            }

            if (r == DialogResult.Yes)
            {
                appCreatedFile = false;
                setFileLocation(appCreatedFile);
                readFile();
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
                writeObjToFile(Game.gameTitle, Game.gameDeveloper, Game.gamePublisher, Game.platformName, Game.releaseYear);
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
                    if (item.Text == null || item.Text == "")
                    {
                        // breaks out if loop if null or empty line.  If not it will continue and fill the listview with blank lines
                        break;
                    }
                    item.SubItems.Add(read.ReadLine());
                    item.SubItems.Add(read.ReadLine());
                    item.SubItems.Add(read.ReadLine());
                    item.SubItems.Add(read.ReadLine());
                    listView1.Items.Add(item);
                }
                read.Close();
            }
        }

        private void writeObjToFile(string gTitle, string gDev, string gPublish, string gPlat, string gYear)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string[] lines = System.IO.File.ReadAllLines(@fileLocation);

            foreach (ListViewItem listItem in listView1.SelectedItems)
            {
                // stores list view item in a string
                string lineforDel = listItem.Text;
                // deletes the specified list view item
                listView1.Items.Remove(listItem);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lineforDel == lines[i])
                    {
                        lines[i] = "";
                        lines[i + 1] = "";
                        lines[i + 2] = "";
                        lines[i + 3] = "";
                        lines[i + 4] = "";
                    }
                }
                //  clear list-view display
                listView1.Items.Clear();

                // text file needs formatting before being put back into listview
                reformatTextFile(lines);
            }
        }

        private void reformatTextFile(string[] lines)
        {
            // This method is used to reformat before being sent to readFile method.  Needs to get rid of empty string lines.
            // deleting old data file
            File.Delete(fileLocation);

            // Write the newly adjusted array to a file, minus empty string items
            using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(fileLocation, true))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] != "")
                    {
                        file.WriteLine(lines[i]);
                    }
                }
            }
            // call readFile to read the new text file made in this method
            readFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

