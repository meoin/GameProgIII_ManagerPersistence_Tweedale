using UnityEngine;

public class TransitionPoint : MonoBehaviour
{
    public string ID = "DEFAULT";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (GameManager.Instance.TransitionPoint == ID) 
        {
            Debug.Log($"Transition point {ID} found.");

            Vector3 newPlayerPosition = transform.position;

            if (GameManager.Instance.MaintainY) newPlayerPosition.y = GameManager.Instance.Player.transform.position.y;

            Debug.Log($"Player currently at {GameManager.Instance.Player.transform.position}");
            Debug.Log($"Putting player at {newPlayerPosition}");

            GameManager.Instance.Player.transform.position = newPlayerPosition;

            Debug.Log($"Player now at {GameManager.Instance.Player.transform.position}");
        }   
    }
}
