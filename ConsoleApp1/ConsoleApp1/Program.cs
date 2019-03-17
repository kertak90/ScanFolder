using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static FileStream fs = new FileStream("FILELIST.txt", FileMode.Create, FileAccess.Write);
        static StreamWriter sw = new StreamWriter(fs);
        static int index = 0;
        static void printDirect(DirectoryInfo dir)
        {
            //Console.WriteLine("***** " + dir.Name + " *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            //Console.WriteLine("Name: {0}", dir.Name);
            //Console.WriteLine("Parent: {0}", dir.Parent);
            //Console.WriteLine("Creation: {0}", dir.CreationTime);
            //Console.WriteLine("Attributes: {0}", dir.Attributes.ToString());
            //Console.WriteLine("Root: {0}", dir.Root);                         //получает корневую часть подкаталога           
        }

        static void printFiles(DirectoryInfo dirFile)
        {
            FileInfo[] subFiles = dirFile.GetFiles();
            //Console.WriteLine("Найдено файлов       {0}:", subFiles.Length);    //вывод количества файлов в данном каталоге            
            foreach (FileInfo f in subFiles)
            {
                index++;
                Console.WriteLine("{0}\t{1} \tFullName: {2}", index, f.CreationTime, f.FullName);
                sw.WriteLine("{0}\t{1} \tFullName: {2}", index, f.CreationTime, f.FullName);
            }
            subFiles = null;
        }

        static void printDirect2(DirectoryInfo dir)
        {
            //index++;
            //Console.WriteLine("\nFullName: {0}", dir.FullName);               //Вывод на экран полного пути до каталога
            DirectoryInfo[] subDirects = dir.GetDirectories();                  //создание массива директорий, dir.GetDirectories() - Возвращает подкаталоги текущего каталога                                           
            //Console.WriteLine("Найдено подкаталогов {0}:", subDirects.Length);  //Вывод на экран длины массива, т.е. количества каталогов по данному адресу    
            printFiles(dir);                                                    //распечатка всех файлов данного каталога
            foreach (DirectoryInfo d in subDirects)                             //перебор всех каталогов и вывод в консоль информации о каждом из них
            {                
                printDirect2(d);                                                //вывод на экран информации о данном каталоге
            }           
            
        }

        static void Main(string[] args)
        {
            //DirectoryInfo dir = new DirectoryInfo(@"C:\С# 1 обучение");         //dir содержит информацию о данной директории
            DirectoryInfo dir = new DirectoryInfo(".");         //dir содержит информацию о данной директории
            printDirect(dir);                                                   //распечатка информации о данной директории
            printDirect2(dir);                                                  //метод создающий дерево каталога
            Console.WriteLine("Дерево файлов сохранено в файл FILELIST.txt\n");
            sw.Close();
            fs.Close();
            Console.ReadLine();                                                 //ожидание нажатия кнопки
        }
    }
}
