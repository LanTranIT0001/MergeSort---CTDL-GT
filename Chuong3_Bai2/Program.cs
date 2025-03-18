﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; 

class Program
{   
        static void Merge((int so, int stt)[] input, int left, int mid, int right) //
        {
            var LArr = new (int,int)[mid - left + 1];//
            var RArr = new (int,int)[right - mid];//
            Array.Copy(input, left, LArr, 0, mid - left + 1);
            Array.Copy(input, mid + 1, RArr, 0, right - mid);
            int i = 0, j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == LArr.Length)
                {
                    input[k] = RArr[j]; j++;
                }
                else if (j == RArr.Length)
                {
                    input[k] = LArr[i]; i++;
                }
                else if (LArr[i].Item1 <= RArr[j].Item1)//
                {
                    input[k] = LArr[i]; i++;
                }
                else
                {
                    input[k] = RArr[j]; j++;
                }
            }
        }
        static void MergeSort((int value, int index)[] input, int left, int right)//
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(input, left, mid);
                MergeSort(input, mid + 1, right);
                Merge(input, left, mid, right);
            }
        }
        static void Main(string[] args)
        {
            (int, int)[] arr1 = { (4, 0), (2, 1), (4, 2), (3, 3), (2, 4) };
            Console.WriteLine("Mang chua sap xep:");
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write("({0},{1})", arr1[i].Item1, arr1[i].Item2);
            }
            MergeSort(arr1, 0, arr1.Length - 1);
            Console.WriteLine();
            Console.WriteLine("Mang sau sap xep:");
             for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write("({0},{1})",arr1[i].Item1,arr1[i].Item2);
            }
        }
    }
