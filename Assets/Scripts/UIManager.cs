using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthDisplay;
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI xpDisplay;
    [SerializeField] private GameObject GameplayPanel;
    [SerializeField] private GameObject PausePanel;

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

    public void ToggleGameplayUI(bool toggle) 
    {
        GameplayPanel.gameObject.SetActive(toggle);
    }

    public void TogglePauseMenu(bool toggle) 
    {
        PausePanel.gameObject.SetActive(toggle);
    }
}
