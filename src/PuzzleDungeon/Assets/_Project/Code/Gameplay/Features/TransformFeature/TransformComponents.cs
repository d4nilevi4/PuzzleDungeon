using Leontitas;

namespace PuzzleDungeon.Gameplay.Transform;

[Game] public struct Position : IComponent { public Vector3 Value; }
[Game] public struct Rotation : IComponent { public Quaternion Value; }
[Game] public struct Scale : IComponent { public Vector3 Value; }