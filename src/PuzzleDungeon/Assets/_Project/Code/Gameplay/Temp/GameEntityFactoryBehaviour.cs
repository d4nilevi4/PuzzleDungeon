using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Core
{
    public sealed class GameEntityFactoryBehaviour : MonoBehaviour
    {
        private void Start()
        {
            GameEntityComponentRegistrar[] registrars =
                GetComponentsInChildren<GameEntityComponentRegistrar>();

            GameEntity entity = GameEntity.Create();

            foreach (GameEntityComponentRegistrar registrar in registrars)
            {
                registrar.RegisterComponents(entity);
            }
        }
    }
}