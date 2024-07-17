using HeroWiki.Requests;
using HeroWiki.Responses;
using HeroWiki.Shared.Data.DB;
using HeroWiki.Shared.Models;
using HeroWiki_Console;
using Microsoft.AspNetCore.Mvc;

namespace HeroWiki.EndPoints
{
    public static class LeagueExtension
    {
        public static void AddEndPointsLeague (this WebApplication app)
        {
            app.MapGet("/Leagues", ([FromServices] DAL<League> dal) =>
            {
                var leagueList = dal.Read();
                if (leagueList is null) return Results.NotFound();
                var leagueResponseList = EntityListToResponseList(leagueList);
                return Results.Ok(leagueResponseList);
            });

            app.MapPost("/Leagues", ([FromServices] DAL<League> dal, [FromBody] LeagueRequest leagueRequest) =>
            {
                dal.Create(RequestToEntity(leagueRequest));
                return Results.Ok();
            });

            app.MapDelete("/Leagues/{id}", ([FromServices] DAL<League> dal, int id) =>
            {
                var league = dal.ReadBy(a => a.Id == id);
                if (league is null) return Results.NotFound();
                dal.Delete(league);
                return Results.NoContent();
            });
        }

        private static League RequestToEntity(LeagueRequest leagueRequest)
        {
            return new League() {Name = leagueRequest.Name};
        }

        private static ICollection<LeagueResponse> EntityListToResponseList(IEnumerable<League> leagueList)
        {
            return leagueList.Select(l => EntityToResponse(l)).ToList();
        }

        private static LeagueResponse EntityToResponse(League l)
        {
            return new LeagueResponse(l.Id, l.Name);
        }
    }
}
