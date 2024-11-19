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
    }
}
