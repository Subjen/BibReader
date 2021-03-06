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
using System.Reflection;
using Collection = BibReader.Finder.Collection.Collection;

namespace BibReader
{
    public partial class MainForm : Form
    {
        List<LibItem> deletedLibItems = new List<LibItem>();
        List<LibItem> libItems = new List<LibItem>();
        string lastOpenedFileName = string.Empty;
        Finder.Finder finder = new Finder.Finder();
        Log.Log log = new Log.Log();

        private StreamReader[] GetStreamReaders()
        {
            using (var opd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Файлы bib|*.bib"
            })
            {
                if (opd.ShowDialog() == DialogResult.OK)
                {
                    var streamReaders = new StreamReader[opd.FileNames.Length];
                    for (var i = 0; i < opd.FileNames.Length; i++)
                    {
                        var reader = new StreamReader(opd.FileNames[i]);
                        streamReaders[i] = reader;
                    }
                    lastOpenedFileName = opd.FileNames.Last();
                    return streamReaders;
                }
                return null;
            }
        }

        private void InitListViewItems()
        {
            lvLibItems.Columns.Add("Название");
            lvLibItems.Columns.Add("Авторы");
            lvLibItems.Columns[0].Width = lvLibItems.Width / 2;
            lvLibItems.Columns[1].Width = lvLibItems.Width / 2;
        }

        private void InitListViewEvent()
        {
            var lists = Controls.OfType<ListView>();
            var tps = tabControlForStatistic.TabPages;
            var listOfTables = new List<ListView>();
            foreach (TabPage tp in tps)
                listOfTables.Add(tp.Controls.OfType<ListView>().First());
            listOfTables.AddRange(lists);
            listOfTables.ForEach(listView => listView.ColumnClick += new ColumnClickEventHandler(
                (sender, e) => Sorting.SortingByColumn((ListView)sender, e.Column))
                );
        }

        private void InitTextBoxTextChangedEvent()
        {
            var textBoxes = tabControl.TabPages["tpData"].Controls.OfType<TextBox>();
            foreach (var tb in textBoxes)
                tb.TextChanged += TextBoxTextChanged;
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            PropertyInfo info = null;
            if (lvLibItems.Items.Count != 0)
                info = ((LibItem)lvLibItems.SelectedItems[0].Tag).GetProperty(((TextBox)sender).Name);
            if (info != null)
                info.SetValue((LibItem)lvLibItems.SelectedItems[0].Tag, ((TextBox)sender).Text);
        }

        public MainForm()
        {
            InitializeComponent();
            InitListViewEvent();
            InitTextBoxTextChangedEvent();
            InitListViewItems();
            btFirst.Enabled = false;
            btUnique.Enabled = false;
            btRelevance.Enabled = false;
            cbBibStyles.SelectedIndex = 0;
            cbSearchCriterion.SelectedIndex = 0;
        }

        private void AddLibItemsInLvItems()
        {
            lvLibItems.Items.Clear();
            foreach (var item in Filter.FilterOut(libItems))
            {
                var lvItem = new ListViewItem(new string[]
                {
                    item.Title,
                    item.Authors,
                });

                lvItem.Tag = item;
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

            var time = DateTime.Now;
            log.Write($"{ time.ToString() }");
            log.Write($"> Find unique where libItems count = {lvLibItems.Items.Count} ");
          
            // var unique = new Unique(lvLibItems.Items.Cast<ListViewItem>().Select(item => (LibItem)item.Tag).ToList());
            var unique = new Unique(libItems);

            var uniqueItems = unique.GetUnique();
            deletedLibItems.AddRange(libItems.Except(uniqueItems).ToList());
            libItems = uniqueItems;
            LoadLibItems();

            log.Write($"{ (DateTime.Now - time).TotalSeconds.ToString() } sec.");
            log.Write("____________________");

            pbLoadUniqueData.Value = 100;
            MessageBox.Show("Готово!");
            pbLoadUniqueData.Value = 0;
        }

        private void RelevanceData()
        {
            var libItemsCount = lvLibItems.Items.Count;
            double step = libItemsCount / 100;

            var time = DateTime.Now;
            log.Write($"{ time.ToString() }");
            log.Write($"> Find relevance where libItems count = {lvLibItems.Items.Count} ");

            // var relevance = new Relevance(lvLibItems.Items.Cast<ListViewItem>().Select(item => (LibItem)item.Tag).ToList());
            var relevance = new Relevance(libItems);
            var relevanceItems = relevance.GetRelevance();
            deletedLibItems.AddRange(libItems.Except(relevanceItems).ToList());
            libItems = relevanceItems;
            LoadLibItems();

            log.Write($"{ (DateTime.Now - time).TotalSeconds.ToString() } sec.");
            log.Write("____________________");

            pbLoadUniqueData.Value = 100;
            MessageBox.Show("Готово!");
            pbLoadUniqueData.Value = 0;
        }

        private void LoadLibItems()
        {
            lvLibItems.Items.Clear();
            // deletedLibItems.Clear();
            AddLibItemsInLvItems();
        }

        private void lvItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                var item = (LibItem)((ListView)sender).SelectedItems[0].Tag;
                tbAbstract.Text = item.Abstract;
                tbAffiliation.Text = item.Affiliation;
                tbAuthors.Text = item.Authors;
                tbDoi.Text = item.Doi;
                tbJournalName.Text = item.JournalName;
                tbKeywords.Text = item.Keywords;
                tbNumber.Text = item.Number;
                tbPages.Text = item.Pages;
                tbPublisher.Text = item.Publisher;
                tbSourсe.Text = item.Sourсe;
                tbTitle.Text = item.Title;
                tbUrl.Text = item.Url;
                tbVolume.Text = item.Volume;
                tbYear.Text = item.Year;
                lbCurrSelectedItem.Text = $"{lvLibItems.SelectedIndices[0] + 1}/{lvLibItems.Items.Count}";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var readers = GetStreamReaders();
            if (readers != null)
            {
                libItems.Clear();
                deletedLibItems.Clear();
                libItems.AddRange(univReader.Read(readers));
                LoadFilters();
                var time = DateTime.Now;
                log.Write($"{ time.ToString() }");
                log.Write($"> Open file");
                finder = new Finder.Finder();
                LoadLibItems();
                log.Write($"> Add new LibItem(s): count = { lvLibItems.Items.Count }");
                log.Write($"{ (DateTime.Now - time).TotalSeconds.ToString() } sec.");
                log.Write("____________________");

                toolStripStatusLabel1.Text = "Last opened file name: " + lastOpenedFileName;
                labelFindedItemsCount.Text = string.Empty;
                btFirst.Enabled = false;
                btUnique.Enabled = true;
                btRelevance.Enabled = false;
                добавитьToolStripMenuItem.Enabled = true;
                UpdateUI();
            }
        }

        private void LoadFilters()
        {
            UpdateStatistic();
            Filter.Clear();
            Filter.Conferences.AddRange(Stat.Conference.Keys.Select(key => key));
            Filter.Years.AddRange(Stat.Years.Keys.Select(key => key));
            Filter.Geography.AddRange(Stat.Geography.Keys.Select(key => key));
            Filter.Journals.AddRange(Stat.Journal.Keys.Select(key => key));
            Filter.Types.AddRange(Stat.Types.Keys.Select(key => key));
            Filter.Source.AddRange(Stat.Sources.Keys.Select(key => key));
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var univReader = new UniversalBibReader();
            var reader = GetStreamReaders();
            if (reader != null)
            {
                List<LibItem> newitems;
                var time = DateTime.Now;
                log.Write($"{ time.ToString() }");
                log.Write($"> Add new LibItem(s): count = { (newitems = univReader.Read(reader)).Count }");
                libItems.AddRange(newitems);
                LoadFilters();
                AddLibItemsInLvItems();
                log.Write($"{ (DateTime.Now - time).TotalSeconds.ToString() } sec.");
                log.Write("____________________");

                labelFindedItemsCount.Text = string.Empty;
                btFirst.Enabled = false;
                btUnique.Enabled = true;
                btRelevance.Enabled = false;
                UpdateUI();
            }
        }

        private void MakeBibRef()
        {
            foreach (ListViewItem item in lvLibItems.Items)
            {
                var libItem = (LibItem)item.Tag;
                switch (((LibItem)item.Tag).Type)
                {
                    case "conference":
                        var conference = new Conference(libItem);
                        if (cbBibStyles.Text == "APA")
                            conference.MakeAPA(rtbBib);
                        else if (cbBibStyles.Text == "Harvard")
                            conference.MakeHarvard(rtbBib);
                        else if (cbBibStyles.Text == "IEEE")
                            conference.MakeIEEE(rtbBib);
                        else
                            conference.MakeGOST(rtbBib);
                        break;

                    case "book":
                        {
                            var book = new Book(libItem);
                            if (cbBibStyles.Text == "APA")
                                book.MakeAPA(rtbBib);
                            else if (cbBibStyles.Text == "Harvard")
                                book.MakeHarvard(rtbBib);
                            else if (cbBibStyles.Text == "IEEE")
                                book.MakeIEEE(rtbBib);
                            else
                                book.MakeGOST(rtbBib);
                            break;
                        }

                    case "journal":
                        var journal = new Journal(libItem);
                        if (cbBibStyles.Text == "APA")
                            journal.MakeAPA(rtbBib);
                        else if (cbBibStyles.Text == "Harvard")
                            journal.MakeHarvard(rtbBib);
                        else if (cbBibStyles.Text == "IEEE")
                            journal.MakeIEEE(rtbBib);
                        else
                            journal.MakeGOST(rtbBib);
                        break;
                }
            }
        }

        private void btFirst_Click(object sender, EventArgs e)
        {
            libItems.AddRange(deletedLibItems);// = lvLibItems.Items.Cast<ListViewItem>().Select(item => (LibItem)item.Tag).ToList();
            deletedLibItems.Clear();
            LoadFilters();
            LoadLibItems();
            btUnique.Enabled = true;
            btFirst.Enabled = false;
            добавитьToolStripMenuItem.Enabled = true;
            UpdateUI();
        }

        private void btUnique_Click(object sender, EventArgs e)
        {
            UniqueTitles();
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

        private void UpdateStatistic()
        {
            Stat.Corpus corpus = Stat.Corpus.First;
            if (btRelevance.Enabled)
                corpus = Stat.Corpus.Unique;
            if (btFirst.Enabled)
                corpus = Stat.Corpus.Relevance;

            Stat.CalculateStatistic(libItems, corpus);
            FormStatistic.LoadSourseStatistic(lvSourceStatistic);
            FormStatistic.LoadYearStatistic(lvYearStatistic);
            FormStatistic.LoadTypeStatistic(lvTypeOfDoc);
            FormStatistic.LoadJournalStatistic(lvJournalStat);
            FormStatistic.LoadGeographyStatistic(lvGeography);
            FormStatistic.LoadConferenceStatistic(lvConferenceStat);
        }

        private void UpdateUI()
        {
            UpdateStatistic();
            UpdateBibReference();
            SelectFstLibItem();
        }

        private void SelectFstLibItem()
        {
            if (lvLibItems.Items.Count != 0)
            {
                lvLibItems.Items[0].Selected = true;
                lbCurrSelectedItem.Text = $"1/{lvLibItems.Items.Count}";
            }
            else
            {
                var textBoxes = tabControl.TabPages["tpData"].Controls.OfType<TextBox>();
                foreach (var tb in textBoxes)
                    tb.Text = string.Empty;
                lbCurrSelectedItem.Text = $"0/{lvLibItems.Items.Count}";
            }
        }

        private void UpdateBibReference()
        {
            rtbBib.Text = string.Empty;
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
                if (lvLibItems.FocusedItem.Bounds.Contains(e.Location) == true)
                    contextMenuStrip1.Show(Cursor.Position);
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            lvLibItems.SelectedItems[0].Remove();
            SelectFstLibItem();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
            {
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Title = tbTitle.Text;
                lvLibItems.SelectedItems[0].SubItems[0].Text = tbTitle.Text;
            }
        }

        private void tbAuthors_TextChanged(object sender, EventArgs e)
        {
            if (lvLibItems.Items.Count != 0)
            {
                ((LibItem)lvLibItems.SelectedItems[0].Tag).Authors = tbAuthors.Text;
                lvLibItems.SelectedItems[0].SubItems[1].Text = tbAuthors.Text;
            }
        }

        private int GetNextIndex(Func<List<int>, int, int> func)
        {
            List<int> indexes;
            switch (cbSearchCriterion.SelectedIndex)
            {
                case 0:
                    indexes = Collection.MakeListOfIndexes(tbFind.Text, lvLibItems, 0);
                    break;
                case 1:
                    indexes = Collection.MakeListOfIndexes(
                            tbFind.Text,
                            lvLibItems.Items.Cast<ListViewItem>().Select(item => ((LibItem)item.Tag).Abstract).ToList()
                    );
                    break;
                case 2:
                    indexes = Collection.MakeListOfIndexes(tbFind.Text, lvLibItems, 1);
                    break;
                default:
                    return 0;
            }
            labelFindedItemsCount.Text = indexes.Count.ToString();
            return finder.GetIndex(indexes, func);
        }

        private void btNextFindedLibItem_Click(object sender, EventArgs e) =>
            Collection.SelectItem(lvLibItems, GetNextIndex(Finder.Functions.Next));

        private void btPrevFindedLibItem_Click(object sender, EventArgs e) =>
            Collection.SelectItem(lvLibItems, GetNextIndex(Finder.Functions.Prev));

        private void btPrintBib_Click(object sender, EventArgs e)
        {
            rtbBib.Text = string.Empty;
            MakeBibRef();
        }

        private void названияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string titles = string.Join("\r\n",
                libItems
                .Where(item => item.Title != string.Empty)
                .Select(item => item.Title)
                );
            var form = new ClassificationForm() { Info = titles };
            form.Show();
        }

        private void ключевыеСловаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string keywords = string.Join("\r\n", 
                libItems
                .Where(item => item.Keywords != string.Empty)
                .Select(item => item.Keywords)
                );
            var form = new ClassificationForm() { Info = keywords };
            form.Show();
        }

        private void аннотацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string abstract_ = string.Join("\r\n", 
                libItems
                .Where(item => item.Abstract != string.Empty)
                .Select(item => item.Abstract)
                );
            var form = new ClassificationForm() { Info = abstract_ };
            form.Show();
        }

        private void cbSearchCriterion_SelectedIndexChanged(object sender, EventArgs e) => finder = new Finder.Finder();

        private void btSaveStatistic_Click(object sender, EventArgs e) => ExcelSaver.Save(GetStatisticListViews());

        private void btSaveBibRef_Click(object sender, EventArgs e) => DocSaver.Save(rtbBib);

        private void корпусДокументовToolStripMenuItem_Click(object sender, EventArgs e) => MyBibFormat.Save(libItems);

        private void библОписанияToolStripMenuItem_Click(object sender, EventArgs e) => DocSaver.Save(rtbBib);

        private void статистикуToolStripMenuItem_Click(object sender, EventArgs e) => ExcelSaver.Save(GetStatisticListViews());

        private List<ListView> GetStatisticListViews()
        {
            var listOfTables = new List<ListView>();
            foreach (TabPage tp in tabControlForStatistic.TabPages)
                listOfTables.Add(tp.Controls.OfType<ListView>().First());
            return listOfTables;
        }

        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new FiltersForm()
            {
                Geography = Stat.Geography.Keys.ToList(),
                Sources = Stat.Sources.Keys.ToList(),
                Types = Stat.Types.Keys.ToList(),
                Journals = Stat.Journal.Keys.ToList(),
                Years = Stat.Years.Keys.ToList(),
                Conference = Stat.Conference.Keys.ToList()
            })
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadLibItems();
                }
            }
        }
    }
}
