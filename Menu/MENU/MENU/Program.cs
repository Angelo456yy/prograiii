using Itinero.Algorithms.Sorting;
using System;
using System.Linq;

class Program
{
  
    public static void BinarySort(int[] arr)
    {
        var binArr = arr.Select(num => Convert.ToString(num, 2).PadLeft(32, '0')).ToArray();
        Array.Sort(binArr);

        for (int i = 0; i < binArr.Length; i++)
        {
            arr[i] = Convert.ToInt32(binArr[i], 2);
        }
    }

  
    public static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

  
    public static void BubbleSort(int[] arr)
    {
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }

   
    public static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }

  
    public static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                QuickSort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                QuickSort(arr, pivot + 1, right);
            }
        }
    }

    private static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[left];
        while (true)
        {
            while (arr[left] < pivot)
            {
                left++;
            }

            while (arr[right] > pivot)
            {
                right--;
            }

            if (left < right)
            {
                if (arr[left] == arr[right]) return right;

                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }
            else
            {
                return right;
            }
        }
    }

 
    public static void Main()
    {
     
        Console.WriteLine("Seleccione el algoritmo de ordenamiento:");
        Console.WriteLine("1. Ordenamiento Binario");
        Console.WriteLine("2. QuickSort");
        Console.WriteLine("3. Ordenamiento por Inserción");
        Console.WriteLine("4. Ordenamiento por Intercambio (Bubble Sort)");

        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese los números separados por espacios:");
        string input = Console.ReadLine();
        int[] arr = input.Split(' ').Select(int.Parse).ToArray();

        switch (choice)
        {
            case 1:
                Console.WriteLine("Ordenando con Ordenamiento Binario...");
                BinarySort(arr);
                Console.WriteLine("Array ordenado:");
                PrintArray(arr);
                break;

            case 2:
                Console.WriteLine("Ordenando con QuickSort...");
                QuickSort(arr, 0, arr.Length - 1);
                Console.WriteLine("Array ordenado:");
                PrintArray(arr);
                break;
            case 3:
                Console.WriteLine("Ordenando con Ordenamiento por Inserción...");
                InsertionSort(arr);
                Console.WriteLine("Array ordenado:");
                PrintArray(arr);
                break;

            case 4:

                Console.WriteLine("Ordenando con Ordenamiento por Intercambio...");
                BubbleSort(arr);
                Console.WriteLine("Array ordenado:");
                PrintArray(arr);
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}

