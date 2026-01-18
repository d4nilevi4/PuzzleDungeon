using Leontitas;
using PuzzleDungeon.Core.Events;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Core.Systems;
using PuzzleDungeon.Unity.Events;
using PuzzleDungeon.VContainer.GameStateMachine;
using PuzzleDungeon.VContainer.Systems;
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

            ConfigureSystemFactory(builder);
        }
        
        private void ConfigureSystemFactory(IContainerBuilder builder)
        {
            builder.Register<ISystemFactory, VContainerSystemFactory>(Lifetime.Singleton);
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