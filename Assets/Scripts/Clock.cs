using UnityEngine;

public class Clock : MonoBehaviour
{
    private float currentTime = 0f;

    void Start()
    {
        currentTime = 0f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
    }

    public float GetCurrentTime() { return currentTime; }
}
