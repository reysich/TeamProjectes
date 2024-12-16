using System.Runtime.CompilerServices;
using TeamProjectes;
using System;


class Program
{
    static void Main(string[] args)
    {
        Team team1 = new Team("Microsoft", 12345);
        Team team2 = new Team("Microsoft", 12345);

        Console.WriteLine($"Ссылки на объекты равны: {ReferenceEquals(team1, team2)}");
        Console.WriteLine($"Объекты равны: {team1 == team2}");
        Console.WriteLine($"Хэш-код team1: {team1.GetHashCode()}");
        Console.WriteLine($"Хэш-код team2: {team2.GetHashCode()}");

        try
        {
            team1.RegistrId = -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        ResearchTeam researchTeam = new ResearchTeam("xz", "Microsoft", 12345, TimeFarme.TwoYears);
        researchTeam.AddPapers(
            new Paper("sxe", new Person("Nigg", "er", new DateTime(1980, 1, 1)), DateTime.Now),
            new Paper("A i OoO", new Person("pi", "sya", new DateTime(1985, 5, 15)), DateTime.Now.AddYears(-1))
        );

        researchTeam.AddMembers(
            new Person("po", "so", new DateTime(1980, 1, 1)),
            new Person("Crypto", "XD", new DateTime(1985, 5, 15)),
            new Person("ema", "lolik", new DateTime(1990, 10, 20))
        );

        Console.WriteLine(researchTeam);
        Console.WriteLine(researchTeam.BaseTeam);

        ResearchTeam researchTeamCopy = (ResearchTeam)researchTeam.DeepCopy();
        researchTeam.Name = "SsS";
        researchTeam.RegistrId = 54321;

        Console.WriteLine("Исходный объект:");
        Console.WriteLine(researchTeam);

        Console.WriteLine("Копия объекта:");
        Console.WriteLine(researchTeamCopy);

        Console.WriteLine("Участники проекта без публикаций:");
        foreach (Person person in researchTeam.PersonPerebor())
        {
            Console.WriteLine(person);
        }

        Console.WriteLine("Публикации за последние два года:");
        foreach (Paper paper in researchTeam.Paperperebor(2))
        {
            Console.WriteLine(paper);
        }
    }
}
