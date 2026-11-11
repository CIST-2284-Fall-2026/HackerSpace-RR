using Common.Models;

namespace Common.Interfaces;

public interface IBadgesDAL
{
    Task<List<Badge>> GetBadgesAsync();
    Task<Badge?> GetBadgeByIdAsync(Guid id);
    Task AddBadgeAsync(Badge badge);
    Task UpdateBadgeAsync(Badge badge);
}
