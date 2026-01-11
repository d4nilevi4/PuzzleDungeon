using System;

namespace PuzzleDungeon.Core.Events;

public interface ILifetimeEventsProducer
{
    event Action EventInitialize;
    event Action EventFixedUpdate;
    event Action EventUpdate;
    event Action EventLateUpdate;
    event Action EventDestroy;
}