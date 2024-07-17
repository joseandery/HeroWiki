using HeroWiki.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroWiki_Console
{
    public class Hero
    {
        public Hero(string name, string slogan)
        {
            Name = name;
            Slogan = slogan;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slogan { get; set; }

        public virtual ICollection<Power> Powers { get; set; } = new List<Power>();

        public virtual ICollection<League> Leagues { get; set; }

        public void AddPower(Power power)
        {
            Powers.Add(power); 
        }

        public void ShowPowers()
        {
            Console.WriteLine($"Poderes de {Name}:");
            foreach (var power in Powers)
            {
                Console.WriteLine(power);
            }
        }

        public override string ToString()
        {
            return $@"Id: {Id} - Nome: {Name}";
        }
     
    }
}
