using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_c2
{
    public static class Program
    {
        public static string Search_path_choice { get; private set; }
        public static string Words_path_choice { get; private set; }
        public static string Iter_choice { get; private set; }
        public static int Sleep_choice { get; private set; }

        #region Default values

        private static string default_search_path = Paths.files_path + @"ENGall.txt";
        private static string default_word_path = Paths.files_path + @"1000.txt";
        private static int default_sleep = 300;
        private static string default_iter = "1000";

        #endregion

        private static void Control_Print()
        {
            Console.WriteLine("\n\nFile path: " + Words_path_choice);
            Console.WriteLine("Word number: " + Iter_choice);
            Console.WriteLine("Sleep time: " + Sleep_choice + "\n");

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        public static void SaveToFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.ShowDialog();

            string newPath = fileDialog.FileName;
            string oldPath = Paths.GeneratedWords_path;

            File.Copy(oldPath, newPath + ".txt");
        }

        static void Main(string[] args)
        {
            Console.Title = "Word Generator";
            int correct_words = 0;

            ConsoleKeyInfo yn;
            bool ok = false;

            do
            {
                Console.Clear();

                Console.Write("Use default settings? (y/n): ");
                yn = Console.ReadKey();

                if (yn.Key == ConsoleKey.Y)
                {
                    Search_path_choice = default_search_path;
                    Words_path_choice = default_word_path;
                    Iter_choice = default_iter;
                    Sleep_choice = default_sleep;

                    Control_Print();


                }
                else if (yn.Key == ConsoleKey.N)
                {
                    Console.WriteLine("\nChoose your own settings...");
                    SettingsForm settings_f = new SettingsForm(default_word_path, default_iter, default_sleep.ToString());
                    settings_f.ShowDialog();

                    Words_path_choice = settings_f.PathChoice;
                    Iter_choice = settings_f.IterChoice;
                    Sleep_choice = int.Parse(settings_f.TimeChoice);
                    Search_path_choice = default_search_path;

                    Control_Print();
                }
                else
                {
                    Console.WriteLine("\nPlease only input keys 'y' or 'n'. Press any key to continue.");
                    Console.ReadLine();
                }

                try
                {
                    Algorythm.Read_SeedFile(Words_path_choice);
                    ok = true;
                }
                catch (Exception ex)
                {
                    string fileName = Path.GetFileName(Words_path_choice);
                    Console.WriteLine("File by the name " + fileName + " was not found.", ex);
                    Console.WriteLine("Check if the file path is correct. Press any key to continue.");
                    Console.ReadLine();
                }

            } while (yn.Key != ConsoleKey.Y && yn.Key != ConsoleKey.N || ok == false);

            Console.WriteLine("\nPlease wait...\n");
            Console.WriteLine("Word matrix: \n");

            Algorythm.PrintMatrix();

            Console.Write("\nShow words being created? (y/n): ");
            ConsoleKeyInfo choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.Y)
            {
                GeneratorForm gf = new GeneratorForm(Search_path_choice, int.Parse(Iter_choice), Sleep_choice);
                gf.ShowDialog();
            }
            else
            {
                Searcher search = new Searcher(Search_path_choice);
                FileManager fm = new FileManager();
                List<string> generated_words = new List<string>();

                fm.Delete_generated();

                Console.WriteLine("\n\nGenerating words...\n");

                for (int i = 0; i < int.Parse(Iter_choice); i++)
                {
                    search.Word = Algorythm.Generate_Word();
                    bool is_eng = search.Is_English_Word();

                    generated_words.Add(search.Word);

                    if (i == int.Parse(Iter_choice) - 1)
                    {
                        Console.WriteLine(Iter_choice + "/" + Iter_choice);
                    }

                    if (is_eng)
                    {
                        correct_words++;
                        Console.WriteLine(search.Word);
                    }
                }

                fm.AddTo_GeneratedWords(generated_words);

                Console.WriteLine("\nEnglish words generated: " + correct_words + "/" + Iter_choice);

                Console.Write("\nWould you like to save the generated words? (y/n): ");
                ConsoleKeyInfo yesno = Console.ReadKey();

                if (yesno.Key == ConsoleKey.Y)
                {
                    Thread saveThread = new Thread(new ParameterizedThreadStart(p => { SaveToFile(); }));
                    saveThread.SetApartmentState(ApartmentState.STA);
                    saveThread.Start();
                }
            }

            Console.WriteLine("\n\n ~ FIN ~ \n\nPress any key to exit.");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

}
