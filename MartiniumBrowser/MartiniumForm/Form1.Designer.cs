using System.IO;
using System.Net.Http;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace MartiniumForm
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.webContents = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(Screen.FromControl(this.tabControl1).Bounds.Width, Screen.FromControl(this.tabControl1).Bounds.Height);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Tab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(Screen.FromControl(this.tabPage1).Bounds.Width, 50);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.button5);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(7, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(967, 38);
            this.panel4.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(882, 7);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "DevTools";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(827, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = ">>";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(794, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(27, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "<<";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(759, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(74, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(629, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter URL: ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.vScrollBar1);
            this.panel1.Controls.Add(this.hScrollBar2);
            this.panel1.Controls.Add(this.webContents);
            this.panel1.Location = new System.Drawing.Point(0, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(Screen.FromControl(this.tabControl1).Bounds.Width, Screen.FromControl(this.tabControl1).Bounds.Height - 170);
            this.panel1.TabIndex = 0;
            //
            // webcontents
            //
            this.webContents.BackColor = System.Drawing.Color.Transparent;
            this.webContents.Location = new System.Drawing.Point(0, 0);
            this.webContents.Size = new System.Drawing.Size(Screen.FromControl(this.tabControl1).Bounds.Width - 40, Screen.FromControl(this.tabControl1).Bounds.Height - 120);
            this.webContents.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(Screen.FromControl(this.tabControl1).Bounds.Width - 200, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, Screen.FromControl(this.tabControl1).Bounds.Height - 190);
            this.panel5.TabIndex = 3;
            this.panel5.Visible = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 25);
            this.panel6.TabIndex = 0;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(Screen.FromControl(this.tabControl1).Bounds.Width - 28, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(20, Screen.FromControl(this.tabControl1).Bounds.Height - 190);
            this.vScrollBar1.TabIndex = 2;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(0, Screen.FromControl(this.tabControl1).Bounds.Height - 190);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(Screen.FromControl(this.tabControl1).Bounds.Width - 28, 20);
            this.hScrollBar2.TabIndex = 0;
            // 
            // hScrollBar1
            // 
            //this.hScrollBar1.Location = new System.Drawing.Point(0, Screen.FromControl(this.tabControl1).Bounds.Height - 170);
            //this.hScrollBar1.Name = "hScrollBar1";
            //this.hScrollBar1.Size = new System.Drawing.Size(Screen.FromControl(this.tabControl1).Bounds.Width, 14);
            //this.hScrollBar1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 623);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(985, 623);
            this.panel2.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height - 80);
            this.Location = new Point(0, 0);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Martinium - LIMO Development";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void loader()
        {
            this.button2.Click += new System.EventHandler((object s, System.EventArgs e) =>
            {
                if (this.textBox1.Text != null)
                {
                    if (this.textBox1.Text.Contains(".") && !this.textBox1.Text.Contains(" "))
                    {
                        this.webContents.Controls.Clear();
                        this.tabPage1.Text = "New Tab";
                        this.topIndex = 0;
                        ParseCHTML("https://" + this.textBox1.Text);
                    }
                    else if (this.textBox1.Text == "mart://chtmltest")
                    {
                        this.webContents.Controls.Clear();
                        this.tabPage1.Text = "New Tab";
                        this.topIndex = 0;
                        ParseCHTML("https://limodevelopmentcom.ferder.repl.co/chtml/test");
                    }
                    else if (this.textBox1.Text == "mart://limodev")
                    {
                        this.webContents.Controls.Clear();
                        this.tabPage1.Text = "New Tab";
                        this.topIndex = 0;
                        ParseCHTML("https://limodevelopmentcom.ferder.repl.co");
                    }
                }
            });

            this.button5.Click += new System.EventHandler((object s, System.EventArgs e) =>
            {
                switch (this.isShown)
                {
                    case true:
                        this.panel5.Visible = false;
                        this.vScrollBar1.Location = new System.Drawing.Point(Screen.FromControl(this.tabControl1).Bounds.Width - 28, 0);
                        this.hScrollBar2.Size = new System.Drawing.Size(Screen.FromControl(this.tabControl1).Bounds.Width - 28, 20);
                        this.isShown = false;
                        break;

                    case false:
                        this.panel5.Visible = true;
                        this.vScrollBar1.Location = new System.Drawing.Point(Screen.FromControl(this.tabControl1).Bounds.Width - 220, 0);
                        this.hScrollBar2.Size = new System.Drawing.Size(Screen.FromControl(this.tabControl1).Bounds.Width - 220, 20);
                        this.isShown = true;
                        break;
                }
            });
        }

        private void ParseCHTML(string url)
        {
            HttpClient web = new HttpClient();
            StringReader sr = new StringReader(web.GetStringAsync(url).Result.ToString().ToLower());
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                switch (line.StartsWith("<title>"))
                {
                    case true:
                        this.tabPage1.Text = line.Replace("<title>", "").Replace("</title>", "");
                        break;

                    case false:
                        switch (line.StartsWith("<h"))
                        {
                            case true:
                                switch (line.StartsWith("<h>"))
                                {
                                    case true:
                                        HeaderLabel label = new HeaderLabel(line.Replace("<h>", "").Replace("</h>", ""));
                                        label.Location = new System.Drawing.Point(0, this.topIndex);
                                        label.AutoSize = true;
                                        label.TabIndex = 2;
                                        this.webContents.Controls.Add(label);
                                        topIndex += 30;
                                        break;

                                    case false:
                                        break;
                                }
                                break;

                            case false:
                                switch (line.StartsWith("<about>")) 
                                {
                                    case true:
                                        AboutSection label2 = new AboutSection(line.Replace("<about>", "").Replace("</about>", ""));
                                        label2.Location = new System.Drawing.Point(0, this.topIndex);
                                        label2.AutoSize = true;
                                        label2.TabIndex = 2;
                                        this.webContents.Controls.Add(label2);
                                        topIndex += 30;
                                        break;

                                    case false:
                                        switch (line.StartsWith("<cimg src=\""))
                                        {
                                            case true:
                                                System.Windows.Forms.Label label3 = new System.Windows.Forms.Label();
                                                break;

                                            case false:
                                                switch (line.StartsWith("<cbtn>"))
                                                {
                                                    case true:
                                                        CButton button = new CButton(line.Replace("<cbtn>", "").Replace("</cbtn>", ""));
                                                        button.Location = new System.Drawing.Point(0, this.topIndex);
                                                        button.AutoSize = true;
                                                        this.webContents.Controls.Add(button);
                                                        topIndex += 30;
                                                        break;

                                                    case false:
                                                        break;
                                                }
                                                break;
                                        }
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }

        private void CreateFiles()
        {
            string dir = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Martinium", dir2 = dir + "\\themes", file = dir2 + "\\main.martiniumtheme";
            switch (!Directory.Exists(dir))
            {
                case true:
                    Directory.CreateDirectory(dir);
                    break;

                case false:
                    switch (!Directory.Exists(dir2)) 
                    {
                        case true:
                            Directory.CreateDirectory(dir2);
                            break;

                        case false:
                            switch (!File.Exists(file))
                            {
                                case true:
                                    File.Create(file);
                                    break;

                                case false:
                                    this.ParseTheme(file);
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }

        private void ParseTheme(string file)
        {
            foreach (string line in File.ReadAllLines(file))
            {
                switch (line.StartsWith("header-background:") && line.EndsWith(";"))
                {
                    case true:
                        string color = line.Replace("header-background:", "").Replace(";", "");
                        switch (color.StartsWith("argb(") && color.EndsWith(")"))
                        {
                            case false:
                                switch (color)
                                {
                                    case "red":
                                        this.panel3.BackColor = Color.Red;
                                        break;

                                    case "orange":
                                        this.panel3.BackColor = Color.Orange;
                                        break;

                                    case "yellow":
                                        this.panel3.BackColor = Color.Yellow;
                                        break;

                                    case "lime":
                                        this.panel3.BackColor = Color.Lime;
                                        break;

                                    case "lightblue":
                                        this.panel3.BackColor = Color.LightBlue;
                                        break;

                                    case "blue":
                                        this.panel3.BackColor = Color.Blue;
                                        break;

                                    case "magenta":
                                        this.panel3.BackColor = Color.Magenta;
                                        break;
                                }
                                break;
                        }
                        break;

                    case false:
                        switch (line.StartsWith("background-img:"))
                        {
                            case true:
                                string img = line.Replace("background-img:", "").Replace(";", "");
                                this.tabControl1.CreateGraphics().FillPolygon(Brushes.Green, new PointF[] { new PointF(0, 0), new PointF(25, 25)});
                                break;

                            case false:
                                switch (line.StartsWith("theme:"))
                                {
                                    case true:
                                        string theme = line.Replace("theme:", "").Replace(";", "");
                                        switch (theme)
                                        {
                                            case "light":
                                                this.panel1.BackColor = Color.White;
                                                break;

                                            case "dark":
                                                this.panel1.BackColor = Color.Gray;
                                                break;
                                        }
                                        break;

                                    case false:
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel webContents;
        private int topIndex = 0;
        private int[] maxelems = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };

        /* events */
        private static string[] ConscriptEvents = new string[] { CLICK, HOVER, APPENDTEXT, APPENDCHILD, CREATELEMENT };

        // click event
        private static string CLICK = "click";

        // hover event
        private static string HOVER = "hover";

        // append-text event
        private static string APPENDTEXT = "appendtext";

        // append-child event
        private static string APPENDCHILD = "appendchild";

        // create-element event
        private static string CREATELEMENT = "createelement";

        private bool isShown = false;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private Button button5;
        private Panel panel5;
        private Panel panel6;
    }
}

