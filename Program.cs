using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSort
{
    class Program
    {
        static void QuickSort(int[] data, int left, int right)
        {
            //Välj det tal som avgör indelningen i "högre" och "lägre"
            int pivot = data[(left + right) / 2];
            //Välj det område som skall bearbetas
            int leftHold = left;
            int rightHold = right;

            //Så länge vi har ett område kvar
            while (leftHold < rightHold)
            {
                //Hitta ett tal på vänster sida som skall ligga i den "högre" delen
                while ((data[leftHold] < pivot) && (leftHold <= rightHold)) leftHold++;
                //Hitta ett tal på höger sida som skall ligga i den "lägre" delen
                while ((data[rightHold] > pivot) && (rightHold >= leftHold)) rightHold--;

                //Om vi nu har ett område kvar så skall talen på 
                //vänster kant och höger kant byta plats
                if (leftHold < rightHold)
                {
                    //Byta plats
                    int tmp = data[leftHold];
                    data[leftHold] = data[rightHold];
                    data[rightHold] = tmp;
                    //Minska området om vi flyttat två pivot-tal
                    if (data[leftHold] == pivot && data[rightHold] == pivot)
                        leftHold++;
                }
            }
            if (left < leftHold -1) QuickSort(data, left, leftHold - 1);
            if (right > rightHold + 1) QuickSort(data, rightHold + 1, right);
        }

        static int[] GenerateData(int size)
        {
            Random rnd = new Random();
            int[] data = new int[size];

            for (int i = 0; i < data.Length; i++)
                data[i] = rnd.Next(data.Length);

            return data;
        }

        static void Main(string[] args)
        {
            int[] sizes = new int[8000];
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Random random = new Random();
            for (int i = 0; i < sizes.Length; i++)
            {
                sizes[i] = random.Next(1, 101);
                int[] data = GenerateData(sizes[i]);
                Console.WriteLine("Sorterar slumpad data");
                DateTime startTid = DateTime.Now;
                QuickSort(data, 0, data.Length - 1);
                TimeSpan deltaTid = DateTime.Now - startTid;
                Console.WriteLine("Det tog {0:0.00} ms att sortera.\n", deltaTid.TotalMilliseconds);

                Console.WriteLine("Sorterar redan sorterad data");
                startTid = DateTime.Now;
                QuickSort(data, 0, data.Length - 1);
                deltaTid = DateTime.Now - startTid;
                Console.WriteLine("Det tog {0:0.00} ms att sortera.\n", deltaTid.TotalMilliseconds);
            }
             watch.Stop();
            long ts = watch.ElapsedMilliseconds;
            Console.WriteLine("RunTime " + ts);
        }
    }
}
