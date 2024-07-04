﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroWiki.Shared.Data.DB
{
    public class DAL<T> where T : class
    {
        private readonly HeroWikiContext context;

        public DAL(HeroWikiContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> Read()
        {
            return context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T? ReadBy(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }
    }
}
