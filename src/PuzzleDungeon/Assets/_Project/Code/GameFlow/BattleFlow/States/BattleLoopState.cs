using System.Threading;
using Cysharp.Threading.Tasks;
using Leontitas;
using PuzzleDungeon.Core.Events;
using PuzzleDungeon.Core.GameStateMachine;
using PuzzleDungeon.Core.Systems;
using PuzzleDungeon.Gameplay;
using UnityEngine;

namespace PuzzleDungeon.GameFlow.Battle;

public class BattleLoopState : IState
{
    private readonly ILifetimeEventsProducer _lifetimeEventsProducer;
    private readonly ISystemFactory _systemFactory;

    private BattleFeature _battleFeature;

    public BattleLoopState(
        ILifetimeEventsProducer lifetimeEventsProducer,
        ISystemFactory systemFactory
    )
    {
        _lifetimeEventsProducer = lifetimeEventsProducer;
        _systemFactory = systemFactory;
    }
    
    public UniTask Enter(CancellationToken cancellationToken)
    {
        _battleFeature = (BattleFeature)_systemFactory.Create<BattleFeature>();
        
        _lifetimeEventsProducer.EventInitialize += OnInitialize;
        _lifetimeEventsProducer.EventFixedUpdate += OnFixedUpdate;
        _lifetimeEventsProducer.EventUpdate += OnUpdate;
        _lifetimeEventsProducer.EventLateUpdate += OnLateUpdate;
        _lifetimeEventsProducer.EventDestroy += OnDestroy;
        
        return UniTask.CompletedTask;
    }

    public async UniTask Exit(CancellationToken cancellationToken)
    {
        await Awaitable.EndOfFrameAsync(cancellationToken);
        
        _lifetimeEventsProducer.EventInitialize -= OnInitialize;
        _lifetimeEventsProducer.EventFixedUpdate -= OnFixedUpdate;
        _lifetimeEventsProducer.EventUpdate -= OnUpdate;
        _lifetimeEventsProducer.EventLateUpdate -= OnLateUpdate;
        _lifetimeEventsProducer.EventDestroy -= OnDestroy;
        
        GameWorld.Instance.Destroy();
        _battleFeature = null;
    }

    private void OnInitialize()
    {
        _battleFeature.Initialize();
    }

    private void OnFixedUpdate()
    {
        _battleFeature.FixedExecute();
    }

    private void OnUpdate()
    {
        _battleFeature.PreExecute();
        _battleFeature.Execute();
    }

    private void OnLateUpdate()
    {
        _battleFeature.LateExecute();
        _battleFeature.Cleanup();
    }

    private void OnDestroy()
    {
        _battleFeature.TearDown();
    }
}