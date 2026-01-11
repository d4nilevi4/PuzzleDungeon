using PuzzleDungeon.Core.Events;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Unity.Events;
using PuzzleDungeon.VContainer.GameStateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PuzzleDungeon.GameFlow.Battle
{
    public class BattleLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<BattleEntryPoint>(Lifetime.Singleton);
            
            ConfigureGameStateMachine(builder);
            
            ConfigureLifetimeEventsProducer(builder);
        }

        private void ConfigureLifetimeEventsProducer(IContainerBuilder builder)
        {
            builder.Register<ILifetimeEventsProducer>(_ =>
            {
                var go = new GameObject("LifetimeEventsProducer");
                return go.AddComponent<UnityCycleLifetimeEventsProducer>();
            }, Lifetime.Singleton);
        }

        private void ConfigureGameStateMachine(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, CommonGameStateMachine>(Lifetime.Singleton);
            builder.Register<IStateFactory, PooledStateFactory>(Lifetime.Singleton);
        }
    }
}