using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Gameplay.Interactions;

public sealed class CheckMouseHoverSystem : IPreExecuteSystem
{
    private readonly InputGroup _mousePositions;
    private readonly GameGroup _interactables;
    private readonly GameGroup _mainCameras;
    private readonly RaycastHit[] _raycastHits = new RaycastHit[1];

    public CheckMouseHoverSystem()
    {
        _mousePositions = InputWorld.GetGroup(InputMatcher.AllOf(InputMatcher.MousePosition));
        _mainCameras = GameWorld.GetGroup(GameMatcher.AllOf(GameMatcher.MainCamera));

        _interactables = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Interactable,
                GameMatcher.InteractionCollider));
    }

    public void PreExecute()
    {
        foreach (InputEntity mousePosition in _mousePositions)
        foreach (GameEntity mainCamera in _mainCameras)
        {
            Ray ray = CreateRayFromMouse(mainCamera, mousePosition);

            if (TryGetHoveredCollider(ray, out Collider hoveredCollider))
            {
                UpdateHoverStates(hoveredCollider);
            }
            else
            {
                ClearAllHoverStates();
            }
        }
    }

    private Ray CreateRayFromMouse(GameEntity camera, InputEntity mousePosition)
    {
        return camera.MainCamera.ScreenPointToRay(mousePosition.MousePosition);
    }

    private bool TryGetHoveredCollider(Ray ray, out Collider hoveredCollider)
    {
        int hitCount = Physics.RaycastNonAlloc(ray, _raycastHits, Mathf.Infinity);
        hoveredCollider = hitCount > 0 ? _raycastHits[0].collider : null;
        return hitCount > 0;
    }

    private void UpdateHoverStates(Collider hoveredCollider)
    {
        foreach (GameEntity interactable in _interactables)
        {
            bool isHovering = interactable.InteractionCollider == hoveredCollider;
            interactable.IsHovered = isHovering;
        }
    }

    private void ClearAllHoverStates()
    {
        foreach (GameEntity interactable in _interactables)
        {
            interactable.IsHovered = false;
        }
    }
}