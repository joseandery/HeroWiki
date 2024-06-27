using HeroWiki_Console;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroWiki.Shared.Data.DB
{
    public class HeroDAL
    {
        private readonly HeroWikiContext context;

        public HeroDAL(HeroWikiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Hero> Read()
        {
            return context.Hero.ToList();
        }

        public void Create(Hero hero)
        {
            context.Hero.Add(hero);
            context.SaveChanges();
        }

        public void Update(Hero hero)
        {
            context.Hero.Update(hero);
            context.SaveChanges();
        }

        public void Delete(Hero hero)
        {
            context.Hero.Remove(hero);
            context.SaveChanges();
        }

        public Hero? ReadByName(string name)
        {
            return context.Hero.FirstOrDefault(x => x.Name == name);
        }
    }
}
