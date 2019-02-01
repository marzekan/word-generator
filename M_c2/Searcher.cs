using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_c2
{
    /// <summary>
    /// Contains methods for determening if the word is english.
    /// </summary>
    public sealed class Searcher
    {

        public string Word { get; set; }

        private string Path { get; set; }


        List<int> startLinesList = new List<int>();

        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        bool wordFound = false;


        public Searcher(string path)
        {
            Path = path;

            // PATH je od fajla koji se radi sadrži pocetne linije slova.
            StreamReader sr = new StreamReader(path);

            for (int i = 0; i < File.ReadLines(path).Count(); i++)
            {
                startLinesList[i] = int.Parse(sr.ReadLine());
            }
        }


        /// <summary>
        /// Returns the line where letters that start with 'first_letter' begin.
        /// </summary>
        /// <param name="fist_letter"></param>
        /// <returns></returns>
        private int Start_Line()
        {
            if (alphabet.Contains(Word.First()))
            {
                return startLinesList[alphabet.IndexOf(Word.First())];
            }
            else
            {
                return -1;
            }
        }
        
        // OVO NE RADI

        /// <summary>
        /// Returns the number of words that start with a given letter.
        /// </summary>
        /// <returns></returns>
        private int Number_of_words()
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

        
        private void Word_Search(int iterator)
        {
            StreamReader sr = new StreamReader(Path);

            for (int i = 0; i < 666; i++)
            {

            }
        }

        public bool Is_English_Word()
        {
            return false;
        }


    }
}
