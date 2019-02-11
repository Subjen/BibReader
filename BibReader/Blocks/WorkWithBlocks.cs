﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Blocks
{
    class WorkWithBlocks
    {
        public static int EditDistance(string fstWord, string sndWord)
        {
            int fstWordLength = fstWord.Length, sndWordLength = sndWord.Length;
            int[,] ed = new int[fstWordLength, sndWordLength];

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
                }
            }

            return ed[fstWordLength - 1, sndWordLength - 1];
        }

        public static int LevenshteinDistance(Dictionary<string,int> currTitles, string word)
        {
            var minDistance = 10000;
            int ed;
            foreach (var title in currTitles.Keys)
            {
                if (title == "" || title == null)
                    ed = 10000;
                else
                    ed = EditDistance(word, title);
                if (ed < minDistance)
                    minDistance = ed;
            }
            return minDistance;
        }

        public static void FindImportantData(LibItem savedItem, LibItem currItem)
        {
            AbstractComplement(savedItem, currItem);
            KeywordsComplement(savedItem, currItem);
        }

        private static void KeywordsComplement(LibItem savedItem, LibItem currItem)
        {
            if (savedItem.KeywordsIsEmpty && !currItem.KeywordsIsEmpty)
                savedItem.Keywords = currItem.Keywords;
        }

        private static void AbstractComplement(LibItem savedItem, LibItem currItem)
        {
            if (savedItem.AbstractIsEmpty && !currItem.AbstractIsEmpty)
                savedItem.Abstract = currItem.Abstract;

        }

        public static bool isRelevancePages(string pages)
        {
            if (pages == "" || pages == string.Empty)
                return false;

            var pagesClone = "";
            for (int j = 0; j < pages.Length; j++)
                if (!char.IsLetter(pages[j]))
                    pagesClone += pages[j];
            pages = pagesClone;

            string pageBegin = "", pageEnd = "";
            int i = 0;
            while (i < pages.Length && char.IsDigit(pages[i]))
            { pageBegin += pages[i]; i++; }
            while (i < pages.Length && !char.IsDigit(pages[i]))
                i++;
            while (i < pages.Length)
            { pageEnd += pages[i]; i++; }

            int intPageBegin;
            Int32.TryParse(pageBegin, out intPageBegin);
            int intPageEnd;
            Int32.TryParse(pageEnd, out intPageEnd);

            return intPageEnd - intPageBegin > 3 ? true : false;

        }

    }


}
