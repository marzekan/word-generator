﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_c2
{
    /// <summary>
    /// Contains methods for managing word files (of type .txt).
    /// </summary>
    public static class FileManager
    {
        /// <summary>
        /// Contains numbers where each letter of the English alphabet begins in the file that contains english words.
        /// </summary>
        static List<int> firstLetterList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Gets the line number of each letter in the english alphabet.
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        private static List<int> Get_LetterLines(string file_path)
        {
            firstLetterList.Clear();

            StreamReader sr = new StreamReader(file_path);

            for (int i = 0; i < File.ReadLines(file_path).Count(); i++)
            {
                string r = sr.ReadLine().ToLower();

                if (r.First() == 'a' && firstLetterList[0] == 0)
                {
                    firstLetterList[0] = i;
                }
                else if (r.First() == 'b' && firstLetterList[1] == 0)
                {
                    firstLetterList[1] = i;
                }
                else if (r.First() == 'c' && firstLetterList[2] == 0)
                {
                    firstLetterList[2] = i;
                }
                else if (r.First() == 'd' && firstLetterList[3] == 0)
                {
                    firstLetterList[3] = i;
                }
                else if (r.First() == 'e' && firstLetterList[4] == 0)
                {
                    firstLetterList[4] = i;
                }
                else if (r.First() == 'f' && firstLetterList[5] == 0)
                {
                    firstLetterList[5] = i;
                }
                else if (r.First() == 'g' && firstLetterList[6] == 0)
                {
                    firstLetterList[6] = i;
                }
                else if (r.First() == 'h' && firstLetterList[7] == 0)
                {
                    firstLetterList[7] = i;
                }
                else if (r.First() == 'i' && firstLetterList[8] == 0)
                {
                    firstLetterList[8] = i;
                }
                else if (r.First() == 'j' && firstLetterList[9] == 0)
                {
                    firstLetterList[9] = i;
                }
                else if (r.First() == 'k' && firstLetterList[10] == 0)
                {
                    firstLetterList[10] = i;
                }
                else if (r.First() == 'l' && firstLetterList[11] == 0)
                {
                    firstLetterList[11] = i;
                }
                else if (r.First() == 'm' && firstLetterList[12] == 0)
                {
                    firstLetterList[12] = i;
                }
                else if (r.First() == 'n' && firstLetterList[13] == 0)
                {
                    firstLetterList[13] = i;
                }
                else if (r.First() == 'o' && firstLetterList[14] == 0)
                {
                    firstLetterList[14] = i;
                }
                else if (r.First() == 'p' && firstLetterList[15] == 0)
                {
                    firstLetterList[15] = i;
                }
                else if (r.First() == 'q' && firstLetterList[16] == 0)
                {
                    firstLetterList[16] = i;
                }
                else if (r.First() == 'r' && firstLetterList[17] == 0)
                {
                    firstLetterList[17] = i;
                }
                else if (r.First() == 's' && firstLetterList[18] == 0)
                {
                    firstLetterList[18] = i;
                }
                else if (r.First() == 't' && firstLetterList[19] == 0)
                {
                    firstLetterList[19] = i;
                }
                else if (r.First() == 'u' && firstLetterList[20] == 0)
                {
                    firstLetterList[20] = i;
                }
                else if (r.First() == 'v' && firstLetterList[21] == 0)
                {
                    firstLetterList[21] = i;
                }
                else if (r.First() == 'w' && firstLetterList[22] == 0)
                {
                    firstLetterList[22] = i;
                }
                else if (r.First() == 'x' && firstLetterList[23] == 0)
                {
                    firstLetterList[23] = i;
                }
                else if (r.First() == 'y' && firstLetterList[24] == 0)
                {
                    firstLetterList[24] = i;
                }
                else if (r.First() == 'z' && firstLetterList[25] == 0)
                {
                    firstLetterList[25] = i;
                }
            }

            return firstLetterList;
        }

        /// <summary>
        /// Writes starting lines from GettingLetterLines to .txt file.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="filename"></param>
        public static void Write_StartLetters(string filepath, string filename)
        {
            if (!File.Exists(filepath))
            {
                File.Create(@"E:\Projects\C# repos\Word Generator\files\files-info\" + filename + "-ll.txt");
            }

            using (TextWriter tw = new StreamWriter(@"E:\Projects\C# repos\Word Generator\files\files-info\" + filename + "-ll.txt"))
            {
                for (int i = 0; i < firstLetterList.Count; i++)
                {
                    tw.WriteLine(firstLetterList[i]);
                }
            }
        }


        /// <summary>
        /// Adds every new generated word to single text file.
        /// </summary>
        /// <param name="word"> Word generated by an algorithm.</param>
        public static void AddTo_GeneratedWords(string word)
        {
            if (!File.Exists(@"E:\Projects\C# repos\Word Generator\files\new_words\generated.txt"))
            {
                File.Create(@"E:\Projects\C# repos\Word Generator\files\new_words\generated.txt");
            }

            using (TextWriter tw = new StreamWriter(@"E:\Projects\C# repos\Word Generator\files\new_words\generated.txt"))
            {
                tw.WriteLine(word);
            }
        }
    }
}