using PuzzleDungeon.Core.Progress;
using PuzzleDungeon.Core.Serializer;
using PuzzleDungeon.Gameplay.Progress;
using UnityEngine;

namespace PuzzleDungeon.Unity.Progress;

public class PlayerProgressHandlerByPlayerPrefs : IProgressHandler<PlayerProgress>
{
    private const string SAVE_KEY = "PLAYER_PROGRESS";
    
    private readonly ISerializer _serializer;

    public PlayerProgressHandlerByPlayerPrefs(
        ISerializer serializer
    )
    {
        _serializer = serializer;
    }
    
    public PlayerProgress LoadProgress()
    {
        if (PlayerPrefs.HasKey(SAVE_KEY))
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            return _serializer.Deserialize<PlayerProgress>(json);
        }

        return null;
    }

    public PlayerProgress CreateNewProgress()
    {
        return new PlayerProgress();
    }

    public void SaveProgress(PlayerProgress progress)
    {
        string json = _serializer.Serialize<PlayerProgress>(progress);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
    }
}