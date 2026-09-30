using UnityEngine;
using UnityEngine.SceneManagement;

public class BootSequence : MonoBehaviour
{
    public static BootSequence Instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("BootScene", LoadSceneMode.Additive);
    }
}
