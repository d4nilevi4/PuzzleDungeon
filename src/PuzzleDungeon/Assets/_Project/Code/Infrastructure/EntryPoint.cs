using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer;
using VContainer.Unity;

namespace PuzzleDungeon.Infrastructure
{
    public class EntryPoint : IAsyncStartable
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public UniTask StartAsync(CancellationToken cancellation)
        {
            return _gameStateMachine.Enter<BootstrapState>(cancellation);
        }
    }
}