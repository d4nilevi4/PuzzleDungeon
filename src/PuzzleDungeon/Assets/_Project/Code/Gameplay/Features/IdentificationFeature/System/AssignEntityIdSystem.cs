using Leontitas;

namespace PuzzleDungeon.Gameplay.Identification;

public sealed class AssignEntityIdSystem : IExecuteSystem
{
    private readonly GameGroup _idCandidates;
    private readonly GameGroup _idNextIds;

    public AssignEntityIdSystem()
    {
        _idCandidates = GameWorld.GetGroup(GameMatcher
            .AllOf(GameMatcher.NeedId)
            .NoneOf(GameMatcher.Id));
        
        _idNextIds = GameWorld.GetGroup(GameMatcher.AllOf(GameMatcher.NextId));
    }
    
    public void Execute()
    {
        foreach (GameEntity idCandidate in _idCandidates)
        foreach (GameEntity nextId in _idNextIds)
        {
            idCandidate.AddId(nextId.NextId);
            
            nextId.ChangeNextId(nextId.NextId + 1);
            
            idCandidate.SetNeedIdFlag(false);
        }
    }
}