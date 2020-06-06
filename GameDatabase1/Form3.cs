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

namespace GameDatabase1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // this is needed to prevent start/create from not working.  
        bool startSelected = true;

        public static string filePath { get; set; } = "";


        private void button3_Click(object sender, EventArgs e)
        {
            // close all windows if this is canceled.
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                InitialDirectory = Application.StartupPath,
                Title = "Open text file"
            };

            DialogResult r = openFileDialog1.ShowDialog();

            if (DialogResult == DialogResult.Yes)
            {
                startSelected = false;
                try
                {
                    try
                    {
                        filePath = openFileDialog1.FileName;
                        using (Stream str = openFileDialog1.OpenFile())
                        {

                            filePath = openFileDialog1.FileName;
                            startSelected = true;
                        }
                    }
                    catch (FileNotFoundException)
                    {
                        MessageBox.Show("Please select a file to load.");
                    }
                }

                
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (startSelected == false)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startSelected = true;
        }
    }
}
