﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.BibReference.TypesOfSourse
{
    public class Book
    {
        string Title;
        string[] Authors;
        string Town;
        string Publisher;
        string Pages;
        string Link;
        DateTime Date;
        int Vol;
        int Year;

        public Book(string[] authors, string title, string town, string publisher, int year, int vol, string pages, string link, DateTime date)
        {
            Authors = authors.ToArray();
            Title = title;
            Town = town;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Vol = vol;
            Link = link;
            Date = date;
        }

        public void MakeGOST(ref RichTextBox rtb)
        {
            const string Space = " ";
            const string PointSpace = ". ";
            const string DoublePointSpace = ": ";
            const string Page = " с.";
            const string IntPages = "C. ";
            const string CommaSpace = ", ";
            const string URL = "URL: ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string DateRus = "дата обращения";
            const string Point = ".";
            string result = string.Empty;
            AuthorsParser authorsParser = new AuthorsParser();
            Authors = authorsParser.MakeAuthorsForGOST(Authors);
            if (Authors.Length < 4)
            {
                result += string.Join(", ", Authors);
                result += Space;
                result += Title + PointSpace;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                    result += Authors[i] + CommaSpace;
                result += Authors[2] + " [и др.]";
                result += PointSpace;
                result += Title + PointSpace;

            }
            result += Town;
            result += DoublePointSpace + Publisher + CommaSpace;
            result += Year + Point;
            if (Vol > 0)
                result += " т. " + Vol + Point;
            if (Pages != "0" && Pages != "")
                result += Space + Pages + Page;
            if (Link != "")
                result += Space + URL + Link + Space + Lparenthesis + DateRus + DoublePointSpace + Date.ToString("dd.MM.yyyy") + Rparenthesis + Point;
            rtb.Text += result + "\n\n";
        }

        public void MakeHarvard(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string PointSpace = ". ";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Avaliable = "Avaliable at: ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string Lpar = "[";
            const string Rpar = "]";
            const string DateRus = "Accesed ";
            const string Point = ".";
            const string DoublePoint = ":";


            //MakeAuthorsForHarvard(Authors);
            //rtb.Text += string.Join("", Authors);
            rtb.Select(rtb.TextLength, 0);
            AuthorsParser authorsParser = new AuthorsParser();
            rtb.SelectedText = authorsParser.MakeAuthorsForHarvard(Authors);
            rtb.SelectedText = Space;
            rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = Title + PointSpace;
            //if (Vol > 0)
            //    rtb.SelectedText += Vol + Point; 
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            rtb.SelectedText = Town + DoublePoint + Space;
            rtb.SelectedText = Publisher + CommaSpace;
            //if (Pages == "" || Pages == "0")
            //{
            //    var form = new fAdd() { Text = "Добавьте страницы" };

            //    if (form.ShowDialog() == DialogResult.OK)
            //        Pages = form.Add;
            //    else
            //        MessageBox.Show("Вы не добавили страницы, ссылка будет не верна!");
            //}
            int a = 0;
            if (Int32.TryParse(Pages, out a))
                rtb.SelectedText = Page;
            else
                rtb.SelectedText = PPage;
            rtb.SelectedText = Pages + Point + "\n\n";

            if (Link != "")
                rtb.SelectedText = Space + Avaliable + Link + Space + Lpar + DateRus + Space + Date.ToString("dd MMM yyyy") + Rpar + Point;


        }

        public void MakeAPA(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string PointSpace = ". ";
            const string Point = ".";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Lparenthesis = "(";
            const string Rparenthesis = ")";
            const string Access = "Доступ ";
            const string Retrieved = "Retrieved ";
            const string From = "from ";
            const string DoublePoint = ": ";

            //MakeAuthorsForAPA(Authors);
            //rtb.Text += string.Join("", Authors);
            rtb.Select(rtb.TextLength, 0);
            AuthorsParser authorsParser = new AuthorsParser();
            rtb.SelectedText = authorsParser.MakeAuthorsForAPA(Authors);
            rtb.SelectedText = Space;
            rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = Title + Space;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            //if (Pages == "" || Pages == "0")
            //{
            //    var form = new fAdd() { Text = "Добавьте страницы" };

            //    if (form.ShowDialog() == DialogResult.OK)
            //        Pages = form.Add;
            //    else
            //        MessageBox.Show("Вы не добавили страницы, ссылка будет не верна!");
            //}
            int a = 0;
            if (Int32.TryParse(Pages, out a))
                rtb.SelectedText = Lparenthesis + Page;
            else
                rtb.SelectedText = Lparenthesis + PPage;
            rtb.SelectedText = Pages + Rparenthesis + PointSpace;

            rtb.SelectedText = Town + DoublePoint;
            rtb.SelectedText = Publisher + Point + "\n\n";

            //if (Vol > 0)
            //    rtb.SelectedText += "т. " + Vol + Point;


            if (Link != "")
                rtb.SelectedText = Space + Retrieved + Date.ToString("dd MMMM yyyy") + CommaSpace + From + Link;

        }

        public void MakeIEEE(ref RichTextBox rtb)
        {
            Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
            const string Space = " ";
            const string DoublePointSpace = ": ";
            const string PointSpace = ". ";
            const string Point = ".";
            const string Page = "p. ";
            const string PPage = "pp. ";
            const string CommaSpace = ", ";
            const string Access = "Accessed on: ";
            const string Available = "Available: ";

            //var form = new fAdd() { Text = "Добавьте название страны" };
            string Country = "";
            //if (form.ShowDialog() == DialogResult.OK)
            //    Country = form.Add;
            //else
            //    MessageBox.Show("Вы не добавили страну, ссылка будет не верна!");
            rtb.Select(rtb.TextLength, 0);
            AuthorsParser authorsParser = new AuthorsParser();
            rtb.SelectedText = authorsParser.MakeAuthorsForIEEE(Authors) + CommaSpace;

            //MakeAuthorsForIEEE(Authors);
            //if (Authors.Length < 6)
            //{
            //    rtb.Text += string.Join("", Authors);
            //    rtb.Text += CommaSpace;
            //}
            //else
            //{
            //    rtb.Text += Authors[0] + " et al." + CommaSpace;
            //}

            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = Title + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            rtb.SelectedText = Town + CommaSpace;
            // rtb.SelectedText = Country + DoublePointSpace;
            rtb.SelectedText = Publisher + CommaSpace + Year;
            // rtb.SelectedText = Year;
            //if (Vol > 0)
            //    rtb.SelectedText += "т. " + Vol + PointSpace;
            if (Pages != "")
            {
                rtb.SelectedText = CommaSpace;
                int a = 0;
                if (Int32.TryParse(Pages, out a))
                    rtb.SelectedText = Page;
                else
                    rtb.SelectedText = PPage;

                rtb.SelectedText = Pages + Point + "\n\n";
            }
            else
                rtb.SelectedText = Point + "\n\n";
            if (Link != "")
                rtb.SelectedText = Space + Available + Link + Point + Space + Access + Date.ToString("MMM. dd, yyyy.");
        }
    }

}
