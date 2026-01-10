using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Core.Logger;
using PuzzleDungeon.Core.SceneLoading;
using PuzzleDungeon.GameFlow.GameStateMachine;
using PuzzleDungeon.Gameplay.Progress;
using PuzzleDungeon.Unity.SceneLoading;
using VContainer.Unity;

namespace PuzzleDungeon.GameFlow
{
    public class EntryPoint : IAsyncStartable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ILogger _logger;

        public EntryPoint(IGameStateMachine gameStateMachine, ILogger logger)
        {
            _gameStateMachine = gameStateMachine;
            _logger = logger;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _logger.LogInfo("EntryPoint", "Executing game state machine sequence.");

            _logger.LogInfo("EntryPoint", $"Entering {nameof(BootstrapState)}.");
            await _gameStateMachine.Enter<BootstrapState>(cancellation);

            _logger.LogInfo("EntryPoint", $"Entering {nameof(LoadProgressState<PlayerProgress>)} for {nameof(PlayerProgress)}.");
            await _gameStateMachine.Enter<LoadProgressState<PlayerProgress>>(cancellation);
            
            string sceneName = SceneNames.MAIN_MENU_SCENE;

#if UNITY_EDITOR
            string key = SwitchToEntrySceneInEditor.CURRENT_SCENE_NAME_KEY;

            if (UnityEditor.EditorPrefs.HasKey(key))
            {
                sceneName = UnityEditor.EditorPrefs.GetString(key);

                UnityEditor.EditorPrefs.DeleteKey(key);
            }
#endif

            _logger.LogInfo("EntryPoint", $"Entering {nameof(LoadSceneState)} for {sceneName} scene.");
            await _gameStateMachine.Enter<LoadSceneState, string>(sceneName, cancellation);
        }
    }
}