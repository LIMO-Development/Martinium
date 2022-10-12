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
        tabs.Theme = MetroThemeStyle.Dark;

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
        navbar.Theme = MetroThemeStyle.Dark;

        // bookmarks button
        bmbtn.Location = new System.Drawing.Point(5, 5);
        bmbtn.Size = new System.Drawing.Size(75, 25);
        bmbtn.Text = "Bookmarks";
        //bmbtn.Theme = MetroThemeStyle.Dark;
        bmbtn.BackColor = System.Drawing.Color.White;
        bmbtn.FlatStyle = FlatStyle.Flat;
        bmbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;

        // adressbar
        adressbar.Location = new System.Drawing.Point(85, 5);
        adressbar.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width - 280, 25);
        adressbar.Name = "AdressBar";
        adressbar.BorderStyle = System.Windows.Forms.BorderStyle.None;

        // go-to-url button
        gtubtn.Location = new System.Drawing.Point(Screen.FromControl(this).Bounds.Width - 191, 5);
        gtubtn.Size = new System.Drawing.Size(50, 25);
        gtubtn.Text = "Go";
        gtubtn.Name = "GoToUrl";
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
        webcontents.Name = "webcontents";
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
        this.Theme = MetroThemeStyle.Dark;

        // custom bool variables
        bool yes = true;

        // tab-related variables
        TabPage currenttab = tabs.TabPages[tabs.SelectedIndex];
        Control gotourl = currenttab.Controls.Find("GoToUrl", yes)[0];
        Control urlbar = currenttab.Controls.Find("Adressbar", yes)[0];
        Control webview = currenttab.Controls.Find("webcontents", yes)[0];

        // page loader(i had to make it a var, because it wouldnt work otherwise)
        var LoadPage = (string url) => { 
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
                webview.Controls.Add(label);
            }
            foreach (HtmlNode p in dn.SelectNodes("//p"))
            {
                Label label = new Label();
                label.Location = new System.Drawing.Point(0, topindex);
                label.Text = p.InnerText;
                label.Font = new System.Drawing.Font("Sans-Serif", 30);
                label.AutoSize = true;
                topindex += 35;
                webview.Controls.Add(label);
            }
            foreach (HtmlNode item in dn.SelectNodes("//cdiv"))
            {
                Panel div = new Panel();
                div.Location = new System.Drawing.Point(0, topindex);
                div.AutoSize = true;
                div.BackColor = System.Drawing.Color.Blue;
                //int innertopindex = 5;
                /**
                StringReader sr = new StringReader(item.InnerHtml);
                string line;
                while ((line = sr.ReadLine()) != null) 
                {
                    switch (line.StartsWith("<h>")) 
                    {
                        case true:
                            Label label = new Label();
                            label.Location = new System.Drawing.Point(5, innertopindex);
                            label.AutoSize = true;
                            label.Location = new System.Drawing.Point(0, topindex);
                            label.Text = line.Replace("<h>", "").Replace("</h>", "");
                            label.Font = new System.Drawing.Font("Sans-Serif", 30);
                            label.AutoSize = true;
                            innertopindex += 45;
                            div.Controls.Add(label);
                            break;

                        case false:
                            break;
                    }
                }*/

                webview.Controls.Add(div);
            }
            currenttab.Text = title;
        };

        // url load functionality
        gotourl.Click += new System.EventHandler((object s, System.EventArgs e) => {
            if (urlbar.Text != null) 
            {
                if (!urlbar.Text.StartsWith("https://") && urlbar.Text.Contains(".") && !urlbar.Text.Contains(" ")) 
                {
                    currenttab.Text = "New Tab";
                    topindex = 0;
                    webview.Controls.Clear();
                    //LoadCHTML("https://" + urlbar.Text);
                    LoadPage("https://" + urlbar.Text);
                }
                else if (urlbar.Text == "mart://chtmltest")
                {
                    currenttab.Text = "New Tab";
                    topindex = 0;
                    webview.Controls.Clear();
                    try {
                        LoadPage("https://limodevelopmentcom.ferder.repl.co/chtml/test");
                    } 
                    catch (Exception e1) 
                    {
                        Console.WriteLine("Error: " + e1);
                    }
                }
            }
        });

        
    }

    /**
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
            //webcontents.Controls.Add(label);
            webview.Controls.Add(label);
        }
        foreach (HtmlNode p in dn.SelectNodes("//p"))
        {
            Label label = new Label();
            label.Location = new System.Drawing.Point(0, topindex);
            label.Text = p.InnerText;
            label.Font = new System.Drawing.Font("Sans-Serif", 30);
            label.AutoSize = true;
            topindex += 35;
            webview.Controls.Add(label);
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
    */

    private MetroTabPage newtab() {
        /* init new tab */
        MetroTabPage tab = new MetroTabPage();
        tab.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height - 85);
        tab.Text = "New Tab";
        /* init navbar */
        MetroPanel nb = new MetroPanel();
        nb.Location = new System.Drawing.Point(0, 0);
        nb.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width, 35);
        nb.Theme = MetroThemeStyle.Dark;
        /* init sidebar */
        MetroPanel sb = new MetroPanel();
        sb.Location = new System.Drawing.Point(0, 35);
        sb.Size = new System.Drawing.Size(35, Screen.FromControl(this).Bounds.Height - 120);
        sb.BackColor = System.Drawing.Color.OrangeRed;
        /* init bookmarks button */
        Button btn = new Button();
        btn.Location = new System.Drawing.Point(5, 5);
        btn.Size = new System.Drawing.Size(75, 25);
        btn.Text = "Bookmarks";
        //bmbtn.Theme = MetroThemeStyle.Dark;
        btn.BackColor = System.Drawing.Color.White;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
        /* init address bar */
        RichTextBox addressbar = new RichTextBox();
        addressbar.Location = new System.Drawing.Point(85, 5);
        addressbar.Size = new System.Drawing.Size(Screen.FromControl(this).Bounds.Width - 280, 25);
        addressbar.Name = "AdressBar";
        addressbar.BorderStyle = System.Windows.Forms.BorderStyle.None;
        /* init gotourl */
        
        return tab;
    }

    public MetroTabControl tabs = new MetroTabControl();
    public MetroTabPage tab1 = new MetroTabPage();
    public MetroTabPage tab2 = new MetroTabPage();
    public MetroTabPage addtab = new MetroTabPage();
    public MetroPanel navbar = new MetroPanel();
    public MetroPanel sidebar = new MetroPanel();
    /* navbar components */
    public Button bmbtn = new Button();
    public RichTextBox adressbar = new RichTextBox();
    public Button gtubtn = new Button();
    /* webcontents */
    public ScrollableControl webcontents = new ScrollableControl();
    /* top index */
    public int topindex = 0;

    /* tab-related stuff */
    

    #endregion
}
