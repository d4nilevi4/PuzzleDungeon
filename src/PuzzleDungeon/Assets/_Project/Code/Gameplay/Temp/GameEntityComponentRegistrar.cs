using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Core
{
    public abstract class GameEntityComponentRegistrar : MonoBehaviour
    {
        public abstract void RegisterComponents(GameEntity entity);
    }
}