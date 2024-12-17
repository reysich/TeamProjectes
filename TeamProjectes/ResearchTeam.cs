using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

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
        private System.Collections.ArrayList listPerson;
        private System.Collections.ArrayList listPaper;

        public ResearchTeam(string nameisled, string nameOrganiz, int regNum, TimeFarme timeFarme) : base(nameOrganiz, regNum)
        {
            this.nameisled = nameisled;
            this.timeframe = timeFarme;
            this.listPerson = new System.Collections.ArrayList();
            this.listPaper = new System.Collections.ArrayList();

        }
        public ResearchTeam() : base()
        {
            this.listPerson = new System.Collections.ArrayList();
            this.listPaper = new System.Collections.ArrayList();
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

        public System.Collections.ArrayList ListPerson
        {
            set { listPerson = value; }
            get { return listPerson; }
        }
        public System.Collections.ArrayList ListPaper
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
        public Paper? lastPublicat
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
            return base.ToString() + $"Название темы иследования:{nameisled}\nПродолжительность иследований:{timeframe}\nСписок публикаций:\n" + string.Join("\n", listPerson) + " \nСписок участников:\n" + string.Join("\n", listPerson);



        }
        public virtual string ToShotrString()
        {
            return base.ToString() + $"Название темы иследования:{nameisled}\nПродолжительность иследований:{timeframe}\n";
        }
        public override object DeepCopy()
        {
            return new ResearchTeam(nameisled, Name, RegistrId, timeframe)
            {
                ListPerson = (System.Collections.ArrayList)listPerson.Clone(),
                ListPaper = (System.Collections.ArrayList)listPaper.Clone(),
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

    }
}
