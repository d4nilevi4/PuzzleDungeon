using Leontitas;

namespace PuzzleDungeon.Gameplay.Transform;

[Game] public struct Movable : IComponent { }
[Game] public struct TargetPosition : IComponent { public Vector3 Value; }