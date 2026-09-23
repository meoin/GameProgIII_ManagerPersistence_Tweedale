using UnityEngine;

public class TransitionPoint : MonoBehaviour
{
    public string ID = "DEFAULT";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance.TransitionPoint == ID) 
        {
            Vector3 newPlayerPosition = transform.position;

            if (GameManager.Instance.MaintainY) newPlayerPosition.y = GameManager.Instance.Player.transform.position.y;

            GameManager.Instance.Player.transform.position = transform.position;
        }   
    }
}
