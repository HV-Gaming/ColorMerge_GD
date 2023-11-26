using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI MovesText;
    
    private float currentTime;
    public GameObject GameOverPanel;
    public GameObject LevelCompletedPanel;
    public GameObject GamePanel;
    public GameObject TaptoBegin;
    public GameObject GameVcam;

    public SwipeDetection SwipeScript;
    public int movesAllowed;
    public float totalTime = 60f; // Total time in seconds
    private int remainingMoves;

    void Start()
    {
        Time.timeScale =0;
        TaptoBegin.SetActive(true);
        GameOverPanel.SetActive(false);
        currentTime = totalTime;
        
    }

    void Update()
    {
        remainingMoves = movesAllowed - SwipeScript.swipeCount;

        if(SwipeScript.swipeCount >= movesAllowed+1)
        {
                GameOverPanel.SetActive(true);
                GamePanel.SetActive(false);
                GameVcam.SetActive(false);
                Time.timeScale =0;

        }
        MovesText.text = remainingMoves.ToString();


        if(TaptoBegin.activeSelf)
        {
            Time.timeScale =0;
            

        }
        else
        {
            Time.timeScale =1;
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
            // Timer has reached 0, you can add code here for what happens when the timer finishes.
                GameOverPanel.SetActive(true);
                GamePanel.SetActive(false);
                GameVcam.SetActive(false);
            }



        }

        if(LevelCompletedPanel.activeSelf)
        {
            Time.timeScale =0f;
            GameOverPanel.SetActive(false);

        }
        
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
