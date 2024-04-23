using System.Text.RegularExpressions;

namespace Domain.Entities;

public partial class UrlEntity
{
    public Guid Id { get; set; }
    public string Short { get; set; }
    public string Redirect { get; set; }
    public DateTime? Expiration { get; set; }

    private readonly Regex _regex = RedirectRegex();

    public UrlEntity(string shortLink, string redirect, DateTime? expiration = null)
    {
        if (!_regex.IsMatch(redirect))
        {
            throw new ArgumentException($"Argument {nameof(redirect)} doesn't match business rule.");
        }
        
        Id = Guid.NewGuid();
        Short = shortLink;
        Redirect = redirect;
        Expiration = expiration;
    }

    [GeneratedRegex(@"^https?:\/\/.+")]
    private static partial Regex RedirectRegex();
}