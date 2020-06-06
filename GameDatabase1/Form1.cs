﻿using System;
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

// WIP - Work on line 110 reading the loaded file from form 3
// WIP - Work on properties for dialog box to make it return to StartUp path instead of recent.

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
