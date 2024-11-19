using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class ResearchTeam
    {
        private string nameisled;
        private string nameOrganiz;
        private int regNum;
        private TimeFarme timeframe;
        private Paper[] listPublicat;
      
        public ResearchTeam(string nameisled, string nameOrganiz, int regNum, TimeFarme timeFarme, Paper[] listPublicat)
        {
            this.nameisled = nameisled;
            this.nameOrganiz = nameOrganiz;
            this.regNum = regNum;
            this.timeframe = timeFarme;
            this.listPublicat = listPublicat;
            
        }
        public ResearchTeam()
        {
            this.listPublicat = new Paper[0];
        }
        public string Nameisled
        {
            set { nameisled = value; }
            get { return nameisled; }
        }
        public string NameOrganiz
        {
            set { NameOrganiz = value; }
            get { return nameOrganiz; }
        }
        public int RegNum
        {
            set { RegNum = value; }
            get { return regNum; }
        }
        public TimeFarme Timeframe
        {
            set { timeframe = value; }
            get { return timeframe; }
        }
        public Paper[] ListPublicat
        {
            set { listPublicat = value; }
            get { return listPublicat; }
        }

        public Paper lastPublicat
        {
            get
            {
                Paper lat = listPublicat[0];
                if (listPublicat.Length == 0)
                {
                    return null;
                }
                else
                {
                    Paper t = listPublicat[0];
                    DateTime max = listPublicat[0].PublishDate;
                    for(int i = 0; i < listPublicat.Length; i++)
                    {
                        if (listPublicat[i].PublishDate.Year> max.Year)
                        {
                            max = listPublicat[i].PublishDate;
                            t = listPublicat[i];
                        }
                    }
                    return t;
                }
                
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
        public void AddPapers(params Paper[] m)
        {
            int oldLength = listPublicat.Length;
            Array.Resize(ref listPublicat, oldLength + m.Length);
            for (int i = 0; i < m.Length; i++)
            {
                listPublicat[oldLength + i] = m[i];
            }
        }
        public override string ToString()
        {
            string rez = $"Название темы иследования:{nameisled}\nНазвание организации:{nameOrganiz}\nРегстрационный номер:{regNum}\nПродолжительность иследований:{timeframe}\nСписок публикаций:\n" ;
            for(int i = 0; i <  listPublicat.Length; i++)
            {
                rez += listPublicat[i] + "\n";
            }
            return rez;
        }
        public virtual string ToShotrString()
        {
            return $"Название темы иследования:{nameisled}\nНазвание организации:{nameOrganiz}\nРегстрационный номер:{regNum}\nПродолжительность иследований:{timeframe}\n";
        }
    }
}
