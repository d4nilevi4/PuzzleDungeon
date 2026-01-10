using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PuzzleDungeon.Infrastructure;

public class LoadProgressState : IState
{
    private readonly IGameStateMachine _stateMachine;

    public LoadProgressState(IGameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public async UniTask Enter(CancellationToken cancellationToken)
    {
        string sceneName = SceneNames.MAIN_MENU_SCENE;

#if UNITY_EDITOR
        string key = SwitchToEntrySceneInEditor.CURRENT_SCENE_NAME_KEY;

        if (UnityEditor.EditorPrefs.HasKey(key))
        {
            sceneName = UnityEditor.EditorPrefs.GetString(key);
            
            UnityEditor.EditorPrefs.DeleteKey(key);
        }
#endif
        
        await _stateMachine.Enter<LoadSceneState, string>(sceneName, cancellationToken);
    }

    public UniTask Exit(CancellationToken cancellationToken) =>
        UniTask.CompletedTask;
}