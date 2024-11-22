using System.Runtime.CompilerServices;
using TeamProjectes;
using System;


class Program
{
    static void Main()
    {
        //1
        ResearchTeam researchTeam = new ResearchTeam(
            "Исследнование пещер", "Золотоискатели", 22869, TimeFarme.TwoYears,
            new Paper[]
            {
                new Paper("Йоооу", new Person("Мага","Барашка", new DateTime(1983,3,1)), new DateTime(2018,1,5)),
                new Paper("АЙАЙАЙ", new Person ("Кака", "WASD", new DateTime(1999,9,9)), new DateTime(2023,2,3)),
                new Paper("Тюль", new Person("Акак","QWERTY", new DateTime(1290,10,10)), new DateTime(2020,3,2))
            }
            );
        //SHOOOORT
        Console.WriteLine("Краткая инфа о ResearchTeam: ");
        Console.WriteLine(researchTeam.ToShotrString());
        //10
        Console.WriteLine("Year timeframe: " + researchTeam[TimeFarme.Year]);
        Console.WriteLine("TwoYears timeframe: " + researchTeam[TimeFarme.TwoYears]);
        Console.WriteLine("Long timeframe: " + researchTeam[TimeFarme.Long]);
        //11
        researchTeam.Nameisled = "Исследование квантовых вычислений барашек";
        researchTeam.NameOrganiz = "Laba kloak";
        researchTeam.RegNum = 67890;
        researchTeam.Timeframe = TimeFarme.Long;
        Console.WriteLine("\nПолная инфа о ресерчтим:");
        Console.WriteLine(researchTeam.ToString());
        //12
        researchTeam.AddPapers(
            new Paper("ААаАА",new Person("Ниг","Вайт",new DateTime(2015,12,10)), new DateTime(1980,10,1)),
            new Paper("ААаАА", new Person("yooq", "nbi", new DateTime(2013, 2, 10)), new DateTime(1988, 1, 1)));
        Console.WriteLine("\nПолная инфа после добавление new paper");
        Console.WriteLine(researchTeam.ToString());
        //13
        Paper lastPublication=researchTeam.lastPublicat;
        Console.WriteLine($"\nЛаст публикатион:{lastPublication}");
        //14
        Console.Write("\nВведите число строк и число столбцов через запятую или пробел:");
        string input = Console.ReadLine();
        string[] tokens = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int nrow = int.Parse(tokens[0]);
        int ncolumn = int.Parse(tokens[1]);
        int elementsCount = nrow * ncolumn;

        Paper[] oneDimArray = new Paper[elementsCount];
        Paper[,] twoDimArray = new Paper[nrow, ncolumn];
        Paper[][] jaggedArray = new Paper[nrow][];
        for (int i = 0; i < nrow; i++)
        {
            jaggedArray[i]=new Paper[ncolumn];
        }
        for (int i = 0; i < elementsCount;i++)
        {
            oneDimArray[i] = new Paper();
        }
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn;j++)
            {
                twoDimArray[i, j] = new Paper();
            }
        }
        for (int i = 0; i < nrow; i++) 
        {
            for (int j = 0; j < ncolumn; j++) 
            {
                jaggedArray[i][j] = new Paper(); 
            }
        }
        int start =Environment.TickCount;
        for(int i = 0;i<elementsCount;i++)
        {
            oneDimArray[i].Title = "вай";
        }
        int end = Environment.TickCount;
        Console.WriteLine($"Время выполнения операции для одномерного массива: {end - start} мс");

        start=Environment.TickCount;
        for (int i = 0; i < nrow; i++)
        {
            for(int j = 0;j < ncolumn;j++)
            {
                twoDimArray[i, j].Title = "вай";
            }
        }
        end=Environment.TickCount;
        Console.WriteLine($"Время выполнения операции для двумерного массива: {end-start} мс");

        start=Environment.TickCount;
        for (int i = 0; i < nrow; i++) 
        {
            for (int j = 0; j < ncolumn; j++) 
            {
                jaggedArray[i][j].Title = "Updated Title"; 
            }
        }
        end=Environment.TickCount;
        Console.WriteLine($"Время выполнения операции для двумерного ступенчатого массива: {end - start} мс");




    }
}