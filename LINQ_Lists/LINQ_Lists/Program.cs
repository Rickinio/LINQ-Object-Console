using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LINQ_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Bets> bets = new List<Bets>();
            List<Matches> matches = new List<Matches>(){
                new Matches(){ TeamA = "Panathinaikos", TeamB = "Olympiakos", GameCode = 123 },
                new Matches(){TeamA = "Panaxaiki", TeamB = "Olympiakos", GameCode = 456 },
                new Matches(){TeamA = "Larisa", TeamB = "Volos", GameCode = 789 }
            };

            FoundTeams foundTeams = new FoundTeams();
            foundTeams.Url = "www.vrikaomada.gr";
            foundTeams.Teams = new List<string>
            {
                "Olympiakos",
                "Volos"
            };

            foreach (var item in foundTeams.Teams)
            {
                var asd = (from c in matches
                           where (c.TeamA.Contains(item.ToString()) || c.TeamB.Contains(item.ToString()))
                           select new Bets()
                           {
                               GameCode = c.GameCode
                           }).ToList();
                foreach (var item2 in asd)
                {
                    bets.Add(item2);
                }
            }


            Console.Write("asd");
        }
    }

    class Matches
    {
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public int GameCode { get; set; }
    }

    class FoundTeams
    {
        public string Url { get; set; }
        public List<string> Teams { get; set; }
    }

    class Bets
    {
        public int GameCode;
    }
}
