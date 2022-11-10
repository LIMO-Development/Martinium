using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HtmlAgilityPack;

namespace Martinium
{
    /// <summary>
    /// Interakční logika pro InnitNewtab.xaml
    /// </summary>
    public partial class InnitNewtab : UserControl
    {
        public InnitNewtab()
        {
            InitializeComponent();
            SetupElementsFromXAML();
        }

        public void SetupElementsFromXAML()
        {
            def1.Height = new GridLength((SystemParameters.PrimaryScreenHeight - 40) - 97);
            def2.Width = new GridLength(SystemParameters.PrimaryScreenWidth - 65);
            def3.Width = new GridLength(SystemParameters.PrimaryScreenWidth - 50);
            webpane.Width = SystemParameters.PrimaryScreenWidth - 50;
            webpane.Height = (SystemParameters.PrimaryScreenHeight - 40) - 97;
            //webcontents.Width = SystemParameters.PrimaryScreenWidth - 50;
            //webcontents.Height = SystemParameters.PrimaryScreenHeight - 40;
            urlBar.Width = (SystemParameters.PrimaryScreenWidth - 65) - 5;
        }

        public void GoToPage(object sender, RoutedEventArgs e)
        {
            string text = urlBar.Text;
            if (text != null)
            {
                switch (text == "mart://chtmltest")
                {
                    case true:
                        topIndex = 0;
                        webcontents.Children.Clear();
                        LoadWebsite("https://limodevelopmentcom.ferder.repl.co/chtml/test");
                        break;

                    case false:
                        switch (text == "mart://newtab")
                        {
                            case true:
                                topIndex = 0;
                                webcontents.Children.Clear();
                                webcontents.Children.Add(new InnitNewtabPage());
                                break;

                            case false:
                                switch (text == "mart://examplepage")
                                {
                                    case true:
                                        topIndex = 0;
                                        webcontents.Children.Clear();
                                        LoadWebsite("https://limodevelopmentcom.ferder.repl.co/examplepage");
                                        break;

                                    case false:
                                        switch (text.Contains(".") && !text.Contains(" "))
                                        {
                                            case true:
                                                topIndex = 0;
                                                webcontents.Children.Clear();
                                                LoadWebsite("https://" + text);
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
            }
        }

        public int topIndex = 0;

        public void LoadWebsite(string url)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            var dom = doc.DocumentNode;
            HtmlNodeCollection nodes = dom.SelectNodes("//div");
            if (nodes != null)
            {
                foreach (HtmlNode node in nodes)
                {
                    StackPanel grid = new StackPanel();
                    foreach (HtmlNode childnode in node.ChildNodes)
                    {
                        switch (childnode.Name)
                        {
                            case "h1":
                                Label h1 = new Label();
                                h1.Content = childnode.InnerText;
                                h1.Foreground = Brushes.White;
                                h1.FontSize = 40;
                                h1.FontFamily = new FontFamily("Times New Roman");
                                h1.Margin = new Thickness(0, topIndex, 0, 0);
                                foreach (HtmlAttribute attr in childnode.GetAttributes())
                                {
                                    switch (attr.Name)
                                    {
                                        case "style":
                                            foreach (string val in attr.Value.Split(";"))
                                            {
                                                if (val.StartsWith("background:"))
                                                {
                                                    string bgVal = val.Replace("background:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(bgVal);
                                                    sBrush.Color = color;
                                                    h1.Background = sBrush;
                                                }
                                                else if (val.StartsWith("border-color:"))
                                                {
                                                    string brdrClrVal = val.Replace("border-color:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(brdrClrVal);
                                                    sBrush.Color = color;
                                                    h1.BorderBrush = sBrush;
                                                }
                                                else if (val.StartsWith("border-width:"))
                                                {
                                                    string brdrWdthVal = val.Replace("border-width:", "").Replace(";", "");
                                                    int brdrThcns = Int32.Parse(brdrWdthVal);
                                                    h1.BorderThickness = new Thickness(brdrThcns, brdrThcns, brdrThcns, brdrThcns);
                                                }
                                                else if (val.StartsWith("color:"))
                                                {
                                                    string clrVal = val.Replace("color:", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(clrVal);
                                                    sBrush.Color = color;
                                                    h1.Foreground = sBrush;
                                                }
                                                else if (val.StartsWith("cursor:"))
                                                {
                                                    string crsrVal = val.Replace("cursor:", "").Replace(";", "");
                                                    switch (crsrVal)
                                                    {
                                                        case "app-starting":
                                                            h1.Cursor = Cursors.AppStarting;
                                                            break;

                                                        case "arrow":
                                                            h1.Cursor = Cursors.Arrow;
                                                            break;

                                                        case "arrow-cd":
                                                            h1.Cursor = Cursors.ArrowCD;
                                                            break;

                                                        case "cross":
                                                            h1.Cursor = Cursors.Cross;
                                                            break;

                                                        case "hand":
                                                            h1.Cursor = Cursors.Hand;
                                                            break;

                                                        case "help":
                                                            h1.Cursor = Cursors.Help;
                                                            break;

                                                        case "ibeam":
                                                            h1.Cursor = Cursors.IBeam;
                                                            break;

                                                        case "no":
                                                            h1.Cursor = Cursors.No;
                                                            break;

                                                        case "none":
                                                            h1.Cursor = Cursors.None;
                                                            break;

                                                        case "pen":
                                                            h1.Cursor = Cursors.Pen;
                                                            break;

                                                        case "scroll-all":
                                                            h1.Cursor = Cursors.ScrollAll;
                                                            break;

                                                        case "scroll-e":
                                                            h1.Cursor = Cursors.ScrollE;
                                                            break;

                                                        case "scroll-n":
                                                            h1.Cursor = Cursors.ScrollN;
                                                            break;

                                                        case "scroll-ne":
                                                            h1.Cursor = Cursors.ScrollNE;
                                                            break;

                                                        case "scroll-ns":
                                                            h1.Cursor = Cursors.ScrollNS;
                                                            break;

                                                        case "scroll-nw":
                                                            h1.Cursor = Cursors.ScrollNW;
                                                            break;

                                                        case "scroll-s":
                                                            h1.Cursor = Cursors.ScrollS;
                                                            break;

                                                        case "scroll-se":
                                                            h1.Cursor = Cursors.ScrollSE;
                                                            break;

                                                        case "scroll-sw":
                                                            h1.Cursor = Cursors.ScrollSW;
                                                            break;

                                                        case "scroll-w":
                                                            h1.Cursor = Cursors.ScrollW;
                                                            break;

                                                        case "scroll-we":
                                                            h1.Cursor = Cursors.ScrollWE;
                                                            break;

                                                        case "size-all":
                                                            h1.Cursor = Cursors.SizeAll;
                                                            break;

                                                        case "size-nesw":
                                                            h1.Cursor = Cursors.SizeNESW;
                                                            break;

                                                        case "size-ns":
                                                            h1.Cursor = Cursors.SizeNS;
                                                            break;

                                                        case "size-nwse":
                                                            h1.Cursor = Cursors.SizeNWSE;
                                                            break;

                                                        case "size-we":
                                                            h1.Cursor = Cursors.SizeWE;
                                                            break;

                                                        case "up-arrow":
                                                            h1.Cursor = Cursors.UpArrow;
                                                            break;

                                                        case "wait":
                                                            h1.Cursor = Cursors.Wait;
                                                            break;
                                                    }
                                                }
                                                else if (val.StartsWith("font-family:"))
                                                {
                                                    string ffVal = (val.Replace("font-family:", "").Replace(";", "")).Replace("-", " ");
                                                    h1.FontFamily = new FontFamily(ffVal);
                                                }
                                                else if (val.StartsWith("font-size:"))
                                                {
                                                    string fsVal = val.Replace("font-size:", "").Replace(";", "");
                                                    int fontSize = Int32.Parse(fsVal);
                                                    h1.FontSize = fontSize;
                                                }
                                                else if (val.StartsWith("height:"))
                                                {
                                                    string hVal = val.Replace("height:", "").Replace(";", "");
                                                    int heightValue = Int32.Parse(hVal);
                                                    h1.Height = heightValue;
                                                    topIndex += (heightValue + 5);
                                                }
                                                else if (val.StartsWith("width:"))
                                                {
                                                    string wVal = val.Replace("width:", "").Replace(";", "");
                                                    int widthValue = Int32.Parse(wVal);
                                                    h1.Width = widthValue;
                                                }
                                            }
                                            break;
                                    }
                                }
                                grid.Children.Add(h1);
                                topIndex = 10;
                                break;

                            case "h2":
                                Label h2 = new Label();
                                h2.Content = childnode.InnerText;
                                h2.Foreground = Brushes.White;
                                h2.FontSize = 35;
                                h2.FontFamily = new FontFamily("Times New Roman");
                                h2.Margin = new Thickness(0, topIndex, 0, 0);
                                foreach (HtmlAttribute attr in childnode.GetAttributes())
                                {
                                    switch (attr.Name)
                                    {
                                        case "style":
                                            foreach (string val in attr.Value.Split(";"))
                                            {
                                                if (val.StartsWith("background:"))
                                                {
                                                    string bgVal = val.Replace("background:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(bgVal);
                                                    sBrush.Color = color;
                                                    h2.Background = sBrush;
                                                }
                                                else if (val.StartsWith("border-color:"))
                                                {
                                                    string brdrClrVal = val.Replace("border-color:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(brdrClrVal);
                                                    sBrush.Color = color;
                                                    h2.BorderBrush = sBrush;
                                                }
                                                else if (val.StartsWith("border-width:"))
                                                {
                                                    string brdrWdthVal = val.Replace("border-width:", "").Replace(";", "");
                                                    int brdrThcns = Int32.Parse(brdrWdthVal);
                                                    h2.BorderThickness = new Thickness(brdrThcns, brdrThcns, brdrThcns, brdrThcns);
                                                }
                                                else if (val.StartsWith("color:"))
                                                {
                                                    string clrVal = val.Replace("color:", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(clrVal);
                                                    sBrush.Color = color;
                                                    h2.Foreground = sBrush;
                                                }
                                                else if (val.StartsWith("cursor:"))
                                                {
                                                    string crsrVal = val.Replace("cursor:", "").Replace(";", "");
                                                    switch (crsrVal)
                                                    {
                                                        case "app-starting":
                                                            h2.Cursor = Cursors.AppStarting;
                                                            break;

                                                        case "arrow":
                                                            h2.Cursor = Cursors.Arrow;
                                                            break;

                                                        case "arrow-cd":
                                                            h2.Cursor = Cursors.ArrowCD;
                                                            break;

                                                        case "cross":
                                                            h2.Cursor = Cursors.Cross;
                                                            break;

                                                        case "hand":
                                                            h2.Cursor = Cursors.Hand;
                                                            break;

                                                        case "help":
                                                            h2.Cursor = Cursors.Help;
                                                            break;

                                                        case "ibeam":
                                                            h2.Cursor = Cursors.IBeam;
                                                            break;

                                                        case "no":
                                                            h2.Cursor = Cursors.No;
                                                            break;

                                                        case "none":
                                                            h2.Cursor = Cursors.None;
                                                            break;

                                                        case "pen":
                                                            h2.Cursor = Cursors.Pen;
                                                            break;

                                                        case "scroll-all":
                                                            h2.Cursor = Cursors.ScrollAll;
                                                            break;

                                                        case "scroll-e":
                                                            h2.Cursor = Cursors.ScrollE;
                                                            break;

                                                        case "scroll-n":
                                                            h2.Cursor = Cursors.ScrollN;
                                                            break;

                                                        case "scroll-ne":
                                                            h2.Cursor = Cursors.ScrollNE;
                                                            break;

                                                        case "scroll-ns":
                                                            h2.Cursor = Cursors.ScrollNS;
                                                            break;

                                                        case "scroll-nw":
                                                            h2.Cursor = Cursors.ScrollNW;
                                                            break;

                                                        case "scroll-s":
                                                            h2.Cursor = Cursors.ScrollS;
                                                            break;

                                                        case "scroll-se":
                                                            h2.Cursor = Cursors.ScrollSE;
                                                            break;

                                                        case "scroll-sw":
                                                            h2.Cursor = Cursors.ScrollSW;
                                                            break;

                                                        case "scroll-w":
                                                            h2.Cursor = Cursors.ScrollW;
                                                            break;

                                                        case "scroll-we":
                                                            h2.Cursor = Cursors.ScrollWE;
                                                            break;

                                                        case "size-all":
                                                            h2.Cursor = Cursors.SizeAll;
                                                            break;

                                                        case "size-nesw":
                                                            h2.Cursor = Cursors.SizeNESW;
                                                            break;

                                                        case "size-ns":
                                                            h2.Cursor = Cursors.SizeNS;
                                                            break;

                                                        case "size-nwse":
                                                            h2.Cursor = Cursors.SizeNWSE;
                                                            break;

                                                        case "size-we":
                                                            h2.Cursor = Cursors.SizeWE;
                                                            break;

                                                        case "up-arrow":
                                                            h2.Cursor = Cursors.UpArrow;
                                                            break;

                                                        case "wait":
                                                            h2.Cursor = Cursors.Wait;
                                                            break;
                                                    }
                                                }
                                                else if (val.StartsWith("font-family:"))
                                                {
                                                    string ffVal = (val.Replace("font-family:", "").Replace(";", "")).Replace("-", " ");
                                                    h2.FontFamily = new FontFamily(ffVal);
                                                }
                                                else if (val.StartsWith("font-size:"))
                                                {
                                                    string fsVal = val.Replace("font-size:", "").Replace(";", "");
                                                    int fontSize = Int32.Parse(fsVal);
                                                    h2.FontSize = fontSize;
                                                }
                                                else if (val.StartsWith("height:"))
                                                {
                                                    string hVal = val.Replace("height:", "").Replace(";", "");
                                                    int heightValue = Int32.Parse(hVal);
                                                    h2.Height = heightValue;
                                                    topIndex += (heightValue + 5);
                                                }
                                                else if (val.StartsWith("width:"))
                                                {
                                                    string wVal = val.Replace("width:", "").Replace(";", "");
                                                    int widthValue = Int32.Parse(wVal);
                                                    h2.Width = widthValue;
                                                }
                                            }
                                            break;
                                    }
                                }
                                grid.Children.Add(h2);
                                topIndex = 10;
                                break;

                            case "p":
                                Label p = new Label();
                                p.Content = childnode.InnerText;
                                p.Foreground = Brushes.White;
                                p.FontSize = 25;
                                p.FontFamily = new FontFamily("Times New Roman");
                                p.Margin = new Thickness(0, topIndex, 0, 0);
                                foreach (HtmlAttribute attr in childnode.GetAttributes())
                                {
                                    switch (attr.Name)
                                    {
                                        case "style":
                                            foreach (string val in attr.Value.Split(";"))
                                            {
                                                if (val.StartsWith("background:"))
                                                {
                                                    string bgVal = val.Replace("background:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(bgVal);
                                                    sBrush.Color = color;
                                                    p.Background = sBrush;
                                                }
                                                else if (val.StartsWith("border-color:"))
                                                {
                                                    string brdrClrVal = val.Replace("border-color:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(brdrClrVal);
                                                    sBrush.Color = color;
                                                    p.BorderBrush = sBrush;
                                                }
                                                else if (val.StartsWith("border-width:"))
                                                {
                                                    string brdrWdthVal = val.Replace("border-width:", "").Replace(";", "");
                                                    int brdrThcns = Int32.Parse(brdrWdthVal);
                                                    p.BorderThickness = new Thickness(brdrThcns, brdrThcns, brdrThcns, brdrThcns);
                                                }
                                                else if (val.StartsWith("color:"))
                                                {
                                                    string clrVal = val.Replace("color:", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(clrVal);
                                                    sBrush.Color = color;
                                                    p.Foreground = sBrush;
                                                }
                                                else if (val.StartsWith("cursor:"))
                                                {
                                                    string crsrVal = val.Replace("cursor:", "").Replace(";", "");
                                                    switch (crsrVal)
                                                    {
                                                        case "app-starting":
                                                            p.Cursor = Cursors.AppStarting;
                                                            break;

                                                        case "arrow":
                                                            p.Cursor = Cursors.Arrow;
                                                            break;

                                                        case "arrow-cd":
                                                            p.Cursor = Cursors.ArrowCD;
                                                            break;

                                                        case "cross":
                                                            p.Cursor = Cursors.Cross;
                                                            break;

                                                        case "hand":
                                                            p.Cursor = Cursors.Hand;
                                                            break;

                                                        case "help":
                                                            p.Cursor = Cursors.Help;
                                                            break;

                                                        case "ibeam":
                                                            p.Cursor = Cursors.IBeam;
                                                            break;

                                                        case "no":
                                                            p.Cursor = Cursors.No;
                                                            break;

                                                        case "none":
                                                            p.Cursor = Cursors.None;
                                                            break;

                                                        case "pen":
                                                            p.Cursor = Cursors.Pen;
                                                            break;

                                                        case "scroll-all":
                                                            p.Cursor = Cursors.ScrollAll;
                                                            break;

                                                        case "scroll-e":
                                                            p.Cursor = Cursors.ScrollE;
                                                            break;

                                                        case "scroll-n":
                                                            p.Cursor = Cursors.ScrollN;
                                                            break;

                                                        case "scroll-ne":
                                                            p.Cursor = Cursors.ScrollNE;
                                                            break;

                                                        case "scroll-ns":
                                                            p.Cursor = Cursors.ScrollNS;
                                                            break;

                                                        case "scroll-nw":
                                                            p.Cursor = Cursors.ScrollNW;
                                                            break;

                                                        case "scroll-s":
                                                            p.Cursor = Cursors.ScrollS;
                                                            break;

                                                        case "scroll-se":
                                                            p.Cursor = Cursors.ScrollSE;
                                                            break;

                                                        case "scroll-sw":
                                                            p.Cursor = Cursors.ScrollSW;
                                                            break;

                                                        case "scroll-w":
                                                            p.Cursor = Cursors.ScrollW;
                                                            break;

                                                        case "scroll-we":
                                                            p.Cursor = Cursors.ScrollWE;
                                                            break;

                                                        case "size-all":
                                                            p.Cursor = Cursors.SizeAll;
                                                            break;

                                                        case "size-nesw":
                                                            p.Cursor = Cursors.SizeNESW;
                                                            break;

                                                        case "size-ns":
                                                            p.Cursor = Cursors.SizeNS;
                                                            break;

                                                        case "size-nwse":
                                                            p.Cursor = Cursors.SizeNWSE;
                                                            break;

                                                        case "size-we":
                                                            p.Cursor = Cursors.SizeWE;
                                                            break;

                                                        case "up-arrow":
                                                            p.Cursor = Cursors.UpArrow;
                                                            break;

                                                        case "wait":
                                                            p.Cursor = Cursors.Wait;
                                                            break;
                                                    }
                                                }
                                                else if (val.StartsWith("font-family:"))
                                                {
                                                    string ffVal = (val.Replace("font-family:", "").Replace(";", "")).Replace("-", " ");
                                                    p.FontFamily = new FontFamily(ffVal);
                                                }
                                                else if (val.StartsWith("font-size:"))
                                                {
                                                    string fsVal = val.Replace("font-size:", "").Replace(";", "");
                                                    int fontSize = Int32.Parse(fsVal);
                                                    p.FontSize = fontSize;
                                                }
                                                else if (val.StartsWith("height:"))
                                                {
                                                    string hVal = val.Replace("height:", "").Replace(";", "");
                                                    int heightValue = Int32.Parse(hVal);
                                                    p.Height = heightValue;
                                                    topIndex += (heightValue + 5);
                                                }
                                                else if (val.StartsWith("width:"))
                                                {
                                                    string wVal = val.Replace("width:", "").Replace(";", "");
                                                    int widthValue = Int32.Parse(wVal);
                                                    p.Width = widthValue;
                                                }
                                            }
                                            break;
                                    }
                                }
                                grid.Children.Add(p);
                                topIndex = 10;
                                break;

                            case "button":
                                Button button = new Button();
                                button.Content = childnode.InnerText;
                                button.Background = Brushes.White;
                                button.BorderBrush = Brushes.LightGray;
                                button.FontSize = 10;
                                button.FontFamily = new FontFamily("Times New Roman");
                                button.Padding = new Thickness(5, 5, 5, 5);
                                button.Margin = new Thickness(0, topIndex, 0, 0);
                                foreach (HtmlAttribute attr in childnode.GetAttributes())
                                {
                                    switch (attr.Name)
                                    {
                                        case "style":
                                            foreach (string val in attr.Value.Split(";"))
                                            {
                                                if (val.StartsWith("background:"))
                                                {
                                                    string bgVal = val.Replace("background:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(bgVal);
                                                    sBrush.Color = color;
                                                    button.Background = sBrush;
                                                }
                                                else if (val.StartsWith("border-color:"))
                                                {
                                                    string brdrClrVal = val.Replace("border-color:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(brdrClrVal);
                                                    sBrush.Color = color;
                                                    button.BorderBrush = sBrush;
                                                }
                                                else if (val.StartsWith("border-width:"))
                                                {
                                                    string brdrWdthVal = val.Replace("border-width:", "").Replace(";", "");
                                                    int brdrThcns = Int32.Parse(brdrWdthVal);
                                                    button.BorderThickness = new Thickness(brdrThcns, brdrThcns, brdrThcns, brdrThcns);
                                                }
                                                else if (val.StartsWith("color:"))
                                                {
                                                    string clrVal = val.Replace("color:", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(clrVal);
                                                    sBrush.Color = color;
                                                    button.Foreground = sBrush;
                                                }
                                                else if (val.StartsWith("cursor:"))
                                                {
                                                    string crsrVal = val.Replace("cursor:", "").Replace(";", "");
                                                    switch (crsrVal)
                                                    {
                                                        case "app-starting":
                                                            button.Cursor = Cursors.AppStarting;
                                                            break;

                                                        case "arrow":
                                                            button.Cursor = Cursors.Arrow;
                                                            break;

                                                        case "arrow-cd":
                                                            button.Cursor = Cursors.ArrowCD;
                                                            break;

                                                        case "cross":
                                                            button.Cursor = Cursors.Cross;
                                                            break;

                                                        case "hand":
                                                            button.Cursor = Cursors.Hand;
                                                            break;

                                                        case "help":
                                                            button.Cursor = Cursors.Help;
                                                            break;

                                                        case "ibeam":
                                                            button.Cursor = Cursors.IBeam;
                                                            break;

                                                        case "no":
                                                            button.Cursor = Cursors.No;
                                                            break;

                                                        case "none":
                                                            button.Cursor = Cursors.None;
                                                            break;

                                                        case "pen":
                                                            button.Cursor = Cursors.Pen;
                                                            break;

                                                        case "scroll-all":
                                                            button.Cursor = Cursors.ScrollAll;
                                                            break;

                                                        case "scroll-e":
                                                            button.Cursor = Cursors.ScrollE;
                                                            break;

                                                        case "scroll-n":
                                                            button.Cursor = Cursors.ScrollN;
                                                            break;

                                                        case "scroll-ne":
                                                            button.Cursor = Cursors.ScrollNE;
                                                            break;

                                                        case "scroll-ns":
                                                            button.Cursor = Cursors.ScrollNS;
                                                            break;

                                                        case "scroll-nw":
                                                            button.Cursor = Cursors.ScrollNW;
                                                            break;

                                                        case "scroll-s":
                                                            button.Cursor = Cursors.ScrollS;
                                                            break;

                                                        case "scroll-se":
                                                            button.Cursor = Cursors.ScrollSE;
                                                            break;

                                                        case "scroll-sw":
                                                            button.Cursor = Cursors.ScrollSW;
                                                            break;

                                                        case "scroll-w":
                                                            button.Cursor = Cursors.ScrollW;
                                                            break;

                                                        case "scroll-we":
                                                            button.Cursor = Cursors.ScrollWE;
                                                            break;

                                                        case "size-all":
                                                            button.Cursor = Cursors.SizeAll;
                                                            break;

                                                        case "size-nesw":
                                                            button.Cursor = Cursors.SizeNESW;
                                                            break;

                                                        case "size-ns":
                                                            button.Cursor = Cursors.SizeNS;
                                                            break;

                                                        case "size-nwse":
                                                            button.Cursor = Cursors.SizeNWSE;
                                                            break;

                                                        case "size-we":
                                                            button.Cursor = Cursors.SizeWE;
                                                            break;

                                                        case "up-arrow":
                                                            button.Cursor = Cursors.UpArrow;
                                                            break;

                                                        case "wait":
                                                            button.Cursor = Cursors.Wait;
                                                            break;
                                                    }
                                                }
                                                else if (val.StartsWith("font-family:"))
                                                {
                                                    string ffVal = (val.Replace("font-family:", "").Replace(";", "")).Replace("-", " ");
                                                    button.FontFamily = new FontFamily(ffVal);
                                                }
                                                else if (val.StartsWith("font-size:"))
                                                {
                                                    string fsVal = val.Replace("font-size:", "").Replace(";", "");
                                                    int fontSize = Int32.Parse(fsVal);
                                                    button.FontSize = fontSize;
                                                }
                                                else if (val.StartsWith("height:"))
                                                {
                                                    string hVal = val.Replace("height:", "").Replace(";", "");
                                                    int heightValue = Int32.Parse(hVal);
                                                    button.Height = heightValue;
                                                    topIndex += (heightValue + 5);
                                                }
                                                else if (val.StartsWith("width:"))
                                                {
                                                    string wVal = val.Replace("width:", "").Replace(";", "");
                                                    int widthValue = Int32.Parse(wVal);
                                                    button.Width = widthValue;
                                                }
                                            }
                                            break;
                                    }
                                }
                                grid.Children.Add(button);
                                topIndex = 10;
                                break;

                            case "textarea":
                                TextBox textarea = new TextBox();
                                textarea.Background = Brushes.White;
                                textarea.BorderBrush = Brushes.LightGray;
                                textarea.FontSize = 10;
                                textarea.FontFamily = new FontFamily("Times New Roman");
                                textarea.Margin = new Thickness(0, topIndex, 0, 0);
                                foreach (HtmlAttribute attr in childnode.GetAttributes())
                                {
                                    switch (attr.Name)
                                    {
                                        case "style":
                                            foreach (string val in attr.Value.Split(";"))
                                            {
                                                if (val.StartsWith("background:"))
                                                {
                                                    string bgVal = val.Replace("background:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(bgVal);
                                                    sBrush.Color = color;
                                                    textarea.Background = sBrush;
                                                }
                                                else if (val.StartsWith("border-color:"))
                                                {
                                                    string brdrClrVal = val.Replace("border-color:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(brdrClrVal);
                                                    sBrush.Color = color;
                                                    textarea.BorderBrush = sBrush;
                                                }
                                                else if (val.StartsWith("border-width:"))
                                                {
                                                    string brdrWdthVal = val.Replace("border-width:", "").Replace(";", "");
                                                    int brdrThcns = Int32.Parse(brdrWdthVal);
                                                    textarea.BorderThickness = new Thickness(brdrThcns, brdrThcns, brdrThcns, brdrThcns);
                                                }
                                                else if (val.StartsWith("color:"))
                                                {
                                                    string clrVal = val.Replace("color:", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(clrVal);
                                                    sBrush.Color = color;
                                                    textarea.Foreground = sBrush;
                                                }
                                                else if (val.StartsWith("cursor:"))
                                                {
                                                    string crsrVal = val.Replace("cursor:", "").Replace(";", "");
                                                    switch (crsrVal)
                                                    {
                                                        case "app-starting":
                                                            textarea.Cursor = Cursors.AppStarting;
                                                            break;

                                                        case "arrow":
                                                            textarea.Cursor = Cursors.Arrow;
                                                            break;

                                                        case "arrow-cd":
                                                            textarea.Cursor = Cursors.ArrowCD;
                                                            break;

                                                        case "cross":
                                                            textarea.Cursor = Cursors.Cross;
                                                            break;

                                                        case "hand":
                                                            textarea.Cursor = Cursors.Hand;
                                                            break;

                                                        case "help":
                                                            textarea.Cursor = Cursors.Help;
                                                            break;

                                                        case "ibeam":
                                                            textarea.Cursor = Cursors.IBeam;
                                                            break;

                                                        case "no":
                                                            textarea.Cursor = Cursors.No;
                                                            break;

                                                        case "none":
                                                            textarea.Cursor = Cursors.None;
                                                            break;

                                                        case "pen":
                                                            textarea.Cursor = Cursors.Pen;
                                                            break;

                                                        case "scroll-all":
                                                            textarea.Cursor = Cursors.ScrollAll;
                                                            break;

                                                        case "scroll-e":
                                                            textarea.Cursor = Cursors.ScrollE;
                                                            break;

                                                        case "scroll-n":
                                                            textarea.Cursor = Cursors.ScrollN;
                                                            break;

                                                        case "scroll-ne":
                                                            textarea.Cursor = Cursors.ScrollNE;
                                                            break;

                                                        case "scroll-ns":
                                                            textarea.Cursor = Cursors.ScrollNS;
                                                            break;

                                                        case "scroll-nw":
                                                            textarea.Cursor = Cursors.ScrollNW;
                                                            break;

                                                        case "scroll-s":
                                                            textarea.Cursor = Cursors.ScrollS;
                                                            break;

                                                        case "scroll-se":
                                                            textarea.Cursor = Cursors.ScrollSE;
                                                            break;

                                                        case "scroll-sw":
                                                            textarea.Cursor = Cursors.ScrollSW;
                                                            break;

                                                        case "scroll-w":
                                                            textarea.Cursor = Cursors.ScrollW;
                                                            break;

                                                        case "scroll-we":
                                                            textarea.Cursor = Cursors.ScrollWE;
                                                            break;

                                                        case "size-all":
                                                            textarea.Cursor = Cursors.SizeAll;
                                                            break;

                                                        case "size-nesw":
                                                            textarea.Cursor = Cursors.SizeNESW;
                                                            break;

                                                        case "size-ns":
                                                            textarea.Cursor = Cursors.SizeNS;
                                                            break;

                                                        case "size-nwse":
                                                            textarea.Cursor = Cursors.SizeNWSE;
                                                            break;

                                                        case "size-we":
                                                            textarea.Cursor = Cursors.SizeWE;
                                                            break;

                                                        case "up-arrow":
                                                            textarea.Cursor = Cursors.UpArrow;
                                                            break;

                                                        case "wait":
                                                            textarea.Cursor = Cursors.Wait;
                                                            break;
                                                    }
                                                }
                                                else if (val.StartsWith("font-family:"))
                                                {
                                                    string ffVal = (val.Replace("font-family:", "").Replace(";", "")).Replace("-", " ");
                                                    textarea.FontFamily = new FontFamily(ffVal);
                                                }
                                                else if (val.StartsWith("font-size:"))
                                                {
                                                    string fsVal = val.Replace("font-size:", "").Replace(";", "");
                                                    int fontSize = Int32.Parse(fsVal);
                                                    textarea.FontSize = fontSize;
                                                }
                                                else if (val.StartsWith("height:"))
                                                {
                                                    string hVal = val.Replace("height:", "").Replace(";", "");
                                                    int heightValue = Int32.Parse(hVal);
                                                    textarea.Height = heightValue;
                                                    topIndex += (heightValue + 5);
                                                }
                                                else if (val.StartsWith("width:"))
                                                {
                                                    string wVal = val.Replace("width:", "").Replace(";", "");
                                                    int widthValue = Int32.Parse(wVal);
                                                    textarea.Width = widthValue;
                                                }
                                            }
                                            break;
                                    }
                                }
                                grid.Children.Add(textarea);
                                topIndex = 10;
                                break;

                            case "input":
                                break;

                            case "script":
                                break;

                            case "style":
                                break;

                            default:
                                Label label = new Label();
                                label.Content = childnode.InnerText;
                                label.Foreground = Brushes.White;
                                label.FontSize = 10;
                                label.FontFamily = new FontFamily("Times New Roman");
                                label.Margin = new Thickness(0, topIndex, 0, 0);
                                foreach (HtmlAttribute attr in childnode.GetAttributes())
                                {
                                    switch (attr.Name)
                                    {
                                        case "style":
                                            foreach (string val in attr.Value.Split(";"))
                                            {
                                                if (val.StartsWith("background:"))
                                                {
                                                    string bgVal = val.Replace("background:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(bgVal);
                                                    sBrush.Color = color;
                                                    label.Background = sBrush;
                                                }
                                                else if (val.StartsWith("border-color:"))
                                                {
                                                    string brdrClrVal = val.Replace("border-color:", "").Replace(";", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(brdrClrVal);
                                                    sBrush.Color = color;
                                                    label.BorderBrush = sBrush;
                                                }
                                                else if (val.StartsWith("border-width:"))
                                                {
                                                    string brdrWdthVal = val.Replace("border-width:", "").Replace(";", "");
                                                    int brdrThcns = Int32.Parse(brdrWdthVal);
                                                    label.BorderThickness = new Thickness(brdrThcns, brdrThcns, brdrThcns, brdrThcns);
                                                }
                                                else if (val.StartsWith("color:"))
                                                {
                                                    string clrVal = val.Replace("color:", "");
                                                    SolidColorBrush sBrush = new SolidColorBrush();
                                                    Color color = (Color)ColorConverter.ConvertFromString(clrVal);
                                                    sBrush.Color = color;
                                                    label.Foreground = sBrush;
                                                }
                                                else if (val.StartsWith("cursor:"))
                                                {
                                                    string crsrVal = val.Replace("cursor:", "").Replace(";", "");
                                                    switch (crsrVal)
                                                    {
                                                        case "app-starting":
                                                            label.Cursor = Cursors.AppStarting;
                                                            break;

                                                        case "arrow":
                                                            label.Cursor = Cursors.Arrow;
                                                            break;

                                                        case "arrow-cd":
                                                            label.Cursor = Cursors.ArrowCD;
                                                            break;

                                                        case "cross":
                                                            label.Cursor = Cursors.Cross;
                                                            break;

                                                        case "hand":
                                                            label.Cursor = Cursors.Hand;
                                                            break;

                                                        case "help":
                                                            label.Cursor = Cursors.Help;
                                                            break;

                                                        case "ibeam":
                                                            label.Cursor = Cursors.IBeam;
                                                            break;

                                                        case "no":
                                                            label.Cursor = Cursors.No;
                                                            break;

                                                        case "none":
                                                            label.Cursor = Cursors.None;
                                                            break;

                                                        case "pen":
                                                            label.Cursor = Cursors.Pen;
                                                            break;

                                                        case "scroll-all":
                                                            label.Cursor = Cursors.ScrollAll;
                                                            break;

                                                        case "scroll-e":
                                                            label.Cursor = Cursors.ScrollE;
                                                            break;

                                                        case "scroll-n":
                                                            label.Cursor = Cursors.ScrollN;
                                                            break;

                                                        case "scroll-ne":
                                                            label.Cursor = Cursors.ScrollNE;
                                                            break;

                                                        case "scroll-ns":
                                                            label.Cursor = Cursors.ScrollNS;
                                                            break;

                                                        case "scroll-nw":
                                                            label.Cursor = Cursors.ScrollNW;
                                                            break;

                                                        case "scroll-s":
                                                            label.Cursor = Cursors.ScrollS;
                                                            break;

                                                        case "scroll-se":
                                                            label.Cursor = Cursors.ScrollSE;
                                                            break;

                                                        case "scroll-sw":
                                                            label.Cursor = Cursors.ScrollSW;
                                                            break;

                                                        case "scroll-w":
                                                            label.Cursor = Cursors.ScrollW;
                                                            break;

                                                        case "scroll-we":
                                                            label.Cursor = Cursors.ScrollWE;
                                                            break;

                                                        case "size-all":
                                                            label.Cursor = Cursors.SizeAll;
                                                            break;

                                                        case "size-nesw":
                                                            label.Cursor = Cursors.SizeNESW;
                                                            break;

                                                        case "size-ns":
                                                            label.Cursor = Cursors.SizeNS;
                                                            break;

                                                        case "size-nwse":
                                                            label.Cursor = Cursors.SizeNWSE;
                                                            break;

                                                        case "size-we":
                                                            label.Cursor = Cursors.SizeWE;
                                                            break;

                                                        case "up-arrow":
                                                            label.Cursor = Cursors.UpArrow;
                                                            break;

                                                        case "wait":
                                                            label.Cursor = Cursors.Wait;
                                                            break;
                                                    }
                                                }
                                                else if (val.StartsWith("font-family:"))
                                                {
                                                    string ffVal = (val.Replace("font-family:", "").Replace(";", "")).Replace("-", " ");
                                                    label.FontFamily = new FontFamily(ffVal);
                                                }
                                                else if (val.StartsWith("font-size:"))
                                                {
                                                    string fsVal = val.Replace("font-size:", "").Replace(";", "");
                                                    int fontSize = Int32.Parse(fsVal);
                                                    label.FontSize = fontSize;
                                                }
                                                else if (val.StartsWith("height:"))
                                                {
                                                    string hVal = val.Replace("height:", "").Replace(";", "");
                                                    int heightValue = Int32.Parse(hVal);
                                                    label.Height = heightValue;
                                                    topIndex += (heightValue + 5);
                                                }
                                                else if (val.StartsWith("width:"))
                                                {
                                                    string wVal = val.Replace("width:", "").Replace(";", "");
                                                    int widthValue = Int32.Parse(wVal);
                                                    label.Width = widthValue;
                                                }
                                            }
                                            break;
                                    }
                                }
                                grid.Children.Add(label);
                                topIndex = 10;
                                break;
                        }
                    }
                    SolidColorBrush bgcolor = new SolidColorBrush();
                    Color clr = new Color();
                    clr.R = 15;
                    clr.G = 15;
                    clr.B = 15;
                    clr.A = 255;
                    bgcolor.Color = clr;
                    webcontents.Background = bgcolor;
                    webcontents.Children.Add(grid);
                    topIndex = 0;
                }
            }
        }
    }
}
