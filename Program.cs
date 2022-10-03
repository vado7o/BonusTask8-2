// Задача со звёздочкой2: Задайте одномерный массив из N элементов, заполненный случайными числами. 
// Необходимо определить, в какой последовательности заданы элементы массива: по возрастанию, по убыванию, хаотично, или все элементы одинаковы.

Console.Clear();
Console.WriteLine("Программа, показывающая последовательность расположения элементов внутри массива.");

int size = 0;

while (true)
{
    Console.Write("\nНапишите - из скольки элементов должен состоять массив? : ");
    if (int.TryParse(Console.ReadLine(), out int number))
    {
        if (number > 0)
        {
            size = number;
            break;
        }
        else Console.WriteLine("Некорректно указано количество элементов первого массива!\n");
    }
    else Console.WriteLine("Некорректно указано количество элементов первого массива!\n");
}

int[] array = FillArray(size, 1, size + 1);
Console.Write("\nCгенерированный массив - ");
PrintArray(array);
Console.WriteLine("\nЭлементы массива расположены: " + DefineOrder(array));

int[] FillArray(int size, int min, int max)
{
    int[] filledArray = new int[size];
    for (int index = 0; index < size; index++)
    {
        filledArray[index] = new Random().Next(min, max);
    }
    return filledArray;
}

void PrintArray(int[] array)
{
    Console.Write(" [" + String.Join(", ", array) + "]");
}

string DefineOrder(int[] array)
{
    int current = array[0];
    int more = 0;
    int less = 0;
    int equal = 0;
    for(int index = 1; index < size; index++)
    {
        if(more>0 && less>0 || more>0 && equal>0 || less>0 && equal>0)
        {
            break;
        }
        if(array[index] > current)
        {
            more++;
        }
        else if(array[index] < current)
        {
            less++;
        }
        else
        {
            equal++;
        }
        current = array[index];
    }
    if(more == size - 1) return "по возрастанию";
    else if(less == size - 1) return "по убыванию";
    else if(equal == size - 1) return "все элементы равны";
    else return "хаотично";
}