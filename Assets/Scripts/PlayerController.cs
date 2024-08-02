using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 7f;
    [SerializeField] float boostSpeed = 1f;
    [SerializeField] float baseSpeed = 20f;

    private Rigidbody2D rb2D;
    private SurfaceEffector2D sf2D;

    private bool controlActive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sf2D = FindObjectOfType<SurfaceEffector2D>(); //works only because there is only one surface effector component in the scene
    }

    // Update is called once per frame
    void Update()
    {
        if (controlActive)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControl()
    {
        controlActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
            sf2D.speed = baseSpeed;
    }

    private void RespondToBoost()
    {
        if (UnityEngine.Input.GetKey(KeyCode.W) && sf2D.speed <= 50f)
            sf2D.speed += boostSpeed;
        else if(sf2D.speed > baseSpeed)
            sf2D.speed -= boostSpeed * 5f;
    }

    private void RotatePlayer()
    {
        if (UnityEngine.Input.GetKey(KeyCode.Q))
            rb2D.AddTorque(torqueAmount);
        else if (UnityEngine.Input.GetKey(KeyCode.E))
            rb2D.AddTorque(-torqueAmount);
    }
}
