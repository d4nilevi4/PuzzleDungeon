using PuzzleDungeon.Core.Logger;

namespace PuzzleDungeon.Unity.Logger;

public class UnityLogger : ILogger
{
    private static UnityEngine.ILogger Logger => UnityEngine.Debug.unityLogger;
    
    public void LogInfo(string tag, string message)
    {
        Logger.Log(tag, message);
    }

    public void LogWarning(string tag, string message)
    {
        Logger.LogWarning(tag, message);
    }

    public void LogError(string tag, string message)
    {
        Logger.LogError(tag, message);
    }
}