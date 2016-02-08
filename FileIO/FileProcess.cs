using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WebsiteClass;

namespace FileIO
{
    /// <summary>
    /// 
    /// </summary>
    public static class FileProcess
    {
        /// <summary>
        /// saves the count of websites and their urls into a file
        /// </summary>
        /// <param name="websites">the list of websites to be saves</param>
        /// <param name="fileName">the file that is to be saved to</param>
        public static void SaveWebsites(List<Website> websites, string fileName)
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.Create));
            writer.Write(websites.Count);
            foreach (Website website in websites)
            {
                writer.Write(website.ToString());
            }
            writer.Close();
        }

        /// <summary>
        /// loads the website urls from a file and converst them to Website objects and adds them to an existing list of Website objects
        /// </summary>
        /// <param name="previousWebsites">a list of Website objects that is to be added to</param>
        /// <param name="nameFile">the file that is to be loaded from</param>
        /// <returns>a list of website objects that contains the list that was inserted into the function with the loaded website objects added</returns>
        public static List<Website> LoadWebsites(List<Website> previousWebsites, string nameFile)
        {
            if (!File.Exists(nameFile))
            {
                FileStream file = File.Create(nameFile);
                file.Close();
            }
            else {
                try {
                    BinaryReader reader = new BinaryReader(new FileStream(nameFile, FileMode.Open));
                    int number = reader.ReadInt32();
                    for (int i = 0; i < number; i++)
                    {
                        string inputData = reader.ReadString();
                        previousWebsites.Add(new Website(inputData));
                    }
                    reader.Close();
                }
                catch (Exception) { }

            }
            return previousWebsites;
        }
    }
}
