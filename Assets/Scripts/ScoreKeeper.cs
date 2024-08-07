using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private const float pointsForFlip = 50f;
    private const float timerValue = 1f;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI flipAdderText;
    private DistanceKeeper distanceKeeper;
    private PlayerController playerController;
    private float score = 0f;
    private float displayFlipTextTimer = 0f;
    private int multiplier = 0;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        distanceKeeper = FindObjectOfType<DistanceKeeper>();
    }

    void Start()
    {
        scoreText.text = "0";   
        flipAdderText.text = "";
    }

    void Update() 
    { 
        if(playerController.GetControlActive())
            scoreText.text = (score + distanceKeeper.GetCurrentTravelledDistance()).ToString();
        displayFlipTextTimer -= Time.deltaTime;
        if (displayFlipTextTimer < 0f)
        {
            flipAdderText.text = "";
            multiplier = 0;
        }
    }

    public void AddFlip()
    {
        if (!playerController.GetControlActive())
            return;
        multiplier++;
        score += pointsForFlip;
        flipAdderText.text = "+" + (pointsForFlip * multiplier).ToString();
        displayFlipTextTimer = timerValue;
    }
}
