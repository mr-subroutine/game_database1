namespace GameDatabase1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 20);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "--",
            "3D Realms",
            "Accolade",
            "AM1 Team",
            "AM2 Team",
            "AM3 Team",
            "AM4 Team",
            "Arc System Works",
            "Artoon",
            "ATLUS",
            "Bandai-Namco",
            "Beat Games",
            "Bethesda",
            "BioWare",
            "Bird Studio",
            "Bizarre Creations",
            "Blizzard Entertainment",
            "Bullfrog ",
            "Bungie",
            "Capcom",
            "Climax Studios",
            "Creative Assembly",
            "CryTek",
            "Digital Anil",
            "Disney",
            "Disney Interactive",
            "DotEmu",
            "Double Fine",
            "DSI",
            "Electronic Arts",
            "Epic Games",
            "Evolution Studios",
            "Firaxis",
            "FromSoftware",
            "Hal Laboratory",
            "Hudson",
            "HudsonSoft",
            "ID Software",
            "Infinity Ward",
            "Insomniac Games",
            "InXile",
            "IO Interactive",
            "Iron Galaxy",
            "Kemco",
            "Koei",
            "Kojima Productions",
            "Level 5",
            "Lionhead Studios",
            "Looking Glass Studios",
            "LucasArts",
            "Maxis",
            "Monolith",
            "Monolith Productions",
            "N/A",
            "Namco",
            "NEC",
            "Nintendo",
            "Origin",
            "RARE",
            "Redwood Studios",
            "Retro Studios",
            "Santa Monica Studios",
            "Sonic Team",
            "Sony Imagesoft",
            "Sony San Diego",
            "Square-Enix",
            "Sucker Punch Productions",
            "Team Dakota",
            "Treyarch",
            "Turn10",
            "Ubisoft",
            "Ubisoft France",
            "Ubisoft Montreal",
            "Ubisoft Shanghai",
            "Unknown",
            "Unspecified",
            "Warner Bros.",
            "Zipper Interactive"});
            this.comboBox1.Location = new System.Drawing.Point(29, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(263, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(29, 68);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(263, 21);
            this.comboBox2.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(29, 95);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(263, 21);
            this.comboBox3.TabIndex = 3;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(29, 122);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(263, 21);
            this.comboBox4.TabIndex = 4;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.IntegralHeight = false;
            this.comboBox5.ItemHeight = 13;
            this.comboBox5.Location = new System.Drawing.Point(29, 149);
            this.comboBox5.MaxLength = 4;
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(89, 21);
            this.comboBox5.TabIndex = 5;
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(263, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add to Library";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(29, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(263, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(328, 332);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Entry";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}