using HeroWiki.EndPoints;
using HeroWiki.Shared.Data.DB;
using HeroWiki.Shared.Data.Models;
using HeroWiki.Shared.Models;
using HeroWiki_Console;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext <HeroWikiContext> ();

builder.Services
    .AddIdentityApiEndpoints<AccessUser>()
    .AddEntityFrameworkStores<HeroWikiContext>();

builder.Services.AddAuthorization();

builder.Services.AddTransient<DAL<Hero>> ();
builder.Services.AddTransient<DAL<Power>>();
builder.Services.AddTransient<DAL<League>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();

app.AddEndPointsHero();
app.AddEndPointsPower();
app.AddEndPointsLeague();

app.MapGroup("auth").MapIdentityApi<AccessUser>().WithTags("Authorization");

app.MapPost("auth/logout", async ([FromServices] SignInManager<AccessUser> signInManager) => {
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Authorization"); 

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
