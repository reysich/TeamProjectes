using System.Runtime.CompilerServices;
using TeamProjectes;
using System;


Person person = new Person("Ден","Куст",new DateTime(2006,04,04));
Person person1 = new Person("Ден", "Куст22", new DateTime(2006, 04, 04));
Person person2 = new Person("Ден", "Куст33", new DateTime(2006, 04, 04));
Person person3 = new Person("Ден", "Куст44", new DateTime(2006, 04, 04));
Paper[] publications = new Paper[] {
    new Paper("Title1", person, new DateTime(2021, 1, 1)), 
    new Paper("Title2", person1, new DateTime(2022, 2, 2)), 
    new Paper("Title3", person2, new DateTime(2020, 3, 3)) 
};
ResearchTeam team = new ResearchTeam("AI Research", "Tech University", 12345, TimeFarme.TwoYears, publications);
Console.WriteLine(team);
team.AddPapers(new Paper("Title4", person3, new DateTime(2023, 4, 4)),new Paper("Title5", person3, new DateTime(2024, 5, 5))) ; 
Console.WriteLine(team);
Console.WriteLine(team.lastPublicat);
Console.WriteLine(team.ToShotrString());
Console.WriteLine(team[TimeFarme.Year]);
