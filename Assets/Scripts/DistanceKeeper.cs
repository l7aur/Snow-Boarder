using UnityEngine;

public class DistanceKeeper : MonoBehaviour
{
    private float distanceTravelled = 0f;
    private Clock clock;
    private PlayerController playerController;

    void Awake()
    {
        clock = FindObjectOfType<Clock>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Start()
    {
        distanceTravelled = 0f;
    }

    void Update()
    {
        distanceTravelled += playerController.GetCurrentSpeed() * clock.GetCurrentTime() / 10000f;
    }

    public float GetCurrentTravelledDistance() { return Mathf.RoundToInt(distanceTravelled); }

}
