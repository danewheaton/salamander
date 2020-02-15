using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static Scenes lastScene;

    public enum Scenes { EstuaryOverworld, Stump, Dock, Log }

    [SerializeField] Scenes sceneToLoad;

    BoxCollider2D triggerZone;

    string overworldName = "EstuaryOverworld", stumpName = "Stump", dockName = "Dock", logName = "Hollow Tree";

    private void OnValidate()
    {
        if (!triggerZone)
        {
            BoxCollider2D myCollider = GetComponent<BoxCollider2D>();

            if (!myCollider)
            {
                gameObject.AddComponent<BoxCollider2D>();
            }

            triggerZone = myCollider;
            triggerZone.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string nameOfSceneToLoad = SceneManager.GetActiveScene().name;

        switch (sceneToLoad)
        {
            case Scenes.EstuaryOverworld:
                nameOfSceneToLoad = overworldName;
                break;
            case Scenes.Stump:
                nameOfSceneToLoad = stumpName;
                break;
            case Scenes.Dock:
                nameOfSceneToLoad = dockName;
                break;
            case Scenes.Log:
                nameOfSceneToLoad = logName;
                break;
        }

        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == stumpName)
        {
            lastScene = Scenes.Stump;
        }
        else if (sceneName == dockName)
        {
            lastScene = Scenes.Dock;
        }
        else if (sceneName == logName)
        {
            lastScene = Scenes.Log;
        }

        SceneManager.LoadScene(nameOfSceneToLoad);
    }
}
