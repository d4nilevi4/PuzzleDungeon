using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

[Game] public struct Draggable : IComponent {  }
[Game] public struct Dragging : IComponent {  }
[Game] public struct DraggingTileAnchorPosition : IComponent { public Vector3 Value; }
[Game] public struct UpdateTargetPositionByDraggingTileAnchor : IComponent { }