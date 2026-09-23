using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    public string SceneName;
    public bool maintainY = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            GameManager.Instance.MaintainY = maintainY;

            SceneManager.LoadScene(SceneName);
        }
    }
}
