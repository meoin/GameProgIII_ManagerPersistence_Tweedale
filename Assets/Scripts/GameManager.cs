using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private UIManager UIManager;

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
}
