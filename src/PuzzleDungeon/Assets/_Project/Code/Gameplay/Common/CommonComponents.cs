using Leontitas;
using PuzzleDungeon.Core.View;

namespace PuzzleDungeon.Gameplay;

[Game] public struct EntityView : IComponent { public IEntityView Value; }

[Game, Input] public struct Event : IComponent { }