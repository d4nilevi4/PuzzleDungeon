namespace PuzzleDungeon.Core.Logger;

public interface ILogger
{
    void LogInfo(string tag, string message);
    void LogWarning(string tag, string message);
    void LogError(string tag, string message);
}