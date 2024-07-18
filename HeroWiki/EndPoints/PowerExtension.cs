using HeroWiki.Requests;
using HeroWiki.Responses;
using HeroWiki.Shared.Data.DB;
using HeroWiki_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace HeroWiki.EndPoints
{
    public static class PowerExtension
    {
        public static void AddEndPointsPower(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("powers")
                .RequireAuthorization()
                .WithTags("Powers");

            groupBuilder.MapGet("", ([FromServices] DAL<Power> dal) =>
            {
                var powerList = dal.Read();
                if (powerList is null) return Results.NotFound();
                var powerResponseList = EntityListToResponseList(powerList);
                return Results.Ok(powerResponseList);
            });

            groupBuilder.MapPost("", ([FromServices] DAL<Power> dal, [FromBody] PowerRequest powerRequest) =>
            {
                dal.Create(new Power(powerRequest.name));
                return Results.Ok();
            });

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Power> dal, int id) =>
            {
                var power = dal.ReadBy(a => a.Id == id);
                if (power is null) return Results.NotFound();
                dal.Delete(power);
                return Results.NoContent();
            });

            groupBuilder.MapPut("", ([FromServices] DAL<Power> dal, [FromBody] PowerEditRequest powerRequest) =>
            {
                var powerToEdit = dal.ReadBy(a => a.Id == powerRequest.id);
                if (powerToEdit is null) return Results.NotFound();
                powerToEdit.Name = powerRequest.name;
                dal.Update(powerToEdit);
                return Results.Ok();
            });

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Power> dal, int id) =>
            {
                var power = dal.ReadBy(a => a.Id == id);
                if (power is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(power));
            });

        }

        private static ICollection<PowerResponse> EntityListToResponseList(IEnumerable<Power> powerList)
        {
            return powerList.Select(a=> EntityToResponse(a)).ToList();
        }
        private static PowerResponse EntityToResponse(Power power)
        {
            return new PowerResponse(
                power.Id, 
                power.Name ?? string.Empty, 
                power.Hero?.Id ?? 0, 
                power.Hero?.Name?? "No linked hero");
        }
    }
}
