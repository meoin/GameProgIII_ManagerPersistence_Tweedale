using UnityEngine;

public class RoomActivation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DisableRoom();
    }

    public void ActivateRoom() 
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        TransitionManager transitionManager = GetComponentInChildren<TransitionManager>();

        if (transitionManager != null)
        {
            transitionManager.UpdateLoadedScenes();
        }
    }

    public void DisableRoom()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
