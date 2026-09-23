using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public void UpdateLoadedScenes() 
    {
        List<string> loadedScenes = GameManager.Instance.LoadedScenes;
        List<string> scenesToKeepLoaded = new List<string>();

        RoomTransition[] transitions = GetComponentsInChildren<RoomTransition>(true);

        scenesToKeepLoaded.Add(GameManager.Instance.CurrentRoom);

        foreach (RoomTransition transition in transitions)
        {
            scenesToKeepLoaded.Add(transition.SceneName);
        }

        foreach (string sceneName in loadedScenes) 
        {
            if (!scenesToKeepLoaded.Contains(sceneName)) 
            {
                GameManager.Instance.UnloadScene(sceneName);
            }
        }

        GameManager.Instance.LoadedScenes.RemoveAll(scene => !scenesToKeepLoaded.Contains(scene));

        foreach (string sceneName in scenesToKeepLoaded) 
        {
            if (!loadedScenes.Contains(sceneName)) 
            {
                GameManager.Instance.LoadScene(sceneName, true);
            }
        }
    }
}
