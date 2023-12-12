using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace readingTesting
{
    internal class Program
    {
        static string path = @"C:\Users\Huzyfa\source\repos\readingTesting\readingTesting\database.txt";
        static string[,] Students;
        static void Main(string[] args)
        {
            pStudents();
            Console.ReadKey();
        }
        static void GetStudents()
        {
            int TotalRows=File.ReadAllLines(path).Length;
            Students = new string[TotalRows,4];
            string Line = "";
            StreamReader sr=new StreamReader(path);
            int Row = 0;
            while ((Line=sr.ReadLine())!=null)
            {
                string[] temp=Line.Split(',');
                for (int i = 0; i < temp.Length; i++)
                {
                    Students[Row,i] = temp[i];
                }
                Row++;
            }


        }
        static void pStudents()
        {
            GetStudents();
            for(int i = 0;i < Students.GetLength(0); i++)
            {
                for (int j = 0; j < Students.GetLength(1); j++)
                {
                    Console.Write(Students[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
