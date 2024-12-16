using System;
using System.Collections;

namespace TeamProjectes
{
    public enum TimeFarme
    {
        Year,
        TwoYears,
        Long
    }

    internal class ResearchTeam : Team, INameAndCopy
    {
        private string nameisled;
        private TimeFarme timeframe;
        private ArrayList listPerson;
        private ArrayList listPaper;

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
            get { return new Team(Name, RegistrId); }
            set
            {
                Name = value.Name;
                RegistrId = value.RegistrId;
            }
        }

        public Paper lastPublicat
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

        public bool this[TimeFarme t]
        {
            get
            {
                if (timeframe == t)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            return base.ToString() + $"Название темы исследования:{nameisled}\nПродолжительность исследований:{timeframe}\nСписок публикаций:\n" + string.Join("\n", listPaper) + " \nСписок участников:\n" + string.Join("\n", listPerson);
        }

        public virtual string ToShotrString()
        {
            return base.ToString() + $"Название темы исследования:{nameisled}\nПродолжительность исследований:{timeframe}\n";
        }

        public override object DeepCopy()
        {
            return new ResearchTeam(nameisled, Name, RegistrId, timeframe)
            {
                ListPerson = (ArrayList)listPerson.Clone(),
                ListPaper = (ArrayList)listPaper.Clone(),
            };
        }

        public IEnumerable PersonPerebor()
        {
            foreach (Person person in listPerson)
            {
                bool publicat = true;
                foreach (Paper paper in listPaper)
                {
                    if (paper.Author.Equals(person))
                    {
                        publicat = false;
                        break;
                    }
                }
                if (!publicat)
                {
                    yield return person;
                }
            }
        }

        public IEnumerable Paperperebor(int n)
        {
            DateTime Date = DateTime.Now;
            foreach (Paper paper in listPaper)
            {
                if ((Date - paper.PublishDate).TotalDays <= n * 365)
                {
                    yield return paper;
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ResearchTeam other = (ResearchTeam)obj;
            return base.Equals(other) && nameisled == other.nameisled && timeframe == other.timeframe;
        }

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
