using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroWiki_Console
{
    public class Power
    {
        public Power(string name)
        {
            Name = name;
            //Description = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        //Processo de alteração de tabelas por Migrations 
        //public string Description { get; set; }
        public int Strength { get; set; }

        public override string ToString()
        {
            return $@"Poder: {Name}";
        }
    }
}
