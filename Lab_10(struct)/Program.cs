using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10_struct_
{
    struct STUDENT : IComparable
    {
        string name;
        byte   numOfGroup;
        int[]  appraisans;

        public STUDENT(string name, byte numOfGroup, params int[] appraisans)
        {
            this.name       = name;
            this.numOfGroup = numOfGroup;
            this.appraisans = new int[5];
            for (int i = 0; i < 5; i++)
            {
                this.appraisans[i] = appraisans[i];
            }
        }
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        public float AvarageScore
        {
            get
            {
                int sum = 0;
                foreach (int item in appraisans)
                {
                    sum += item;
                }
                return sum / 5;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj is STUDENT)
            {
                STUDENT temp = (STUDENT)obj;
                if (this.numOfGroup > temp.numOfGroup) return 1;
                if (this.numOfGroup < temp.numOfGroup) return -1;
                return 0;
            }
            else {
                throw new Exception("Невозмодно преобразовать тип" + obj.GetType().Name + "к типу STUDENT");
            }
            

        }

        public override string ToString()
        {
            return "ФИО: " + name + " Номер групп: " + numOfGroup;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int COUNT = 10;
            STUDENT[] Class = new STUDENT[COUNT];

            Console.WriteLine("Введите имена 10 студентов: ");
            for (int i = 0; i < COUNT; i++)
            {
                Console.Write("Имя студента №" + (i + 1) + ":");
                string name = Console.ReadLine();

                Console.Write("Номер группы: ");
                byte numOfGroup = Convert.ToByte(Console.ReadLine());

                Console.WriteLine("Введите 5 оценок: ");
                int[] Arr  = new int[5];
                Random rnd = new Random();
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("[" + (j + 1) + "] = ");
                    Arr[j] = rnd.Next() % 10;   //тест
                    Console.WriteLine(Arr[j]); // тест
                    //Arr[j] = Convert.ToInt32(Console.ReadLine());
                }

                Class[i] = new STUDENT(name, numOfGroup, Arr) ;
            } //Input data

            Array.Sort(Class);

            Console.WriteLine("Вывод студентов со средним баллом выше 4.0");
            bool flag = true;
            foreach (STUDENT item in Class)
            {
                if (item.AvarageScore > 8.0)
                {
                    flag = false;
                    Console.WriteLine(item.ToString());
                }
            }

            if (flag) {
                Console.WriteLine("Таких студентов нет");
            }

            Console.Read();

        } // Main()
    } //class Programm
} // namespace
