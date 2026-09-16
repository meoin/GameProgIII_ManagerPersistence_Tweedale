using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthDisplay;
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI xpDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealthDisplay(int hp) 
    {
        healthDisplay.text = "Health: " + hp;
    }
    public void SetScoreDisplay(int score)
    {
        scoreDisplay.text = "Score: " + score;
    }
    public void SetXPDisplay(int score)
    {
        xpDisplay.text = "XP: " + score;
    }
}
