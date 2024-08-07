using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTracker : MonoBehaviour
{
    private float cumulativeRotation = 0f;
    private float previousRotation = 0f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotation = transform.eulerAngles.z;
        float deltaRotation = currentRotation - previousRotation;

        // Handle the case where rotation wraps around 360 degrees
        if (deltaRotation < -180f)
        {
            deltaRotation += 360f;
        }
        else if (deltaRotation > 180f)
        {
            deltaRotation -= 360f;
        }

        cumulativeRotation += deltaRotation;
        previousRotation = currentRotation;

        if (Mathf.Abs(cumulativeRotation) >= 360f)
        {
            cumulativeRotation = 0f;
            scoreKeeper.AddFlip();
        }
    }
}
