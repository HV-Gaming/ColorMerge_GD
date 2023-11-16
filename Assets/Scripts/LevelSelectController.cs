using UnityEngine;
using UnityEngine.UI;

public class LevelSelectController : MonoBehaviour
{
    public Button[] levelButtons; // Assign your level buttons in the Inspector
    public int currentPlayerLevel; // You can get this from your game data or player progress

    public Sprite greenSprite;
    public Sprite orangeSprite;
    public Sprite greySprite;


     void Awake()
    {
        
        
    }
    void Start()
    {
        currentPlayerLevel = GameManager.Instance.GetPlayerLevel();
        UpdateButtonSprites();

    }

    void UpdateButtonSprites()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 == currentPlayerLevel)
            {
                // Current level button
                levelButtons[i].image.sprite = greenSprite;
            }
            else if (i + 1 < currentPlayerLevel)
            {
                // Levels below the current level
                levelButtons[i].image.sprite = orangeSprite;
            }
            else
            {
                levelButtons[i].interactable = false;
                // Levels above the current level
                levelButtons[i].image.sprite = greySprite;
            }
        }
    }

    // private void Update() {
    //     currentPlayerLevel = GameManager.Instance.GetPlayerLevel();
    //     UpdateButtonSprites();
    // }

    private void OnEnable() {
        currentPlayerLevel = GameManager.Instance.GetPlayerLevel();
        UpdateButtonSprites();
        
    }
    
}
