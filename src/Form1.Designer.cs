using System.Windows.Forms;
using HtmlAgilityPack;
using MetroFramework;
using MetroFramework.Controls;

namespace src;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        // tabs
        tabs.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height - 85);

        // tab1
        tab1.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height - 85);
        tab1.Text = "New Tab";

        // tab2
        tab2.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height - 85);
        tab2.Text = "New Tab";

        // add-tab
        addtab.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height - 85);
        addtab.Text = "+";

        // navbar
        navbar.Location = new System.Drawing.Point(0, 0);
        navbar.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, 35);
        navbar.Text = "New Tab";
        navbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
        navbar.BackColor = System.Drawing.Color.OrangeRed;

        // bookmarks button
        bmbtn.Location = new System.Drawing.Point(5, 5);
        bmbtn.Size = new System.Drawing.Size(75, 25);
        bmbtn.Text = "Bookmarks";
        bmbtn.BackColor = System.Drawing.Color.White;
        bmbtn.FlatStyle = FlatStyle.Flat;
        bmbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;

        // adressbar
        adressbar.Location = new System.Drawing.Point(85, 5);
        adressbar.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width - 280, 25);
        adressbar.BorderStyle = System.Windows.Forms.BorderStyle.None;

        // go-to-url button
        gtubtn.Location = new System.Drawing.Point(Screen.FromControl(this).Bounds.Width - 191, 5);
        gtubtn.Size = new System.Drawing.Size(50, 25);
        gtubtn.Text = "Go";
        gtubtn.BackColor = System.Drawing.Color.White;
        gtubtn.FlatStyle = FlatStyle.Flat;
        gtubtn.FlatAppearance.BorderColor = System.Drawing.Color.White;

        // sidebar
        sidebar.Location = new System.Drawing.Point(0, 35);
        sidebar.Size = new System.Drawing.Size(35, Screen.FromControl(this).Bounds.Height - 120);
        sidebar.BackColor = System.Drawing.Color.OrangeRed;

        // webcontents
        webcontents.Location = new System.Drawing.Point(35, 35);
        webcontents.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width - 35, Screen.FromControl(this).Bounds.Height - 85);
        webcontents.BackColor = System.Drawing.Color.Aquamarine;
        webcontents.AutoScroll = true;

        // tab adders
        tab1.Controls.Add(navbar);
        tab1.Controls.Add(sidebar);
        tab1.Controls.Add(webcontents);
        navbar.Controls.Add(bmbtn);
        navbar.Controls.Add(adressbar);
        navbar.Controls.Add(gtubtn);
        tabs.Controls.Add(tab1);
        tabs.Controls.Add(tab2);
        tabs.Controls.Add(addtab);

        // main stuff
        this.Controls.Add(tabs);
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.WindowState = FormWindowState.Maximized;
        this.Text = "Martinium";

        // url load functionality
        gtubtn.Click += new System.EventHandler((object s, System.EventArgs e) => {
            if (adressbar.Text != null) 
            {
                if (!adressbar.Text.StartsWith("https://") && adressbar.Text.Contains(".") && !adressbar.Text.Contains(" ")) 
                {
                    tab1.Text = "New Tab";
                    topindex = 0;
                    webcontents.Controls.Clear();
                    LoadCHTML("https://" + adressbar.Text);
                }
                else if (adressbar.Text == "mart://chtmltest")
                {
                    tab1.Text = "New Tab";
                    topindex = 0;
                    webcontents.Controls.Clear();
                    try {
                        LoadCHTML("https://limodevelopmentcom.ferder.repl.co/chtml/test");
                    } 
                    catch (Exception e1) 
                    {
                        Console.WriteLine("Error: " + e1);
                    }
                }
            }
        });
    }

    private void LoadCHTML(string url) {
        HtmlWeb web = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = web.Load(url);
        HtmlNode dn = doc.DocumentNode;
        string title = dn.SelectSingleNode("//title").InnerText;
        foreach (HtmlNode h in dn.SelectNodes("//h")) {
            Label label = new Label();
            label.Location = new System.Drawing.Point(0, topindex);
            label.Text = h.InnerText;
            label.Font = new System.Drawing.Font("Sans-Serif", 35);
            label.AutoSize = true;
            topindex += 40;
            webcontents.Controls.Add(label);
        }
        foreach (HtmlNode p in dn.SelectNodes("//p"))
        {
            Label label = new Label();
            label.Location = new System.Drawing.Point(0, topindex);
            label.Text = p.InnerText;
            label.Font = new System.Drawing.Font("Sans-Serif", 30);
            label.AutoSize = true;
            topindex += 35;
            webcontents.Controls.Add(label);
        }
        foreach (HtmlNode item in dn.SelectNodes("//cdiv"))
        {
            Panel div = new Panel();
            div.Location = new System.Drawing.Point(0, topindex);
            div.BackColor = System.Drawing.Color.Blue;
            int innertopindex = 0;
            foreach (HtmlNode h in dn.SelectNodes("//cdiv/h"))
            {
                Label label = new Label();
                label.Location = new System.Drawing.Point(0, innertopindex);
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("Sans-Serif", 35);
                label.Text = h.InnerText;
                innertopindex += 40;
                div.Controls.Add(label);
            }
            foreach (HtmlNode p in dn.SelectNodes("//cdiv/p"))
            {

            }
            div.AutoSize = true;
            webcontents.Controls.Add(div);
        }
        tab1.Text = title;
    }

    private MetroTabControl tabs = new MetroTabControl();
    private MetroTabPage tab1 = new MetroTabPage();
    private MetroTabPage tab2 = new MetroTabPage();
    private MetroTabPage addtab = new MetroTabPage();
    private Panel navbar = new Panel();
    private Panel sidebar = new Panel();
    /* navbar components */
    private Button bmbtn = new Button();
    private RichTextBox adressbar = new RichTextBox();
    private Button gtubtn = new Button();
    /* webcontents */
    private ScrollableControl webcontents = new ScrollableControl();
    /* top index */
    private int topindex = 0;

    #endregion
}
