using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private UIManager UIManager;
    public PlayerControl Player;
    public FollowCamera Camera;
    public bool MaintainY;
    public string TransitionPoint = "DEFAULT";
    public string CurrentRoom = "StartRoom";
    public List<string> LoadedScenes = new List<string>();

    private int _health = 100;
    public int Health
    {
        get { return _health; }
        private set { _health = value; }
    }
    private int _xp = 0;
    public int Xp
    {
        get { return _xp; }
        private set { _xp = value; }
    }
    private int _score = 0;
    public int Score
    {
        get { return _score; }
        private set { _score = value; }
    }


    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUIDisplays();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) Health += 10;
        if (Input.GetKeyDown(KeyCode.DownArrow)) Health -= 10;

        Health = Mathf.Clamp(Health, 0, 100);

        if (Input.GetKeyDown(KeyCode.Space)) Score += 25;
        if (Input.GetKeyDown(KeyCode.LeftShift)) Score *= 2;

        if (Input.GetKeyDown(KeyCode.X)) Xp += Random.Range(5, 50);

        UpdateUIDisplays();
    }

    void UpdateUIDisplays() 
    {
        UIManager.SetHealthDisplay(Health);
        UIManager.SetScoreDisplay(Score);
        UIManager.SetXPDisplay(Xp);
    }

    public void ToggleUI(bool toggle) 
    {
        UIManager.gameObject.SetActive(toggle);
    }

    public void StartGame() 
    {
        LoadScene(CurrentRoom, false);
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        Player.gameObject.SetActive(true);
        ToggleUI(true);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene {scene.name} is fully loaded!");

        if (scene.name == CurrentRoom) 
        {
            GameObject.Find(CurrentRoom).GetComponent<RoomActivation>().ActivateRoom();
        }
    }

    public void QuitGame() 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void LoadScene(string sceneName, bool additive) 
    {
        if (additive) SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        else SceneManager.LoadScene(sceneName);

        LoadedScenes.Add(sceneName);
    }

    public void UnloadScene(string sceneName) 
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
