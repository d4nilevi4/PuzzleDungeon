using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Gameplay.Tiles;

public sealed class UpdateDraggingAnchorSystem : IExecuteSystem
{
    private readonly GameGroup _draggingEntities;
    private readonly InputGroup _mouseDeltas;
    private readonly GameGroup _mainCameras;

    public UpdateDraggingAnchorSystem()
    {
        _draggingEntities = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Dragging,
                GameMatcher.DraggingTileAnchorPosition));

        _mouseDeltas = InputWorld.GetGroup(InputMatcher
            .AllOf(
                InputMatcher.MousePosition));

        _mainCameras = GameWorld.GetGroup(GameMatcher.AllOf(GameMatcher.MainCamera));
    }

    public void Execute()
    {
        foreach (InputEntity mouseDelta in _mouseDeltas)
        foreach (GameEntity mainCamera in _mainCameras)
        foreach (GameEntity entity in _draggingEntities)
        {
            Vector2 pixelDelta = mouseDelta.MousePosition;
            Camera camera = mainCamera.MainCamera;

            Vector3 targetPos = camera.ScreenToWorldPoint(new Vector3(pixelDelta.x, pixelDelta.y, 8));
            
            entity.ReplaceDraggingTileAnchorPosition(targetPos);
        }
    }
}