using Leontitas;

namespace PuzzleDungeon.Gameplay.Tiles;

[Game] public struct GameBoardTileInHand : IComponent { }
[Game] public struct GameBoardTilesInHandCount : IComponent { public int Value; }
[Game] public struct GameBoardTileInHandOrderIndex : IComponent { public int Value; }

[Game] public struct Hand : IComponent { }
[Game] public struct LinkedHand : IComponent { public int Value; }
[Game] public struct HandPosition : IComponent { public Vector3 Value; }
[Game] public struct InHandTileAnchor : IComponent { public Vector3 Value; }
[Game] public struct TileSpacing : IComponent { public float Value; }