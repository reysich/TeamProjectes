﻿using System;
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
    internal class ResearchTeam : Team
    {
        

        private string nameisled;
        private string nameOrganiz;
        private int regNum;
        private TimeFarme timeframe;
        private Paper[] listPublicat;
        private System.Collections.ArrayList listPerson;
        private System.Collections.ArrayList listPaper;
      
        public ResearchTeam(string nameisled, string nameOrganiz, int regNum, TimeFarme timeFarme, Paper[] listPublicat)  : base(nameOrganiz, regNum)
        {
            this.nameisled = nameisled;
            this.nameOrganiz = nameOrganiz;
            this.regNum = regNum;
            this.timeframe = timeFarme;
            this.listPublicat = listPublicat;
            
        }
        public ResearchTeam() : base()
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
            set { nameOrganiz = value; }
            get { return nameOrganiz; }
        }
        public int RegNum
        {
            set { regNum = value; }
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
                if (listPublicat.Length == 0)
                {
                    return null;
                }

                Paper latest = listPublicat[0];
                DateTime maxDate = listPublicat[0].PublishDate;

                for (int i = 1; i < listPublicat.Length; i++)
                {
                    if (listPublicat[i].PublishDate > maxDate)
                    {
                        maxDate = listPublicat[i].PublishDate;
                        latest = listPublicat[i];
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
            string rez = base.ToString() + $"Название темы иследования:{nameisled}\nНазвание организации:{nameOrganiz}\nРегстрационный номер:{regNum}\nПродолжительность иследований:{timeframe}\nСписок публикаций:\n" ;
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
