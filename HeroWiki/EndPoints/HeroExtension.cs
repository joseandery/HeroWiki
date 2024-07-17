using HeroWiki.Requests;
using HeroWiki.Responses;
using HeroWiki.Shared.Data.DB;
using HeroWiki.Shared.Models;
using HeroWiki_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HeroWiki.EndPoints
{
    public static class HeroExtension
    {
        public static void AddEndPointsHero(this WebApplication app)
        {
            app.MapGet("/Heros", ([FromServices] DAL<Hero> dal) =>
            {
                var heroList = dal.Read();
                if (heroList is null) return Results.NotFound();
                var heroResponseList = EntityListToResponseList(heroList);
                return Results.Ok(heroResponseList);
            });

            app.MapPost("/Heros", ([FromServices] DAL<Hero> dal, [FromServices] DAL<League> dalLeague,[FromBody] HeroRequest heroRequest) =>
            {
                var hero = new Hero(heroRequest.name, heroRequest.slogan)
                {
                    Leagues = heroRequest.Leagues is not null ? 
                    LeagueRequestConverter(heroRequest.Leagues, dalLeague) : 
                    new List<League>()
                };
                dal.Create(hero);
                return Results.Ok();
            });

            app.MapDelete("/Heros/{id}", ([FromServices] DAL<Hero> dal, int id) =>
            {
                var hero = dal.ReadBy(a => a.Id == id);
                if (hero is null) return Results.NotFound();
                dal.Delete(hero);
                return Results.NoContent();
            });

            app.MapPut("/Heros", ([FromServices] DAL<Hero> dal, [FromBody] HeroEditRequest heroRequest) =>
            {
                var heroToEdit = dal.ReadBy(a => a.Id == heroRequest.id);
                if (heroToEdit is null) return Results.NotFound();
                heroToEdit.Name = heroRequest.name;
                heroToEdit.Slogan = heroRequest.slogan;
                dal.Update(heroToEdit);
                return Results.Ok();
            });

            app.MapGet("/Heros{id}", ([FromServices] DAL<Hero> dal, int id) =>
            {
                var hero = dal.ReadBy(a => a.Id ==id);
                if (hero is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(hero));
            });
            
        }
        private static ICollection<HeroResponse> EntityListToResponseList (IEnumerable<Hero> heroList)
        {
            return heroList.Select(a => EntityToResponse(a)).ToList();
        }

        private static HeroResponse EntityToResponse(Hero hero)
        {
            return new HeroResponse(hero.Id, hero.Name, hero.Slogan);
        }

        private static ICollection<League> LeagueRequestConverter(ICollection<LeagueRequest> leagues, DAL<League> dalLeague)
        {
            var leagueList = new List<League>();
            foreach (var item in leagues)
            {
                var entity = RequestToEntity(item);
                var league = dalLeague.ReadBy(l => l.Name.ToUpper().Equals(entity.Name.ToUpper()));
                if (league is not null) leagueList.Add(league);
                else leagueList.Add(entity);
            }
            return leagueList;
        }     

        private static League RequestToEntity(LeagueRequest l)
        {
            return new League() {Name = l.Name};
        }
    }
}
