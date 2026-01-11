using PuzzleDungeon.Core;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Core.Logger;
using PuzzleDungeon.Core.Progress;
using PuzzleDungeon.Core.SceneLoading;
using PuzzleDungeon.Core.Serializer;
using PuzzleDungeon.Core.Systems;
using PuzzleDungeon.Gameplay.Progress;
using PuzzleDungeon.Unity.Logger;
using PuzzleDungeon.Unity.Progress;
using PuzzleDungeon.VContainer.GameStateMachine;
using PuzzleDungeon.Unity.SceneLoading;
using PuzzleDungeon.Unity.Serializer;
using PuzzleDungeon.VContainer.Systems;
using VContainer;
using VContainer.Unity;

namespace PuzzleDungeon.GameFlow
{
    public class GlobalLifetimeScope : LifetimeScope, ICompositionRoot
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GlobalEntryPoint>(Lifetime.Singleton);

            ConfigureGameStateMachine(builder);

            ConfigureSceneLoader(builder);
            
            ConfigureLogger(builder);
            
            ConfigureProgress(builder);
            
            ConfigureSerialization(builder);

            ConfigureSystemFactory(builder);
        }

        private void ConfigureSystemFactory(IContainerBuilder builder)
        {
            builder.Register<ISystemFactory, VContainerSystemFactory>(Lifetime.Singleton);
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
            builder.Register<IGameStateMachine, CommonGameStateMachine>(Lifetime.Singleton);
            builder.Register<IStateFactory, PooledStateFactory>(Lifetime.Singleton);
        }
    }
}