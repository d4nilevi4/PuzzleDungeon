using System.Threading;
using Cysharp.Threading.Tasks;
using Leontitas;
using Leopotam.EcsLite;
using Mitfart.LeoECSLite.UnityIntegration;
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
    
#if UNITY_EDITOR
    private EcsWorldDebugSystem _inputDebug;
    private EcsWorldDebugSystem _gameDebug;
#endif

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
        GameWorld.Create();
        InputWorld.Create();
        
        _battleFeature = (BattleFeature)_systemFactory.Create<BattleFeature>();
        
#if UNITY_EDITOR
        var dummyInputSystems = new EcsSystems(InputWorld.Instance);
        var dummyGameSystems = new EcsSystems(GameWorld.Instance);
        
        _inputDebug = new EcsWorldDebugSystem(null, null);
        _gameDebug = new EcsWorldDebugSystem(null, null);
        
        ((EcsWorld)InputWorld.Instance).AddEventListener(_inputDebug);
        ((EcsWorld)GameWorld.Instance).AddEventListener(_gameDebug);

        _inputDebug.PreInit(dummyInputSystems);
        _gameDebug.PreInit(dummyGameSystems);
#endif
        
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
        
#if UNITY_EDITOR
        ((EcsWorld)InputWorld.Instance).RemoveEventListener(_inputDebug);
        ((EcsWorld)GameWorld.Instance).RemoveEventListener(_gameDebug);
#endif
        
        _lifetimeEventsProducer.EventInitialize -= OnInitialize;
        _lifetimeEventsProducer.EventFixedUpdate -= OnFixedUpdate;
        _lifetimeEventsProducer.EventUpdate -= OnUpdate;
        _lifetimeEventsProducer.EventLateUpdate -= OnLateUpdate;
        _lifetimeEventsProducer.EventDestroy -= OnDestroy;
        
        GameWorld.Destroy();
        InputWorld.Destroy();
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
#if UNITY_EDITOR
        _inputDebug.Run(null);
        _gameDebug.Run(null);
#endif
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