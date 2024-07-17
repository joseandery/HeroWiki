namespace HeroWiki.Requests
{
    public record HeroRequest (string name, string slogan, ICollection<LeagueRequest> Leagues = null);
}
