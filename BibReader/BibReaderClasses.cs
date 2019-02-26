﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibReader
{
    public class MyDictinaries
    {
        public Dictionary<string, string> dict;
        public Dictionary<string, string> mainDict;
        public void Init()
        {
            dict = new Dictionary<string, string>
            {
                {"author", "authors"},
                {"Author", "authors"},
                {"title", "title"},
                {"Title", "title"},
                {"journal", "journalName"},
                {"Journal", "journalName"},
                {"year", "year"},
                {"Year", "year"},
                {"volume", "volume"},
                {"Volume", "volume"},
                {"pages", "pages"},
                {"Pages", "pages"},
                {"number", "number"},
                {"Number", "number"},
                {"doi", "doi"},
                {"DOI", "doi"},
                {"url", "url"},
                {"affiliation", "affiliation"},
                {"abstract", "abstract"},
                {"Abstract", "abstract"},
                {"keywords", "keywords"},
                {"Keywords", "keywords"},
                {"author_keywords", "keywords"},
                {"publisher", "publisher"},
                {"Publisher", "publisher"},
                {"source", "source"},
                {"inproceedings", "conference"},
                {"INPROCEEDINGS", "conference"},
                {"article", "journal"},
                {"ARTICLE", "journal"},
                {"CONFERENCE", "conference"},
                {"incollection", "book"},
                {"BOOK", "book"},
            };
            mainDict = new Dictionary<string, string>
            {
                { "authors", ""},
                { "title", ""},
                { "booktitle", ""},
                { "journalName", ""},
                { "year", ""},
                { "volume", ""},
                { "pages", ""},
                { "doi", ""},
                { "url", ""},
                { "affiliation", ""},
                { "abstract", ""},
                { "keywords", ""},
                { "publisher", ""},
                { "source", ""},
                { "number", ""},
                { "originalTitle", ""},
                { "type", "" }
            };
    }
}

    public class ReadAllHeaders
    {
        public Dictionary<string, string> Reader(StreamReader reader)
        {
            var answer = new Dictionary<string, string>();
            var template = @"([^=\s]+)\s?=\s?""?({{?)?([^{}""]+)(}}?)?""?,";
            var regex = new Regex(template);
            string str="", currstr;
            const string endStr = "\",";
            while (!reader.EndOfStream)
            {
                while ((currstr = reader.ReadLine()) != "}")
                {
                    if (currstr.Length != 0)
                    {
                        if (currstr[0] != '@')
                            str += currstr;

                        if (currstr.Substring(currstr.Length - 2, 2) == "}," || currstr.Substring(currstr.Length - 2, 2) == endStr)
                        //    continue;
                        //else
                        {
                            var key = regex.Match(str, 0).Groups[1].Value;
                            var value = regex.Match(str, 0).Groups[3].Value;
                            
                            if (!answer.ContainsKey(key))
                                answer.Add(key, value);
                            str = "";
                        }
                    }
                }
                reader.ReadLine();// еще пробел
            }
                return answer;
        }

    }

    public class UniversalBibReader
    {
        MyDictinaries myDictinaries = new MyDictinaries();


        private string WhereFrom(string str)
        {
            switch(str.Substring(0, "title".Length))
            {
                case " titl":
                    return "ACMDL";
                case "title":
                    return (str[5] != ' ') ? "IEEE" : "Science direct";
                case "Title":
                    return "Web of science";
            }
            return "";
        }

        private string pretreatmentTitle(string title)
        {
            string[] codesForRemove = new string[] {
                @"\&\#38;",
                "amp;#x2014;"
            };

            foreach (var code in codesForRemove)
            {
                if (title.Contains(code))
                {
                    var index = title.IndexOf(code);
                    title = title.Remove(index, code.Length);
                }
            }

            title = FindOriginalTitle(title);

            return title;
        }

        private string FindOriginalTitle(string title)
        {
            var template = @".*\[(.+)\].*";
            var regex = new Regex(template);

            var value = regex.Match(title).Groups[1].Value;
            if (value != "")
            {
                myDictinaries.mainDict["originalTitle"] = value;
                var index = title.IndexOf(value);
                title = title.Remove(index - 1, value.Length + 2);
            }

            return title;
        }

        private bool isScienceDirectEnd(string str) => 
            (str.Length >= "abstract = ".Length + 1 && str.Substring(0, "abstract = ".Length + 1) == "abstract = \"")
            ? true 
            : false;

        private void ScienceDirectFix(string str)
        {
            var template = @"(.+?)\s=\s""(.+?)""";
            var regex = new Regex(template);
           
            var key = regex.Match(str).Groups[1].Value;
            var value = regex.Match(str).Groups[2].Value;
            myDictinaries.mainDict[myDictinaries.dict[key]] = value;
        }

        private void SetTypeOfLibItem(string str)
        {
            var index = str.IndexOf('{');
            myDictinaries.mainDict["type"] = myDictinaries.dict[str.Substring(1, index - 1).ToLower()];
        }

        private List<LibItem> ReadFile(StreamReader reader, List<LibItem> Items)
        {
            var template = @"\s?(.+?)\s?=\s?(""|{{|{)(.+?)(""|}}|}),";
            var regex = new Regex(template);
            string str = "", currstr = "";
            const string endStr = "\",";

            if (reader == null)
                return Items;
            while ((currstr = reader.ReadLine()) != null && currstr != "" && currstr[0] != '@')
                currstr = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                myDictinaries = new MyDictinaries();
                myDictinaries.Init();
                currstr = reader.ReadLine();
                while (currstr == "" || currstr != "}" && (currstr.Length > 2 && currstr.Substring(currstr.Length - 2, 2) != ",}"))
                {
                    if (currstr != "")
                    {
                        if (currstr[0] != '@')
                            str += currstr;
                        else
                            SetTypeOfLibItem(currstr);

                        if (currstr.Length >= 2 && (currstr.Substring(currstr.Length - 2, 2) == "}," ||
                            currstr.Substring(currstr.Length - 2, 2) == endStr))
                        {
                            var key = regex.Match(str).Groups[1].Value;
                            var value = regex.Match(str).Groups[3].Value;
                            if (key == "title" || key == "Title" || key == "sourse")
                            {
                                value = pretreatmentTitle(value);
                                myDictinaries.mainDict["source"] = WhereFrom(str);
                                if (key == "sourse")
                                    myDictinaries.mainDict["sourse"] = value;
                            }
                            if (myDictinaries.dict.ContainsKey(key))
                                myDictinaries.mainDict[myDictinaries.dict[key]] = value;
                            str = "";
                        }
                    }
                    currstr = reader.ReadLine();
                    if (currstr == null)
                        break;
                }
                if (str != string.Empty)
                    ScienceDirectFix(str);
                if (currstr == null)
                    break;
                str = string.Empty;
                var newItem = new LibItem(myDictinaries.mainDict);
                Items.Add(newItem);
            }
            reader.Close();
            return Items;

        }

        public List<LibItem> Read(StreamReader[] readers)
        {
            var Items = new List<LibItem>();
            if (readers != null)
                foreach (var reader in readers)
                    Items = ReadFile(reader, Items);
            return Items;
        }
    }
}
