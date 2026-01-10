using UnityEngine;

namespace PuzzleDungeon.Infrastructure;

public interface IEntityView
{
    Vector3 Position { get; set; }
    Quaternion Rotation { get; set; }
    Vector3 Scale { get; set; }
    
    bool IsVisible { get; set; }
    
    void Destroy();
}