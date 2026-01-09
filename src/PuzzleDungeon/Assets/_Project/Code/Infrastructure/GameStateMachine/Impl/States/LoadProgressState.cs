using System.Threading;
using Cysharp.Threading.Tasks;

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
// #if UNITY_EDITOR
//         string key = SwitchToEntrySceneInEditor.CURRENT_SCENE_NAME_KEY;
//             
//         if (EditorPrefs.HasKey(key))
//         {
//             sceneName = EditorPrefs.GetString(key);
//
//             EditorPrefs.DeleteKey(key);
//         }
// #endif
        await _stateMachine.Enter<LoadSceneState, string>(SceneNames.MAIN_MENU_SCENE, cancellationToken);
    }

    public UniTask Exit(CancellationToken cancellationToken) =>
        UniTask.CompletedTask;
}