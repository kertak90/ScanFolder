using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ScanFolder
{
    static class ScanFolder
    {
        static FileStream fs;
        static StreamWriter sw;
        static int index = 0;                                                   //Индекс числа файлов

        public static void StartScan(string path)
        {
            string filename = path + "\\FILELIST.txt";
            fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(fs);
            DirectoryInfo dir = new DirectoryInfo(path);                        //dir содержит информацию о данной директории
            DateTime today = DateTime.Now;

            sw.WriteLine("Дата создания списка:\t{0}", today);
            sw.WriteLine("№\tДата изменения \t\tПуть до файла");                                                    //распечатка информации о данной директории
            printDirect(dir);                                                   //метод создающий дерево каталога                                 
        }     
        
        static ScanFolder()
        {

        }

        private static void printFiles(DirectoryInfo dirFile)
        {
            FileInfo[] subFiles = dirFile.GetFiles();         
            foreach (FileInfo f in subFiles)
            {
                index++;                
                sw.WriteLine("{0}\t{1} \t{2}", index, f.CreationTime, f.FullName);
            }
            subFiles = null;
        }

        private static void printDirect(DirectoryInfo dir)
        {            
            DirectoryInfo[] subDirects = dir.GetDirectories();                  //создание массива директорий, dir.GetDirectories() - Возвращает подкаталоги текущего каталога                                           
            printFiles(dir);                                                    //распечатка всех файлов данного каталога
            foreach (DirectoryInfo d in subDirects)                             //перебор всех каталогов данного каталога
            {
                printDirect(d);                                                 //Снова вызываем метод который распечатает содержимое папки
            }
        }

        public static void Close()
        {
            sw.Close();
            fs.Close();
        }
    }
}
