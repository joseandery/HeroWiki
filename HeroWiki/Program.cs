using HeroWiki.EndPoints;
using HeroWiki.Shared.Data.DB;
using HeroWiki_Console;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext <HeroWikiContext> ();
builder.Services.AddTransient<DAL<Hero>> ();
builder.Services.AddTransient<DAL<Power>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointsHero();
app.AddEndPointsPower();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
