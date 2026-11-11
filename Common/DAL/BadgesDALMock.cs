using Common.Interfaces;
using Common.Models;

namespace Common.DAL;

public sealed class BadgesDALMock : IBadgesDAL
{
    private readonly object gate = new();
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

    public Task<List<Badge>> GetBadgesAsync()
    {
        lock (gate)
        {
            return Task.FromResult(badges.Select(Copy).ToList());
        }
    }

    public Task<Badge?> GetBadgeByIdAsync(Guid id)
    {
        lock (gate)
        {
            var badge = badges.Find(badge => badge.Id == id);
            return Task.FromResult(badge is null ? null : Copy(badge));
        }
    }

    public Task AddBadgeAsync(Badge badge)
    {
        lock (gate)
        {
            var newBadge = Copy(badge);
            newBadge.Id = Guid.NewGuid();
            badges.Add(newBadge);
        }

        return Task.CompletedTask;
    }

    public Task UpdateBadgeAsync(Badge badge)
    {
        lock (gate)
        {
            var index = badges.FindIndex(existingBadge => existingBadge.Id == badge.Id);
            if (index < 0)
            {
                throw new KeyNotFoundException("The badge is no longer available.");
            }

            badges[index] = Copy(badge);
        }

        return Task.CompletedTask;
    }

    private static Badge Copy(Badge badge) => new()
    {
        Id = badge.Id,
        Title = badge.Title,
        Description = badge.Description,
        TurnInInstructions = badge.TurnInInstructions,
        IsVisible = badge.IsVisible
    };
}
