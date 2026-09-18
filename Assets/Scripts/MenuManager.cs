using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitButton() 
    {
        GameManager.Instance.QuitGame();
    }

    public void StartButton() 
    {
        GameManager.Instance.StartGame();
    }
}
