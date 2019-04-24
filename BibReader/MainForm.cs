﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BibReader.Corpuses;
using BibReader.Statistic;
using System.Drawing;
using System.Collections;
using BibReader.Saver;
using BibReader.ColumnSorting;
using BibReader.Readers;
using BibReader.Publications;
using BibReader.BibReference;
using BibReader.BibReference.TypesOfSourse;

namespace BibReader
{
    public partial class MainForm : Form
    {
        FormStatistic statistic = new FormStatistic();
        List<ListViewItem> deletedNotUniqueItems = new List<ListViewItem>();
        string lastOpenedFileName = string.Empty;
        List<int> indexesOfLibItems;
        int currIndex = -1;

        private StreamReader[] GetStreamReaders()
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Multiselect = true;
            opd.Filter = "Файлы bib|*.bib";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                StreamReader[] streamReaders = new StreamReader[opd.FileNames.Length];
                for(var i =0;i<opd.FileNames.Length;i++)
                {
                    var reader = new StreamReader(opd.FileNames[i]);
                    streamReaders[i] = reader;
                }
                lastOpenedFileName = opd.FileNames.Last();
                return streamReaders;
            }
            return null;
        }

        private void InitListViewItems()
        {
            lvLibItems.Columns.Add("Название");
            lvLibItems.Columns.Add("Авторы");
            lvLibItems.Columns[0].Width = lvLibItems.Width / 2;
            lvLibItems.Columns[1].Width = lvLibItems.Width / 2;

        }

        public MainForm()
        {
            InitializeComponent();
            InitListViewItems();
            btFirst.Enabled = false;
            btUnique.Enabled = false;
            btRelevance.Enabled = false;
            cbBibStyles.SelectedIndex = 0;
            cbSearchCriterion.SelectedIndex = 0;
            // TryToLoadText();
        }

        private void AddLibItemsInLvItems(List<LibItem> libItems)
        {
            foreach (var item in libItems)
            {

                var lvItem = new ListViewItem(new string[]
                {
                    item.Title,
                    item.Authors
                });

                lvItem.Tag = item;
                lvItem.SubItems.Add("1");
                lvLibItems.Items.Add(lvItem);
            }
            lvLibItems.Sorting = SortOrder.Ascending;
            lvLibItems.Sort();
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
        }

        private void UniqueTitles()
        {
            var libItemsCount = lvLibItems.Items.Count;
            double step = libItemsCount / 100;
            pbLoadUniqueData.Step = (int)step;
            Unique unique = new Unique();

            foreach (ListViewItem item in lvLibItems.Items)
            {
                //var ed = 100;
                var title = ((LibItem)item.Tag).Title;
                if (unique.isUnique(title, item.Index))
                {
                    item.SubItems[2].Text = "2";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedNotUniqueItems.Add(item);
                    if (unique.ContainsKey(title))
                        unique.FindImportantData(
                            (LibItem)lvLibItems.Items[unique.IndexOfTitle(title)].Tag,
                            (LibItem)item.Tag
                            );
                }
                if (pbLoadUniqueData.Value + step <= 100)
                    pbLoadUniqueData.Value += (int)step;
            }
            pbLoadUniqueData.Value = 100;
            //Unique.ClearDictionary();
            MessageBox.Show("Готово!");
            pbLoadUniqueData.Value = 0;
        }

        private void RelevanceData()
        {
            var libItemsCount = lvLibItems.Items.Count;
            double step = libItemsCount / 100;
            foreach (ListViewItem item in lvLibItems.Items)
            {
                var pages = ((LibItem)item.Tag).Pages;
                var authors = ((LibItem)item.Tag).Authors;

                if (Relevance.isRelevance(pages, authors))
                {
                    item.SubItems[2].Text = "3";
                }
                else
                {
                    item.Remove();
                    item.SubItems[2].Text = "1";
                    deletedNotUniqueItems.Add(item);
                }

                if (pbLoadUniqueData.Value + step <= 100)
                    pbLoadUniqueData.Value += (int)step;
            }
            pbLoadUniqueData.Value = 100;
            MessageBox.Show("Готово!");
            pbLoadUniqueData.Value = 0;
        }

        private void LoadLibItemsInLv(List<LibItem> libItems)
        {
            lvLibItems.Items.Clear();
            statistic = new FormStatistic();
            //Unique.ClearDictionary();
            currIndex = -1;
            deletedNotUniqueItems.Clear();
            AddLibItemsInLvItems(libItems);
        }

        private List<LibItem> GetListOfLibItemsFromLv()
        {
            var libItems = new List<LibItem>();
            foreach (ListViewItem item in lvLibItems.Items)
                libItems.Add((LibItem)item.Tag);
            return libItems;
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                tbAbstract.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Abstract;
                tbAffiliation.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Affiliation;
                tbAuthors.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Authors;
                tbDoi.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Doi;
                tbJournalName.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).JournalName;
                tbKeywords.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Keywords;
                tbNumber.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Number;
                tbPages.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Pages;
                tbPublisher.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Publisher;
                tbSourсe.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Sourсe;
                tbTitle.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Title;
                tbUrl.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Url;
                tbVolume.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Volume;
                tbYear.Text = ((LibItem)lvLibItems.SelectedItems[0].Tag).Year;
                lbCurrSelectedItem.Text = $"{lvLibItems.SelectedIndices[0] + 1}/{lvLibItems.Items.Count}";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = GetStreamReaders();
            if (reader != null)
            {
                var listOfItems = univReader.Read(reader);
                ClearDataBeforeLoad();
                LoadLibItemsInLv(listOfItems);
                toolStripStatusLabel1.Text = "Last opened file name: " + lastOpenedFileName;

                if (reader != null)
                {
                    btFirst.Enabled = false;
                    btUnique.Enabled = true;
                    btRelevance.Enabled = false;
                    добавитьToolStripMenuItem.Enabled = true;
                }
                UpdateUI();
            }
        }

        private void ClearDataBeforeLoad()
        {
            lvSourceStatistic.Clear();
            lvYearStatistic.Clear();
            lbCurrSelectedItem.Text = "";
            rtbBib.Clear();
            var tbs = tabControl.TabPages["tpData"].Controls.OfType<TextBox>();
            foreach (var tb in tbs)
                tb.Text = string.Empty;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveFile = new SaveFileDialog())
            {
                //MessageBox.Show(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"filesystem\newfile.bib"));
                saveFile.InitialDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"filesystem\newfile.bib");
                saveFile.Filter = "Файлы bib|*.bib";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;
                    MyBibFormat bibFormat = new MyBibFormat();
                    var libItems = GetListOfLibItemsFromLv();
                    bibFormat.Write(libItems, filePath);
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = GetStreamReaders();
            if (reader != null)
            {
                var listOfItems = univReader.Read(reader);
                AddLibItemsInLvItems(listOfItems);

                if (reader != null)
                {
                    btFirst.Enabled = false;
                    btUnique.Enabled = true;
                    btRelevance.Enabled = false;
                }
                UpdateUI();
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            //switch (e.TabPage.Name)
            //{

            //    case "tpYearStatistic":
            //        LoadYearStatistic();
            //        break;
            //    case "tpSourceStatistic":
            //        LoadSourseStatistic();
            //        break;
            //    case "tpBib":
            //        rtbBib.Text = string.Empty;
            //        try
            //        {
            //            MakeBibRef();
            //        }
            //        catch(Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //        break;
            //}
        }

        private void MakeBibRef()
        {
            foreach (ListViewItem item in lvLibItems.Items)
            {
                var libItem = (LibItem)item.Tag;
                AuthorsParser parser = new AuthorsParser();
                parser.Authors = libItem.Authors;
                int volume, number, year;
                Int32.TryParse(libItem.Volume, out volume);
                Int32.TryParse(libItem.Number, out number);
                Int32.TryParse(libItem.Year, out year);
                var authors = parser.GetAuthors(libItem.Sourсe);
                switch (((LibItem)item.Tag).Type)
                {
                    case "conference":
                        var conf = new Conference(authors, libItem.Title, libItem.Publisher, libItem.Pages,
                            year, libItem.Address, libItem.Booktitle);
                        if (cbBibStyles.Text == "APA")
                            conf.MakeAPA(ref rtbBib);
                        else if (cbBibStyles.Text == "Harvard")
                            conf.MakeHarvard(ref rtbBib);
                        else if (cbBibStyles.Text == "IEEE")
                            conf.MakeIEEE(ref rtbBib);
                        else
                            conf.MakeGOST(ref rtbBib);
                        break;

                    case "book":
                        {
                            var book = new Book(authors, libItem.Title, "libItem.Address", libItem.Publisher,
                                year, volume, libItem.Pages, "",
                                DateTime.Parse(DateTime.Now.ToShortDateString()));
                            if (cbBibStyles.Text == "APA")
                                book.MakeAPA(ref rtbBib);
                            else if (cbBibStyles.Text == "Harvard")
                                book.MakeHarvard(ref rtbBib);
                            else if (cbBibStyles.Text == "IEEE")
                                book.MakeIEEE(ref rtbBib);
                            else
                                book.MakeGOST(ref rtbBib);
                            break;
                        }
                    case "journal":
                        var journal = new Journal(authors, libItem.Title, libItem.JournalName, libItem.Pages,
                            year, number, volume,
                            "", DateTime.Parse(DateTime.Now.ToShortDateString()));
                        if (cbBibStyles.Text == "APA")
                            journal.MakeAPA(ref rtbBib);
                        else if (cbBibStyles.Text == "Harvard")
                            journal.MakeHarvard(ref rtbBib);
                        else if (cbBibStyles.Text == "IEEE")
                            journal.MakeIEEE(ref rtbBib);
                        else
                            journal.MakeGOST(ref rtbBib);
                        break;
                }
            }
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            // вернуть все на место
            foreach(var item in deletedNotUniqueItems)
            {
                lvLibItems.Items.Add(item);
            }
            deletedNotUniqueItems.Clear();
            lvLibItems.Sorting = SortOrder.Ascending;
            lvLibItems.Sort();
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
            else
                lbCurrSelectedItem.Text = $"0/{lvLibItems.Items.Count}";

            btUnique.Enabled = true;
            btFirst.Enabled = false;
            добавитьToolStripMenuItem.Enabled = true;
            UpdateUI();

        }

        private void btUnique_Click(object sender, EventArgs e)
        {
            pbLoadUniqueData.Value = 0;
            UniqueTitles();
            foreach(var item in deletedNotUniqueItems)
            {
                if (item.SubItems[2].Text == "2")
                {
                    lvLibItems.Items.Add(item);
                }
            }
            deletedNotUniqueItems = deletedNotUniqueItems.Where(item => item.SubItems[2].Text != "2").ToList();
            lvLibItems.Sorting = SortOrder.Ascending;
            lvLibItems.Sort();


            btRelevance.Enabled = true;
            btUnique.Enabled = false;
            добавитьToolStripMenuItem.Enabled = false;
            UpdateUI();
        }

        private void btRelevance_Click(object sender, EventArgs e)
        {
            RelevanceData();

            btFirst.Enabled = true;
            btRelevance.Enabled = false;
            UpdateUI();
        }

        private void UpdateUI()
        {
            statistic.LoadSourseStatistic(lvLibItems, lvSourceStatistic, btFirst, btUnique, btRelevance);
            statistic.LoadYearStatistic(lvYearStatistic);
            statistic.LoadTypeStatistic(lvTypeOfDoc);
            statistic.LoadJournalStatistic(lvJournalStat);
            statistic.LoadGeographyStatistic(lvGeography);
            statistic.LoadConferenceStatistic(lvConferenceStat);

            rtbBib.Text = string.Empty;
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
            else
            {
                tbAbstract.Text = string.Empty;
                tbAffiliation.Text = string.Empty;
                tbAuthors.Text = string.Empty;
                tbDoi.Text = string.Empty;
                tbJournalName.Text = string.Empty;
                tbKeywords.Text = string.Empty;
                tbNumber.Text = string.Empty;
                tbPages.Text = string.Empty;
                tbPublisher.Text = string.Empty;
                tbSourсe.Text = string.Empty;
                tbTitle.Text = string.Empty;
                tbUrl.Text = string.Empty;
                tbVolume.Text = string.Empty;
                tbYear.Text = string.Empty;
                lbCurrSelectedItem.Text = $"0/{lvLibItems.Items.Count}";
            }
            try
            {
                MakeBibRef();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void lvItems_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (lvLibItems.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            lvLibItems.SelectedItems[0].Remove();
            if (lvLibItems.Items.Count > 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0) { 
            ((LibItem)lvLibItems.SelectedItems[0].Tag).Title = tbTitle.Text;
            lvLibItems.SelectedItems[0].SubItems[0].Text = tbTitle.Text;
            }
        }

        private void tbAbstract_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Abstract = tbAbstract.Text;
        }

        private void tbJournalName_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).JournalName = tbJournalName.Text;
        }

        private void tbYear_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Year = tbYear.Text;
        }

        private void tbVolume_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Volume = tbVolume.Text;
        }

        private void tbPublisher_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Publisher = tbPublisher.Text;
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Number = tbNumber.Text;
        }

        private void tbPages_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Pages = tbPages.Text;
        }

        private void tbDoi_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Doi = tbDoi.Text;
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Url = tbUrl.Text;
        }

        private void tbAffiliation_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Affiliation = tbAffiliation.Text;
        }

        private void tbKeywords_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Keywords = tbKeywords.Text;
        }

        private void tbSourсe_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Sourсe = tbSourсe.Text;
        }

        private void tbAuthors_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
            {
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Authors = tbAuthors.Text;
                lvLibItems.SelectedItems[0].SubItems[1].Text = tbAuthors.Text;
            }
        }

        private void btNextFindedLibItem_Click(object sender, EventArgs e)
        {
            indexesOfLibItems = new List<int>();
            indexesOfLibItems.Clear();
            foreach (ListViewItem libItem in lvLibItems.Items)
            {
                switch (cbSearchCriterion.SelectedIndex)
                {
                    case 0:
                        if (libItem.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 1:
                        if (((LibItem)libItem.Tag).Abstract.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 2:
                        if (libItem.SubItems[1].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                }
            }
            labelFindedItemsCount.Text = indexesOfLibItems.Count.ToString();

            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                // currIndex = indexesOfLibItems[0];
                currIndex = currIndex >= indexesOfLibItems.Last() || currIndex == -1
                    ? indexesOfLibItems.First()
                    : indexesOfLibItems.First(x => x > currIndex);
                lvLibItems.Items[currIndex].Selected = true;
                lvLibItems.EnsureVisible(currIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");
            
           
        }

        private void btPrevFindedLibItem_Click(object sender, EventArgs e)
        {
            indexesOfLibItems = new List<int>();
            indexesOfLibItems.Clear();
            foreach (ListViewItem libItem in lvLibItems.Items)
            {
                switch (cbSearchCriterion.SelectedIndex)
                {
                    case 0:
                        if (libItem.SubItems[0].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 1:
                        if (((LibItem)libItem.Tag).Affiliation.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                    case 2:
                        if (libItem.SubItems[1].Text.ToLower().IndexOf(tbFind.Text.ToLower()) >= 0)
                            indexesOfLibItems.Add(libItem.Index);
                        break;
                }
            }
            labelFindedItemsCount.Text = indexesOfLibItems.Count.ToString();

            if (indexesOfLibItems.Count > 0)
            {
                lvLibItems.Select();
                currIndex = currIndex <= indexesOfLibItems.First() || currIndex == -1
                    ? indexesOfLibItems.Last() 
                    : indexesOfLibItems.Last(x => x < currIndex);
                lvLibItems.Items[currIndex].Selected = true;
                lvLibItems.EnsureVisible(currIndex);
            }
            else
                MessageBox.Show("Элементы не найдены!");

        }

        private void btPrintBib_Click(object sender, EventArgs e)
        {
            rtbBib.Text = string.Empty;
            MakeBibRef();
        }

        private void названияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var libItems = GetListOfLibItemsFromLv();
            string titles = string.Empty;
            foreach(var libItem in libItems)
            {
                if (libItem.Title != string.Empty)
                titles += libItem.Title + "\r\n";
            }
            var form = new ClassificationForm() { Info = titles };
            form.Show();
        }

        private void ключевыеСловаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var libItems = GetListOfLibItemsFromLv();
            string keywords = string.Empty;
            foreach (var libItem in libItems)
            {
                if (libItem.Keywords != string.Empty)
                    keywords += libItem.Keywords + "\r\n";
            }
            var form = new ClassificationForm() { Info = keywords };
            form.Show();
        }

        private void аннотацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var libItems = GetListOfLibItemsFromLv();
            string abstract_ = string.Empty;
            foreach (var libItem in libItems)
            {
                if (libItem.Abstract != string.Empty)
                abstract_ += libItem.Abstract + "\r\n";
            }
            var form = new ClassificationForm() { Info = abstract_ };
            form.Show();
        }

        private void cbSearchCriterion_SelectedIndexChanged(object sender, EventArgs e)
        {
            currIndex = -1;
        }

        private void lvLibItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting.SortingByColumn((ListView)sender, e);  
        }

        private void btSaveStatistic_Click(object sender, EventArgs e)
        {
            ExcelSaver saver = new ExcelSaver();
            var tps = tabControlForStatistic.TabPages;
            var listOfTables = new List<ListView>();

            foreach (TabPage tp in tps)
                listOfTables.Add(tp.Controls.OfType<ListView>().First());
            saver.Save(listOfTables);
        }

        private void lvYearStatistic_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting.SortingByColumn((ListView)sender, e);
        }

        private void lvSourceStatistic_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting.SortingByColumn((ListView)sender, e);
        }

        private void lvTypeOfDoc_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting.SortingByColumn((ListView)sender, e);
        }

        private void lvJournalStat_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting.SortingByColumn((ListView)sender, e);
        }

        private void lvGeography_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting.SortingByColumn((ListView)sender, e);
        }

        private void lvConferenceStat_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Sorting.SortingByColumn((ListView)sender, e);
        }

        private void btSaveBibRef_Click(object sender, EventArgs e)
        {
            WordSaver saver = new WordSaver();
            saver.Save(rtbBib);
        }
    }
}
