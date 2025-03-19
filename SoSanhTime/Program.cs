using System;

class Program
    {
        static void Merge(int[] input,int left,int mid,int right)
        {
            int[] LArr = new int[mid - left + 1]; 
            int[] RArr = new int[right - mid]; 
            Array.Copy(input, left, LArr, 0, mid - left + 1);
            Array.Copy(input, mid + 1, RArr, 0, right - mid);
            int i = 0, j = 0;
            for(int k = left; k < right + 1; k++)
            {
                if (i == LArr.Length)
                {
                    input[k] = RArr[j]; j++;
                }
                else if (j == RArr.Length)
                {
                    input[k] = LArr[i];i++;
                }
                else if (LArr[i] <= RArr[j])
                {
                    input[k] = LArr[i]; i++;
                }
                else
                {
                    input[k] = RArr[j]; j++;
                }
            }
        }
        static void MergeSort(int[] input,int left, int right)
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
            Console.WriteLine("Nhap so phan tu cua mang: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            //Random rd = new Random();

            for(int i = 0; i < n; i++)
            {
                //arr[i] = i;
                //arr[i] = rd.Next(100);
                arr[i] = n - i;
            }    

            Console.WriteLine("\n Mang chua sap xep: ");
            Console.WriteLine(string.Join(" ", arr));

            Timing T = new Timing();
            T.startTime();
            for(int i = 0; i < 1000000; i++)
            {
                MergeSort(arr, 0, arr.Length - 1);
            }
            T.StopTime();
            
            Console.WriteLine("---------------------------------------- ");
            Console.WriteLine("\n Mang da sap xep: ");
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine("\n Duration: {0} ms", T.Result().TotalMilliseconds/1000000);
        }
    }
