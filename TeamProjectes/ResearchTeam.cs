using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectes
{
    // чибоксар
    public enum TimeFarme
    {
        Year,
        TwoYears,
        Long
    }
    internal class ResearchTeam : Team, INameAndCopy
    {
        // поля класса
        private string nameisled; 
        private TimeFarme timeframe; 
        private ArrayList listPerson;
        private ArrayList listPaper; 

        // онструктор лего
        public ResearchTeam(string nameisled, string nameOrganiz, int regNum, TimeFarme timeFarme) : base(nameOrganiz, regNum)
        {
            this.nameisled = nameisled;
            this.timeframe = timeFarme;
            this.listPerson = new ArrayList();
            this.listPaper = new ArrayList();
        }
        public ResearchTeam() : base()
        {
            this.listPerson = new ArrayList();
            this.listPaper = new ArrayList();
            this.nameisled = "default";
        }

        //свойства
        public string Name
        {
            set { nameisled = value; }
            get { return nameisled; }
        }

        public TimeFarme Timeframe
        {
            set { timeframe = value; }
            get { return timeframe; }
        }

        public ArrayList ListPerson
        {
            set { listPerson = value; }
            get { return listPerson; }
        }

        public ArrayList ListPaper
        {
            set { listPaper = value; }
            get { return listPaper; }
        }
        public Team BaseTeam
        {
            get
            {
                return new Team(Name, RegistrId);
            }
            set
            {
                Name = value.Name;
                RegistrId = value.RegistrId;
            }
        }
        public Paper LastPublication
        {
            get
            {
                if (listPaper.Count == 0)
                {
                    return null;
                }

                Paper latest = (Paper)listPaper[0];
                DateTime maxDate = latest.PublishDate;

                foreach (Paper paper in listPaper)
                {
                    if (paper.PublishDate > maxDate)
                    {
                        maxDate = paper.PublishDate;
                        latest = paper;
                    }
                }
                return latest;
            }
        }

        // продолжительность исследованрей крч да
        public bool this[TimeFarme t]
        {
            get
            {
                return timeframe == t;
            }
        }
        public void AddPapers(params Paper[] publicat)
        {
            foreach (Paper pub in publicat)
            {
                listPaper.Add(pub);
            }
        }

        public void AddMembers(params Person[] persons)
        {
            foreach (Person person in persons)
            {
                listPerson.Add(person);
            }
        }
        public override string ToString()
        {
            return base.ToString() +
                   $"Название темы исследования: {nameisled}\n" +
                   $"Продолжительность исследований: {timeframe}\n" +
                   $"Список публикаций: {string.Join("\n", listPaper)}\n" +
                   $"Список участников: {string.Join("\n", listPerson)}";
        }

        public virtual string ToShortString()
        {
            return base.ToString() +
                   $"Название темы исследования: {nameisled}\n" +
                   $"Продолжительность исследований: {timeframe}\n";
        }

        // глубоко копи коип
        public override object DeepCopy()
        {
            ResearchTeam copy = (ResearchTeam)this.MemberwiseClone();
            copy.ListPerson = (ArrayList)listPerson.Clone();
            copy.ListPaper = (ArrayList)listPaper.Clone();
            return copy;
        }

        // сравненрие
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ResearchTeam other = (ResearchTeam)obj;
            return base.Equals(other) && nameisled == other.nameisled && timeframe == other.timeframe;
        }

        // хэшик кешик
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), nameisled, timeframe);
        }
        public static bool operator ==(ResearchTeam rt1, ResearchTeam rt2)
        {
            if (ReferenceEquals(rt1, null) && ReferenceEquals(rt2, null)) return true;
            if (ReferenceEquals(rt1, null) || ReferenceEquals(rt2, null)) return false;
            return rt1.Equals(rt2);
        }

        public static bool operator !=(ResearchTeam rt1, ResearchTeam rt2)
        {
            return !(rt1 == rt2);
        }

        // метод для пперебора чепухов
        public IEnumerable<Person> PersonPerebor()
        {
            foreach (Person person in listPerson)
            {
                bool hasPublication = false;
                foreach (Paper paper in listPaper)
                {
                    if (paper.Author.Equals(person))
                    {
                        hasPublication = true;
                        break;
                    }
                }
                if (!hasPublication)
                {
                    yield return person;
                }
            }
        }

        // за ласт лет йоу
        public IEnumerable<Paper> Paperperebor(int n)
        {
            DateTime currentDate = DateTime.Now;
            foreach (Paper paper in listPaper)
            {
                if ((currentDate - paper.PublishDate).TotalDays <= n * 365)
                {
                    yield return paper;
                }
            }
        }

        // перебор крутых
        public IEnumerator GetEnumerator()
        {
            foreach (Person person in listPerson)
            {
                foreach (Paper paper in listPaper)
                {
                    if (paper.Author.Equals(person))
                    {
                        yield return person;
                        break;
                    }
                }
            }
        }

        // перебор больше 1 публикации на онлике
        public IEnumerable<Person> PersonsWithMultiplePapers()
        {
            foreach (Person person in listPerson)
            {
                int count = 0;
                foreach (Paper paper in listPaper)
                {
                    if (paper.Author.Equals(person))
                    {
                        count++;
                    }
                }
                if (count > 1)
                {
                    yield return person;
                }
            }
        }

        // публикации за ласт год
        public IEnumerable<Paper> PapersFromLastYear()
        {
            DateTime currentDate = DateTime.Now;
            foreach (Paper paper in listPaper)
            {
                if ((currentDate - paper.PublishDate).TotalDays <= 365)
                {
                    yield return paper;
                }
            }
        }
    }
}
