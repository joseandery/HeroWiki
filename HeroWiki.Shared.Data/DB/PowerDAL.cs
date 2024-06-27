using HeroWiki_Console;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroWiki.Shared.Data.DB
{
    public class PowerDAL
    {
        private readonly HeroWikiContext context;

        public PowerDAL(HeroWikiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Power> Read()
        {
            return context.Power.ToList();
        }

        public void Create(Power power)
        {
            context.Power.Add(power);
            context.SaveChanges();
        }

        public void Update(Power power)
        {
            context.Power.Update(power);
            context.SaveChanges();
        }

        public void Delete(Power power)
        {
            context.Power.Remove(power);
            context.SaveChanges();
        }

        public Power? ReadByName(string name)
        {
            return context.Power.FirstOrDefault(x => x.Name == name);
        }
    }
}
