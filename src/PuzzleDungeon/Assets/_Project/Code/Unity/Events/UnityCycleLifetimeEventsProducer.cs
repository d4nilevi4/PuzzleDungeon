using System;
using PuzzleDungeon.Core.Events;
using UnityEngine;

namespace PuzzleDungeon.Unity.Events
{
    public class UnityCycleLifetimeEventsProducer : MonoBehaviour, ILifetimeEventsProducer
    {
        public event Action EventInitialize;
        public event Action EventFixedUpdate;
        public event Action EventUpdate;
        public event Action EventLateUpdate;
        public event Action EventDestroy;

        private void Start()
        {
            EventInitialize?.Invoke();
        }
    
        private void FixedUpdate()
        {
            EventFixedUpdate?.Invoke();
        }
    
        private void Update()
        {
            EventUpdate?.Invoke();
        }
    
        private void LateUpdate()
        {
            EventLateUpdate?.Invoke();
        }
    
        private void OnDestroy()
        {
            EventDestroy?.Invoke();
        }
    }
}