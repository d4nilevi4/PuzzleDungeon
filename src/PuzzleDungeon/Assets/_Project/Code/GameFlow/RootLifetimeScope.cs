using PuzzleDungeon.Core;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Core.Logger;
using PuzzleDungeon.Core.Progress;
using PuzzleDungeon.Core.SceneLoading;
using PuzzleDungeon.Core.Serializer;
using PuzzleDungeon.GameFlow.GameStateMachine;
using PuzzleDungeon.Gameplay.Progress;
using PuzzleDungeon.Unity.Logger;
using PuzzleDungeon.Unity.Progress;
using PuzzleDungeon.VContainer.GameStateMachine;
using PuzzleDungeon.Unity.SceneLoading;
using PuzzleDungeon.Unity.Serializer;
using VContainer;
using VContainer.Unity;

namespace PuzzleDungeon.GameFlow
{
    public class RootLifetimeScope : LifetimeScope, ICompositionRoot
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntryPoint>(Lifetime.Singleton);

            ConfigureGameStateMachine(builder);

            ConfigureSceneLoader(builder);
            
            ConfigureLogger(builder);
            
            ConfigureProgress(builder);
            
            ConfigureSerialization(builder);
        }

        private void ConfigureSerialization(IContainerBuilder builder)
        {
            builder.Register<ISerializer, JsonUtilitySerializer>(Lifetime.Singleton);
        }

        private void ConfigureProgress(IContainerBuilder builder)
        {
            builder.Register<IProgressProvider<PlayerProgress>, PlayerProgressProvider>(Lifetime.Singleton);
            builder.Register<IProgressContainer<PlayerProgress>, PlayerProgressProvider>(Lifetime.Singleton);
            builder.Register<IProgressHandler<PlayerProgress>, PlayerProgressHandlerByPlayerPrefs>(Lifetime.Singleton);
        }

        private void ConfigureLogger(IContainerBuilder builder)
        {
            builder.Register<ILogger, UnityLogger>(Lifetime.Singleton);
        }

        private void ConfigureSceneLoader(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SceneLoaderBySceneManager>(Lifetime.Singleton);
        }

        private void ConfigureGameStateMachine(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, GlobalGameStateMachine>(Lifetime.Singleton);
            builder.Register<IStateFactory, PooledStateFactory>(Lifetime.Singleton);
        }
    }
}