using System.Collections.Generic;
using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

[Game] public struct GameBoardTileInHand : IComponent { }
[Game] public struct GameBoardTilesInHandCount : IComponent { public int Value; }
[Game] public struct GameBoardTileInHandOrderIndex : IComponent { public int Value; }

[Game] public struct Hand : IComponent { }
[Game] public struct LinkedHand : IComponent { public int Value; }
[Game] public struct TileThickness : IComponent { public float Value; }

[Game] public struct UpdateTargetPositionByInHandTileAnchor : IComponent { }
[Game] public struct InHandTileAnchorPosition : IComponent { public Vector3 Value; }
[Game] public struct InHandTileAnchorDeltas : IComponent { public List<AnchorDeltaPosition> Value; }

[Game] public struct InHandTileHoverDelta : IComponent { public float Value; }