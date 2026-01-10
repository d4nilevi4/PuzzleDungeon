using UnityEngine;
using UnityEngine.SceneManagement;

namespace PuzzleDungeon.Infrastructure
{
    public class SwitchToEntrySceneInEditor : MonoBehaviour
    {
#if UNITY_EDITOR
        public const string CURRENT_SCENE_NAME_KEY = "CurrentSceneNameKey";

        public bool LoadCurrentScene;

        private void Awake()
        {
            if (IsRootContainerAlreadyInitialized())
                return;

            foreach (GameObject root in gameObject.scene.GetRootGameObjects())
                root.SetActive(false);

            if (LoadCurrentScene)
            {
                UnityEditor.EditorPrefs.SetString(
                    key: CURRENT_SCENE_NAME_KEY,
                    value: SceneManager.GetActiveScene().name);
            }

            SceneManager.LoadScene(SceneNames.BOOTSTRAP_SCENE);

            return;

            bool IsRootContainerAlreadyInitialized()
            {
                return FindFirstObjectByType<RootLifetimeScope>() != null;
            }
        }
#endif
    }
}