using System.Xml.Linq;

namespace TeamProjectes;

class Person
{
    String firstName;
    String lastName;
    DateTime birthday;

    public DateTime Birthday
    {
        get => birthday;
        set
        {
            if (DateTime.Today >= value)
                birthday = value;
            else
                throw new ArgumentException("День рождения не может быть больше сегодняшнего дня");
        }
    }
    public String FirstName
    {
        get => firstName;
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Значение имеет null или пустая строка");

            firstName = value;
        }
    }
    public String LastName
    {
        get => lastName;
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Значение имеет null или пустая строка");

            lastName = value;
        }
    }

    public int Yers
    {
        get => birthday.Year;
        set
        {
            if (value > DateTime.Now.Year)
                throw new ArgumentException("Передаваемый год больше года в данный момент");

            int differenceYers = DateTime.Now.Year - value;

            birthday = birthday.AddYears(-differenceYers);
        }
    }

    public virtual object DeepCopy()
    {
        return new Person(firstName, lastName, birthday);
    }
    public Person()
    {
        this.firstName = "Имя неизвестно";
        this.lastName = "Фамилия неизвестна";
        this.birthday = DateTime.Today;
    }

    public Person(String firstName, String lastName, DateTime birthday)
    {
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
    }

    public override string ToString() => $"Имя: {firstName}; Фамилия: {LastName}; год рождения: {birthday.ToShortDateString()}";

    public virtual string ToShortString() => $"Имя: {firstName}; Фамилия: {LastName}";
}