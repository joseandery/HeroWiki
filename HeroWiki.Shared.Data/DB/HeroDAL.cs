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
        public IEnumerable<Hero> Read()
        {
            var list = new List<Hero>();
            using var connection = new Connection().Connect();
            connection.Open();
            string sql = "SELECT * FROM Hero";
            SqlCommand cmd = new SqlCommand(sql, connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string heroName = Convert.ToString(reader["Name"]);
                string heroSlogan = Convert.ToString(reader["Slogan"]);
                Hero hero = new(heroName, heroSlogan);
                list.Add(hero);
            }
            return list;
        }

        public void Create(Hero hero)
        {
            using var connection = new Connection().Connect();
            connection.Open();
            string sql = "INSERT INTO Hero (Name, Slogan) VALUES (@name, @slogan)";
            SqlCommand cmd = new SqlCommand(sql,connection);
            cmd.Parameters.AddWithValue("@name", hero.Name);
            cmd.Parameters.AddWithValue("@slogan", hero.Slogan);
            int retorno = cmd.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}");
        }
    }
}
