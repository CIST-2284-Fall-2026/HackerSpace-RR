using Common.Interfaces;
using Common.Models;

namespace Common.DAL;

public sealed class BadgesDALMock : IBadgesDAL
{
    private readonly List<Badge> badges =
    [
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Contributor",
            Description = "Awarded for contributing to the project.",
            TurnInInstructions = "Submit a pull request with your contribution."
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Early Adopter",
            Description = "Awarded for being an early adopter of the platform.",
            TurnInInstructions = "Sign up and start using the platform early."
        },
        new()
        {
            Id = Guid.NewGuid(),
            Title = "Community Helper",
            Description = "Awarded for helping other members of the community.",
            TurnInInstructions = "Assist other members in the community forums."
        }
    ];

    public Task<List<Badge>> GetBadgesAsync() =>
        Task.FromResult(badges.Select(Copy).ToList());

    private static Badge Copy(Badge badge) => new()
    {
        Id = badge.Id,
        Title = badge.Title,
        Description = badge.Description,
        TurnInInstructions = badge.TurnInInstructions,
        IsVisible = badge.IsVisible
    };
}
