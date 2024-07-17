using HeroWiki_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroWiki.Shared.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Hero> Heros { get; set; }

        public override string ToString()
        {
            return $@"Id: {Id} - Nome: {Name}"; ;
        }
    }
}
