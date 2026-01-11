using PuzzleDungeon.Core.View;
using UnityEngine;

namespace PuzzleDungeon.Unity.View;

public class UnityEntityViewFactory : IEntityViewFactory
{
    public TView Create<TView>(TView viewPrefab) where TView : IEntityView
    {
        var prefabGameObject = (viewPrefab as MonoBehaviour)?.gameObject;
        
        if (prefabGameObject == null)
        {
            throw new System.ArgumentException("viewPrefab must be a MonoBehaviour");
        }
            
        var instance = Object.Instantiate(prefabGameObject);
        var entityView = instance.GetComponent<TView>();
        
        if (entityView == null)
        {
            throw new System.InvalidOperationException("Instantiated object does not contain the required IEntityView component");
        }

        return entityView;
    }
}