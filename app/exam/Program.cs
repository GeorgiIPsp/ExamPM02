
string nameFile;




void InputFileName()
{
    while (true)
    {
        Console.Write("Введите имя файла: ");
        nameFile = Console.ReadLine();
        if (!string.IsNullOrEmpty(nameFile.Trim()))
        {
            using (StreamWriter sw = new StreamWriter(nameFile + ".txt"))
            {
                using (StreamReader reader = new StreamReader("route.txt"))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {

                        sw.WriteLine(line);
                        line = reader.ReadLine();
                    }
                }
            }
            
            break;
        }
        else
        {
            Console.WriteLine("Имя файла не может быть пустым!");
        }
    }
}
int[] numbers = new int[3];
void InputNumberRoute()
{
    for (int i = 0; i < 2; i++)
    {
        try
        {

            while (true)
            {
                Console.Write($"Введите {i + 1} - е число: ");
                string number = Console.ReadLine();
                if (!string.IsNullOrEmpty(number))
                {

                    if (int.TryParse(number, out numbers[i]))
                    {

                        if (numbers[i] > 9 || numbers[i] < 1)
                        {
                            Console.WriteLine("Неверный номер точки. Минимальная: 1, а максимальная: 9.");
                        }
                        else if (numbers[i] == 0)
                        {
                            Console.WriteLine("Выход из программы");
                            return;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Точка не может быть пустой!");
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex);
        }
    }
}


InputFileName();
InputNumberRoute();

double[] ints = new double[15];
using (StreamReader reader = new StreamReader(nameFile + ".txt"))
{
    int i = 0;
    string line = reader.ReadLine();
    while (line != null)
    {
        ints[i] = double.Parse(line);
        i++;
        line = reader.ReadLine();
    }
}
double[,] matrixresult = new double[9, 9];
double[,] matrix = new double[,]
{
    {double.MaxValue,ints[0],double.MaxValue,double.MaxValue,ints[8],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue },
    {ints[0],double.MaxValue,ints[1],double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue},
    {double.MaxValue,double.MaxValue,double.MaxValue,ints[2],double.MaxValue,double.MaxValue,double.MaxValue,ints[11],double.MaxValue},
    {double.MaxValue,double.MaxValue,ints[2],double.MaxValue,ints[3],double.MaxValue,ints[9],double.MaxValue,double.MaxValue},
    {ints[8],double.MaxValue,double.MaxValue,ints[3],double.MaxValue,ints[4],double.MaxValue,double.MaxValue,double.MaxValue},
    {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,ints[4],double.MaxValue,ints[5],double.MaxValue,ints[11]},
    {double.MaxValue,double.MaxValue,double.MaxValue,ints[9],double.MaxValue,ints[5],double.MaxValue,ints[6],double.MaxValue},
    {double.MaxValue,double.MaxValue,ints[11],double.MaxValue,double.MaxValue,double.MaxValue,ints[6],double.MaxValue,ints[7]},
    {double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,double.MaxValue,ints[10],double.MaxValue,ints[7],double.MaxValue},

};


for(int i = 0;i < 11;i++)
{
    Console.WriteLine(ints[i]);
}
int index = 0;
for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        if (matrix[i, j] == 1)
        {
            matrix[i, j] = ints[index];

            index++;
        }
    }
    Console.WriteLine();
}
for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {


            Console.Write(matrix[i, j] + ", ") ;

    }
    Console.WriteLine();
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
matrixresult = Floyds.Floyd(matrix);
for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        Console.Write(matrixresult[i, j] + " ");
    }
    Console.WriteLine();
}
double matrixx = matrixresult[numbers[0] - 1, numbers[1] - 1];
Console.WriteLine($"\nКратчайшее растояние между точками: {numbers[0]} и {numbers[1]} = {matrixx}");