using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M_c2
{
    /// <summary>
    /// Contains methods for determening if the word is english.
    /// </summary>
    public class Searcher
    {
        /// <summary>
        /// Word that is searched for.
        /// </summary>
        public string Word { get; set; }

        private string Path { get; set; }


        List<int> startLinesList;

        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        bool wordFound = false;


        public Searcher(string path)
        {
            Path = path;
            startLinesList = new List<int>();

            string filename = System.IO.Path.GetFileName(Path);
            string letterFile_path = Paths.fileInfo_path + @"" + filename + "-ll.txt";

            if (!File.Exists(letterFile_path))
            {
                FileManager fm = new FileManager();
                fm.Write_StartLetters(Path);
            }

            using (StreamReader sr = new StreamReader(letterFile_path))
            {
                int maxLine = File.ReadLines(letterFile_path).Count();

                for (int i = 0; i < maxLine; i++)
                {
                    startLinesList.Add(int.Parse(sr.ReadLine()));
                }
            }

        }


        /// <summary>
        /// Returns the line in file where searching begins.
        /// </summary>
        /// <returns></returns>
        private int Start_Line()
        {
            if (alphabet.Contains(Word.First().ToString().ToLower()))
            {
                return startLinesList[alphabet.IndexOf(Word.First().ToString().ToLower())];
            }
            else
            {
                return -1;
            }
        }
       
        // Word number is determined by the number of words that start with a same word as the "Word" property.
        /// <summary>
        /// Returns the number of words that need to be searched.
        /// </summary>
        /// <returns></returns>
        private int Words()
        {
            if (Start_Line() != startLinesList.Last())
            {
                return startLinesList[startLinesList.IndexOf(Start_Line()) + 1] - startLinesList[startLinesList.IndexOf(Start_Line())];
            }
            else
            {
                int max_lines = File.ReadLines(Path).Count();
                return max_lines - startLinesList[startLinesList.IndexOf(Start_Line())];
            }
        }

        // Number of tasks is determined by the number of words that need to be searched.
        /// <summary>
        /// Returns number of Tasks to perform in one search.
        /// </summary>
        /// <returns></returns>
        private int Tasks()
        {
            int wordNum = Words();

            if (wordNum <= 100)
            {
                return 1;
            }
            else if (wordNum > 100 && wordNum <= 1000)
            {
                return 2;
            }
            else if (wordNum > 1000 && wordNum <= 5000)
            {
                return 4;
            }
            else if (wordNum > 5000 && wordNum <= 10000)
            {
                return 8;
            }
            else if (wordNum > 10000 && wordNum <= 100000)
            {
                return 10;
            }
            else
            {
                return 12;
            }

        }

        /// <summary>
        /// Method that will be used by multiple Tasks to search for Word.
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="taskRange"></param>
        /// <param name="token"></param>
        private void Word_Search(int iterator, int taskRange, CancellationTokenSource token)
        {

            StreamReader sReader = new StreamReader(Path);

            for (int i = 0; i < (Start_Line() + (iterator * taskRange)); i++)
            {
                sReader.ReadLine();
            }

            for (int i = 0; i < ((iterator * taskRange) + taskRange); i++)
            {
                // Checking if cancellation event happened already.
                if (token.Token.IsCancellationRequested)
                {
                    return;
                }

                string row = sReader.ReadLine();

                if (row != null && row.ToLower() == Word.ToLower())
                {
                    wordFound = true;

                    // Cancelling the search in the case the word is found.
                    token.Cancel();

                    return;
                }
            }
        }

        /// <summary>
        /// Returns true if the word is english.
        /// </summary>
        /// <returns> Returns if the word is english or not.</returns>
        public bool Is_English_Word()
        {
            // Token source through which the cancellation signal will be sent.
            CancellationTokenSource tokensource = new CancellationTokenSource();
            wordFound = false;

            int task_Number = Tasks();
            int word_Number = Words();

            int task_range = (word_Number / task_Number) + (word_Number % task_Number);

            Parallel.For(0, task_Number, i => Word_Search(i, task_range, tokensource));

            Task.WaitAny();

            if (wordFound)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
