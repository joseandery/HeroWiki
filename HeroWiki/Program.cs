using HeroWiki.Shared.Data.DB;
using HeroWiki_Console;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext <HeroWikiContext> ();
builder.Services.AddTransient<DAL<Hero>> ();

var app = builder.Build();

app.MapGet("/Heros", ([FromServices] DAL<Hero> dal) =>
{
    return Results.Ok(dal.Read());
});

app.MapPost("/Heros", ([FromServices] DAL<Hero> dal, [FromBody] Hero hero) =>
{
    dal.Create(hero);
    return Results.Ok();
});

app.MapDelete("/Heros/{id}", ([FromServices] DAL<Hero> dal, int id) =>
{
    var hero = dal.ReadBy(a=> a.Id == id);
    if (hero is null) return Results.NotFound();
    dal.Delete(hero);
    return Results.NoContent();
});

app.MapPut("/Heros", ([FromServices] DAL<Hero> dal, [FromBody] Hero hero) =>
{
    var heroToEdit = dal.ReadBy(a=>a.Id == hero.Id);
    if (heroToEdit is null) return Results.NotFound();
    heroToEdit.Name = hero.Name;
    heroToEdit.Slogan = hero.Slogan;
    dal.Update(heroToEdit);
    return Results.Ok();
});

app.Run();
