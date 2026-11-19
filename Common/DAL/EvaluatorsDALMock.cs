using System.Collections.Concurrent;
using Common.Interfaces;
using Common.Models;

namespace Common.DAL;

public sealed class EvaluatorsDALMock : IEvaluatorsDAL
{
    private readonly ConcurrentDictionary<Guid, Evaluator> evaluators = new();

    public IReadOnlyList<Evaluator> GetAll() =>
        evaluators.Values.OrderBy(person => person.Name).Select(person => person with { }).ToArray();

    public void Save(Evaluator evaluator)
    {
        if (evaluator.Id == Guid.Empty)
        {
            var id = Guid.NewGuid();
            evaluators.TryAdd(id, evaluator with { Id = id });
        }
        else if (evaluators.TryGetValue(evaluator.Id, out var current))
        {
            evaluators.TryUpdate(evaluator.Id, evaluator with { }, current);
        }
    }

    public void Delete(Guid id) => evaluators.TryRemove(id, out _);
}
