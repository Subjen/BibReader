﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibReader.Publications;

namespace BibReader.Corpuses
{
    class Unique
    {
        const int distance = 5;
        Dictionary<string, int> currTitles = new Dictionary<string, int>();

        public Unique() {
            currTitles = new Dictionary<string, int>();
        }


        public bool isUnique(string title, int positoin)
        {
            title = Normalize(title);
            if (isUnique(title))
            {
                currTitles.Add(title, positoin);
                return true;
            }
            else
                return false;
        }

        private bool isUnique(string title) => !currTitles.ContainsKey(title) && LevenshteinDistance(currTitles, title) > distance ? true : false;

        public void ClearDictionary() => currTitles.Clear();

        public int IndexOfTitle(string title) => currTitles[Normalize(title)];

        public bool ContainsKey(string title) => currTitles.ContainsKey(Normalize(title));

        public void FindImportantData(LibItem savedItem, LibItem currItem)
        {
            AbstractComplement(savedItem, currItem);
            KeywordsComplement(savedItem, currItem);
            AffiliationComplement(savedItem, currItem);
        }

        private string Normalize(string sentence)
        {
            var resultContainer = new StringBuilder(100);
            var lowerSentece = sentence.ToLower();
            foreach (var c in lowerSentece)
            {
                if (char.IsLetterOrDigit(c) || c == ' ')
                {
                    resultContainer.Append(c);
                }
            }

            return resultContainer.ToString();
        }

        private int EditDistance(string fstWord, string sndWord)
        {
            int fstWordLength = fstWord.Length, sndWordLength = sndWord.Length;
            int[,] ed = new int[fstWordLength, sndWordLength];
            int minValueInRow = 100;

            ed[0, 0] = (fstWord[0] == sndWord[0]) ? 0 : 1;
            for (int i = 1; i < fstWordLength; i++)
            {
                ed[i, 0] = ed[i - 1, 0] + 1;
            }

            for (int j = 1; j < sndWordLength; j++)
            {
                ed[0, j] = ed[0, j - 1] + 1;
            }

            for (int j = 1; j < sndWordLength; j++)
            {
                minValueInRow = 100;
                for (int i = 1; i < fstWordLength; i++)
                {
                    if (fstWord[i] == sndWord[j])
                    {
                        // Операция не требуется
                        ed[i, j] = ed[i - 1, j - 1];
                    }
                    else
                    {
                        // Минимум между удалением, вставкой и заменой
                        ed[i, j] = Math.Min(ed[i - 1, j] + 1,
                            Math.Min(ed[i, j - 1] + 1, ed[i - 1, j - 1] + 1));
                    }
                    if (ed[i, j] < minValueInRow)
                        minValueInRow = ed[i, j];
                }
                if (minValueInRow > distance)
                    return minValueInRow;
            }

            return ed[fstWordLength - 1, sndWordLength - 1];
        }

        private int LevenshteinDistance(Dictionary<string, int> currTitles, string word)
        {
            var minDistance = 10000;
            int ed;
            foreach (var title in currTitles.Keys)
            {
                if (title == "" || title == null)
                    ed = 10000;
                else if (Math.Abs(word.Length - title.Length) > distance)
                    ed = 10000;
                else
                    ed = EditDistance(word, title);
                if (ed < minDistance)
                    minDistance = ed;
            }
            return minDistance;
        }

        private void KeywordsComplement(LibItem savedItem, LibItem currItem)
        {
            if (savedItem.KeywordsIsEmpty && !currItem.KeywordsIsEmpty)
                savedItem.Keywords = currItem.Keywords;
        }

        private void AbstractComplement(LibItem savedItem, LibItem currItem)
        {
            if (savedItem.AbstractIsEmpty && !currItem.AbstractIsEmpty)
                savedItem.Abstract = currItem.Abstract;

        }

        private void AffiliationComplement(LibItem savedItem, LibItem currItem)
        {
            if (savedItem.AffiliationIsEmpty && !currItem.AffiliationIsEmpty)
                savedItem.Affiliation = currItem.Affiliation;
        }


    }


}
