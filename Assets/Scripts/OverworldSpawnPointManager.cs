using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldSpawnPointManager : MonoBehaviour
{
    [SerializeField] Transform player, stumpSpawnPoint, DockSpawnPoint, LogSpawnPoint;

    private void Awake()
    {
        switch (SceneLoader.lastScene)
        {
            case SceneLoader.Scenes.Stump:
                player.position = stumpSpawnPoint.position;
                break;
            case SceneLoader.Scenes.Dock:
                player.position = DockSpawnPoint.position;
                break;
            case SceneLoader.Scenes.Log:
                player.position = LogSpawnPoint.position;
                break;
        }
    }
}
