using Common.Models;

namespace Common.Interfaces;

public interface IEvaluatorsDAL
{
    IReadOnlyList<Evaluator> GetAll();
    void Save(Evaluator evaluator);
    void Delete(Guid id);
}
