﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1a o = new Class1a();
            o[0] = 10;
            o[1] = 20;
            o[2] = 30;

            for (int i = 0; i < o.Length; i++)
            {
                Console.WriteLine(o[i]);
            }

            Console.ReadLine();
        }
        static void Main1(string[] args)
        {
            Class1 o = new Class1(3, 100);
            o[100] = 10;
            o[101] = 20;
            o[102] = 30;

            Console.WriteLine(o[100]);
            Console.ReadLine();
        }
    }
    class Class1a
    {
        private int[] arr= new int[3];
        public int this[int i]
        {
            get 
            {
                return arr[i];
            }
            set 
            {
                arr[i] = value;
            }
        }
        public int Length
        {
            get 
            {
                return arr.Length;
            }
        }
    }

    public class Class1
    {
        private int[] arr;
        int start;
        public Class1(int Size, int start)
        {
            this.start = start;
            arr = new int[Size];
        }
        public int this[int index]
        {
            get
            {
                return arr[index - start];
            }
            set
            {
                arr[index - start] = value;
            }
        }

    }
}
