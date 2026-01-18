using Leontitas;
using UnityEngine;

namespace PuzzleDungeon.Gameplay.Transformation;

public sealed class RotateTowardsMainCameraSystem : IExecuteSystem
{
    private readonly GameGroup _rotatables;
    private readonly GameGroup _mainCameras;

    public RotateTowardsMainCameraSystem()
    {
        _rotatables = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.Rotatable,
                GameMatcher.Rotation,
                GameMatcher.RotateTowardsCamera));
        
        _mainCameras = GameWorld.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.MainCamera));
    }
    
    public void Execute()
    {
        foreach (GameEntity rotatable in _rotatables)
        foreach (GameEntity camera in _mainCameras)
        {
            Vector3 directionToCamera = -camera.MainCamera.transform.forward;
            
            if (Mathf.Approximately(directionToCamera.sqrMagnitude, 0f))
                continue;

            Quaternion targetRotation = Quaternion.LookRotation(
                forward: directionToCamera,
                upwards: camera.MainCamera.transform.up);
            
            rotatable.ChangeRotation(targetRotation);
        }
    }
}