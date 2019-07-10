using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_Organizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please drag and drop the root folder into the app.");

            // Validating the input
            if (args.Length == 0 || String.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Invalid folder.");
            }

            
            try
            {
                // Getting the root path and name
                String root = args[0];

                //Validating the directory
                if (Directory.Exists(root))
                {

                    // Getting the path and directory name separetely
                    String rootName = Path.GetFileName(root);
                    String rootPath =Path.GetDirectoryName(root);

                    // Creating the new directory
                    String newDirectory = rootPath + "/" + rootName + " - Organized";                   
                    Directory.CreateDirectory(newDirectory);

                    // Looping through every sub-directory
                    string[] dirs = Directory.GetDirectories(root);
                    foreach (string dir in dirs)
                    {
                        // Looping through every file in the sub-directories
                        string[] files = Directory.GetFiles(dir);
                        foreach (string file in files)
                        {
                            // Copying the file to the new folder
                            String newFile = newDirectory + "/" + Path.GetFileName(dir) + "___" + Path.GetFileName(file);
                            Console.WriteLine("Creating: " + newFile);
                            File.Copy(file, newFile);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed, please try again: {0}", e.ToString());
            }

            // Holds the window
            Console.Write("Done!");
            Console.ReadLine();
        }
    }
}
