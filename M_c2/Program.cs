using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_c2
{
    enum Stanje { START_LETTER_STATE, NEXT_LETTER_STATE }

    class Program
    {
        private static int FIRST_LETTER_ROW = 27;

        private static List<char> lettersList = new List<char> { 'a','b','c','d','e','f','g','h','i',
            'j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z' };

        /*\
         * Matrix indexes from 0 to 25 (rows and columns) represent letters of the english aphabet.
         * 
         * Index 26 (row and columns) represent the "\0", the end of the word sign.
         * 
         * Row index 27 represents the sum of the numbers in that row.
         * 
         * Column index 27 represents number of words where that rows letter was the first letter of the word.
        \*/

        /// <summary>
        /// Seed word decomposition matrix.
        /// </summary>
        private static int[,] matrix = new int[28, 28];

        /// <summary>
        /// Fills the word matrix with letters.
        /// </summary>
        /// <param name="fileName"></param>
        private static void Read_SeedFile(string filepath)
        {
            StreamReader seedFile = new StreamReader(filepath);

            int MAX_LINES = File.ReadLines(filepath).Count();

            Stanje stanje = Stanje.START_LETTER_STATE;

            string slovo = "";
            string prev_slovo = "";
            string rijec = "";

            if (seedFile == null) return;

            for (int i = 0; i < MAX_LINES; i++)
            {
                rijec = seedFile.ReadLine();

                if (rijec.All(char.IsLetter))
                {
                    for (int j = 0; j < rijec.Length; j++)
                    {
                        slovo = rijec[j].ToString().ToLower();

                        switch (stanje)
                        {
                            case Stanje.START_LETTER_STATE:

                                // Ako 'slovo' nije zadnje slovo u redu.
                                if (j != rijec.Length - 1)
                                {
                                    prev_slovo = slovo;

                                    matrix[FIRST_LETTER_ROW, GetIndex(slovo)]++;

                                    stanje = Stanje.NEXT_LETTER_STATE;
                                }

                                break;

                            case Stanje.NEXT_LETTER_STATE:

                                // Ako je 'slovo' zadnje slovo u redu.
                                if (j == rijec.Length - 1)
                                {
                                    matrix[GetIndex(slovo), 26]++;

                                    stanje = Stanje.START_LETTER_STATE;
                                }
                                else
                                {
                                    matrix[GetIndex(prev_slovo), GetIndex(slovo)]++;

                                    prev_slovo = slovo;
                                }

                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            Calculate_Sums(matrix);
        }

        /// <summary>
        /// Gets index of a given letter from the 'lettersList'.
        /// </summary>
        /// <param name="slovo"></param>
        /// <returns></returns>
        private static int GetIndex(string slovo)
        {
            int index = 0;

            for (int i = 0; i < lettersList.Count; i++)
            {
                if (lettersList[i].ToString() == slovo)
                {
                    index = lettersList.IndexOf(lettersList[i]);
                }
            }
            return index;
        }

        /// <summary>
        /// Sums up rows and collumns of the matrix.
        /// </summary>
        /// <param name="matrix"></param>
        private static void Calculate_Sums(int[,] matrix)
        {
            // Sumira zadnji redak matrice (znamenka u zadnjem retku i zadnjem stupcu).
            for (int i = 0; i < 27; i++)
            {
                matrix[27, 27] += matrix[27, i];

                // Sumira sve clanove svakog retka matrice u pripadajuci zadnji stupac.
                for (int j = 0; j < 27; j++)
                {
                    matrix[i, 27] += matrix[i, j];
                }
            }
        }

        /// <summary>
        /// Generates new letter.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static int Select_Letter(int row)
        {
            Random rand = new Random();
            Random rand2 = new Random();

            int sum = 0;
            int maxMatrix = matrix[row, 27] + 1;

            // Generates maximum value for letter selection (roulette wheel selection - look it up).
            int max_val = rand.Next(0, maxMatrix);

            // Generates starting column index for letter selection.
            int selected_column = rand2.Next(0, 26);

            while (true)
            {
                // Adding the value of the matrix field.
                int add = matrix[row, selected_column];
                sum += add;

                // Checking if selection critera is met.
                if (sum >= max_val)
                {
                    return selected_column;
                }

                // When column count comes to the column end, it starts over.
                if (++selected_column >= 27)
                {
                    selected_column = 0;
                }
            }
        }

        /// <summary>
        /// Generates new word.
        /// </summary>
        /// <returns></returns>
        private static string Generate_Word()
        {
            Random rand = new Random();

            int new_firstLetter_ROW = rand.Next(0, 26);

            while (matrix[27, new_firstLetter_ROW] == 0)
            {
                rand = new Random();
                new_firstLetter_ROW = rand.Next(0, 26);
            }

            string new_word = lettersList[new_firstLetter_ROW].ToString();
            int counter = 0;

            while (true)
            {
                int letter_index = Select_Letter(new_firstLetter_ROW);
                counter++;

                if (letter_index == 26 || counter > 20)
                {
                    counter = 0;
                    return new_word;
                }
                else
                {
                    new_word += lettersList[letter_index].ToString();

                    new_firstLetter_ROW = letter_index;
                }
            }
        }

        /*\
         *  dat korisniku da odabere file *u file loaderu* nek se otvori w-forma jbg
         *  ili run default file
         *  
         *  prikazat matricu
         *  
         *  pitat krosnika oce li gledat sve rijeci - *u novoj konzoli*
         *  ili samo prikazat tocne rijeci
         *  
         *  pitat korisnika za broj iteracija 
         *  ispisat broj iteracija i "Generating..." ako generiranje jos traje
         *  
         *  statistike trazenja, vrijeme, genenrirane rijeci, prosjecno vrijeme generiranja rijeci
        \*/
        
        static void Main(string[] args)
        {
            Console.Title = "Word Generator";

            string search_path_choice = "";
            string words_path_choice = "";
            string iter_choice = "";
            int sleep_choice = 0;

            int correct_words = 0;

            #region Default values

            string default_search_path = Paths.files_path + @"1000.txt";
            string default_word_path = Paths.files_path + @"1000.txt";
            int default_sleep = 300;
            string default_iter = "1000";

            #endregion

            ConsoleKeyInfo yn;
            bool ok = false;

            do
            {
                Console.Clear();

                Console.Write("Use default settings? (y/n): ");
                yn = Console.ReadKey();

                if (yn.Key == ConsoleKey.Y)
                {
                    search_path_choice = default_search_path;
                    words_path_choice = default_word_path;
                    iter_choice = default_iter;
                    sleep_choice = default_sleep;

                    Console.WriteLine("\n\nFile path: " + words_path_choice);
                    Console.WriteLine("Iteration number: " + iter_choice);
                    Console.WriteLine("Sleep time: " + sleep_choice + "\n");
                }
                else if (yn.Key == ConsoleKey.N)
                {
                    Console.WriteLine("\nChoose your own settings...");
                    SettingsForm settings_f = new SettingsForm(default_word_path, default_iter, default_sleep.ToString());
                    settings_f.ShowDialog();

                    words_path_choice = settings_f.PathChoice;
                    iter_choice = settings_f.IterChoice;
                    sleep_choice = int.Parse(settings_f.TimeChoice);
                    search_path_choice = default_search_path;

                    Console.WriteLine("\nFile path: " + words_path_choice);
                    Console.WriteLine("Iteration number: " + iter_choice);
                    Console.WriteLine("Sleep time: " + sleep_choice + "\n");
                }
                else
                {
                    Console.WriteLine("\nPlease only input keys 'y' or 'n'. Press enter to continue.");
                    Console.ReadLine();
                }

                Console.WriteLine("Press any key to continue.");
                Console.ReadLine();

                try
                {
                    Read_SeedFile(words_path_choice);
                    ok = true;
                }
                catch (Exception ex)
                {
                    string fileName = Path.GetFileName(words_path_choice);
                    Console.WriteLine("File by the name " + fileName + " was not found.", ex);
                    Console.WriteLine("Check if the file path is correct. Press any key to continue.");
                    Console.ReadLine();
                }

            } while (yn.Key != ConsoleKey.Y && yn.Key != ConsoleKey.N || ok == false);

            Console.WriteLine("\nPlease wait...\n");
            Console.WriteLine("Word matrix: \n");

            PrintMatrix();

            Console.Write("\nShow words being created? (y/n): ");
            ConsoleKeyInfo choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.Y)
            {
                Searcher search = new Searcher(search_path_choice);
                FileManager fm = new FileManager();

                for (int i = 0; i < int.Parse(iter_choice); i++)
                {
                    search.Word = Generate_Word();
                    bool is_eng = search.Is_English_Word();
                    Console.Write(search.Word);

                    if (is_eng)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("{0,20}", " IS ENGLISH");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("{0,20}", " NOT ENGLISH");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.WriteLine();
                    Thread.Sleep(sleep_choice);
                }
            }
            else
            {
                Searcher search = new Searcher(search_path_choice);
                FileManager fm = new FileManager();

                Console.WriteLine("\nGenerating...\n");

                for (int i = 0; i < int.Parse(iter_choice); i++)
                {
                    search.Word = Generate_Word();
                    bool is_eng = search.Is_English_Word();

                    if (i % 500 == 0)
                    {
                        Console.WriteLine(i + "/" + iter_choice + "...");
                    }
                    else if (i == int.Parse(iter_choice) - 1)
                    {
                        Console.WriteLine(iter_choice + "/" + iter_choice);
                    }

                    if (is_eng)
                    {
                        correct_words++;
                        Console.WriteLine(search.Word);
                    }
                }
            }

            Console.WriteLine("\nEnglish words generated: " + correct_words);

            Console.WriteLine("\n ~ FIN ~ ");
            Console.ReadLine();
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    Console.Write(matrix[i, j] + " " + "\t");
                }
                Console.WriteLine();
            }
        }
    }

}
