using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private DistanceKeeper distanceKeeper;
    
    void Awake()
    {
        distanceKeeper = FindObjectOfType<DistanceKeeper>();
    }

    void Start()
    {
        scoreText.text = "0000";    
    }

    void Update()
    {
        scoreText.text = distanceKeeper.GetCurrentTravelledDistance().ToString();
    }
}
