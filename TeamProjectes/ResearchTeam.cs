using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjectes
{
    public interface IEnumerator<ResearchTeam>////////////
    {
        bool MoveNext();
        ResearchTeam Current { get; }
        void Reset();
    }
    internal class ListResearchTeam : IEnumerator<ResearchTeam>///////////////
    {
        private List<ResearchTeam> List;
        public bool disposed = false;
        public int currentIndex = -1;
        public ListResearchTeam(List<ResearchTeam> tr) => this.List = tr;
        public ResearchTeam Current
        {
            get { return List[currentIndex]; }
        }
        public bool MoveNext()
        {
            if (currentIndex + 1 == List.Count)
            {
                Reset();
                return false;
            }
            currentIndex++;
            return true;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {

                }
                this.disposed = true;
            }
        }
    }
    public class ResearchEnum : IEnumerable<ResearchTeam>/////////////////////
    {
        List<ResearchTeam> list;
        public IEnumerator<ResearchTeam> GetEnumerator() => new ListResearchTeam(list);
        public ResearchEnum(List<ResearchTeam> list)
        {
            this.list = list;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        System.Collections.Generic.IEnumerator<ResearchTeam> IEnumerable<ResearchTeam>.GetEnumerator()
        { throw new NotImplementedException(); }
    }

    public enum TimeFarme
    {
        Year,
        TwoYears,
        Long

    }
    internal class ResearchTeam : Team , INameAndCopy
    {
        
        private string nameisled;
        private TimeFarme timeframe;
        private System.Collections.ArrayList listPerson;
        private System.Collections.ArrayList listPaper;
      
        public ResearchTeam(string nameisled, string nameOrganiz, int regNum, TimeFarme timeFarme)  : base(nameOrganiz, regNum)
        {
            this.nameisled = nameisled;
            this.timeframe = timeFarme;
            /////////////////////////////////////////////////// 
            
        }
        public ResearchTeam() : base()
        {
            /////////////////////////////////
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

                foreach(Paper paper in listPaper)
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
                if(timeframe == t)
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
            listPaper.Add(publicat);
        }
        public void AddMembers(params Person[] persons)
        {
            listPerson.Add(persons);
        }
        public override string ToString()
        {
            string rez = base.ToString() + $"Название темы иследования:{nameisled}\nНазвание организации:{nameOrganiz}\nРегстрационный номер:{registrId}\nПродолжительность иследований:{timeframe}\nСписок публикаций:\nСписок участников:\n" ;
            foreach (Paper paper in listPaper)
            {
                rez += paper + "\n";
            }
            rez += "Список публикаций\n";
            foreach (Paper paper in listPerson)
            {
                rez += paper + "\n";
            }
            return rez;
        }
        public virtual string ToShotrString()
        {
            return $"Название темы иследования:{nameisled}\nНазвание организации:{nameOrganiz}\nРегстрационный номер:{registrId}\nПродолжительность иследований:{timeframe}\n";
        }
        public override  object DeepCopy()
        {
            return new ResearchTeam(nameisled, Name, RegistrId, timeframe);
        }


    }
}
