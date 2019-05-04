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
        Dictionary<string, int> UniqueTitles = new Dictionary<string, int>();

        //public Unique() {
        //    UniqueTitles = new Dictionary<string, int>();
        //}


        public int FindCopyPosition(LibItem item, int positoin)
        {
            var title = Normalize(item.Title);
            if (IsUnique(title))
            {
                UniqueTitles.Add(title, positoin);
                return -1;
            }
            else
            {
                return UniqueTitles.ContainsKey(title) ? UniqueTitles[title] :-2;
            }
        }

        private bool IsUnique(string title) => UniqueTitles.Count == 0 || !UniqueTitles.ContainsKey(title) && UniqueTitles.Select(pair => LevenshteinDistance(pair.Key, title)).Min() > distance;

        private int IndexOfTitle(string title) => UniqueTitles[Normalize(title)];

        public void FindImportantData(LibItem savedItem, LibItem currItem)
        {
            AbstractComplement(savedItem, currItem);
            KeywordsComplement(savedItem, currItem);
            AffiliationComplement(savedItem, currItem);
        }

        private string Normalize(string sentence)
        {
            var resultContainer = new StringBuilder(sentence.Length);
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
            int minValueInRow = int.MaxValue;

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
                minValueInRow = int.MaxValue;
                for (int i = 1; i < fstWordLength; i++)
                {
                    if (fstWord[i] == sndWord[j])
                        ed[i, j] = ed[i - 1, j - 1];
                    else
                        ed[i, j] = Math.Min(
                            ed[i - 1, j] + 1,
                            Math.Min(ed[i, j - 1] + 1, ed[i - 1, j - 1] + 1)
                            );
                    if (ed[i, j] < minValueInRow)
                        minValueInRow = ed[i, j];
                }
                if (minValueInRow > distance)
                    return minValueInRow;
            }

            return ed[fstWordLength - 1, sndWordLength - 1];
        }

        private int LevenshteinDistance(string fstWord, string sndWord)
        {
            if (sndWord == "" || sndWord == null)
                return int.MaxValue;
            else if (Math.Abs(sndWord.Length - fstWord.Length) > distance)
                return int.MaxValue;
            else
                return EditDistance(fstWord, sndWord);
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
