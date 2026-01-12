using Leontitas;

namespace PuzzleDungeon.Gameplay.Identification;

[Game] public struct Id : IComponent { public int Value; }
[Game] public struct NextId : IComponent { public int Value; }
[Game] public struct NeedId : IComponent { }