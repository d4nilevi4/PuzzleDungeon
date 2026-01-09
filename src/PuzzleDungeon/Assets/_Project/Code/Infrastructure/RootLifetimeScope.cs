using VContainer;
using VContainer.Unity;

namespace PuzzleDungeon.Infrastructure
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntryPoint>(Lifetime.Singleton);

            ConfigureGameStateMachine(builder);

            ConfigureSceneLoader(builder);
        }

        private void ConfigureSceneLoader(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SceneLoaderBySceneManager>(Lifetime.Singleton);
        }

        private void ConfigureGameStateMachine(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
            builder.Register<IStateFactory, PooledStateFactory>(Lifetime.Singleton);
        }
    }
}