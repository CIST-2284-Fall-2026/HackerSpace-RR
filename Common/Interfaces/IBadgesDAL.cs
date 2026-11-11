using Common.Models;

namespace Common.Interfaces;

public interface IBadgesDAL
{
    Task<List<Badge>> GetBadgesAsync();
}
