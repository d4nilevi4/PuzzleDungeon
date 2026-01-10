using PuzzleDungeon.Core.View;
using UnityEngine;

namespace PuzzleDungeon.Unity.View
{
    public class UnityEntityView : MonoBehaviour, IEntityView
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public Quaternion Rotation
        {
            get => transform.rotation;
            set => transform.rotation = value;
        }

        public Vector3 Scale
        {
            get => transform.localScale;
            set => transform.localScale = value;
        }

        public bool IsVisible
        {
            get => isActiveAndEnabled;
            set => gameObject.SetActive(value);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}