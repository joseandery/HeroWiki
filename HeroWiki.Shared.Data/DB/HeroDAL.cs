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

        public void Update(Hero hero, int id)
        {
            using var connection = new Connection().Connect();
            connection.Open();
            string sql = $"UPDATE Hero SET Name = @name, Slogan = @slogan WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql,connection);
            cmd.Parameters.AddWithValue("@name", hero.Name);
            cmd.Parameters.AddWithValue("@slogan", hero.Slogan);
            cmd.Parameters.AddWithValue("@id", id);
            int retorno = cmd.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}");

        }

        public void Delete(int id)
        {
            using var connection = new Connection().Connect();
            connection.Open();

            string sql = $"DELETE FROM Hero WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sql,connection);

            cmd.Parameters.AddWithValue("@id", id);
            int retorno = cmd.ExecuteNonQuery();
            Console.WriteLine($"Linhas afetadas: {retorno}");
        }
    }
}
