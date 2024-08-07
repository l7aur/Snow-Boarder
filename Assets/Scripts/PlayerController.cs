using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] const float boostSpeed = 0.5f;
    [SerializeField] const float baseSpeed = 20f;

    private Rigidbody2D rb2D;
    private SurfaceEffector2D sf2D;

    private bool controlActive = true;

    void Awake()
    {
        sf2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

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
        sf2D.speed = 10f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            sf2D.speed = baseSpeed;
    }

    private void RespondToBoost()
    {
        if (controlActive)
        {
            if (UnityEngine.Input.GetKey(KeyCode.W) && sf2D.speed < baseSpeed + 10f)
                sf2D.speed += boostSpeed;
            else if (UnityEngine.Input.GetKey(KeyCode.S) && sf2D.speed > baseSpeed - 10f)
                sf2D.speed -= boostSpeed * 0.1f;
            else if (sf2D.speed > baseSpeed)
                sf2D.speed -= 0.1f;
        }
    }

    private void RotatePlayer()
    {
        if (controlActive)
        {
            if (UnityEngine.Input.GetKey(KeyCode.A))
                rb2D.totalTorque = Random.Range(0f, 7.5f);
            if (UnityEngine.Input.GetKey(KeyCode.D))
                rb2D.totalTorque = -Random.Range(0f, 7.5f);
        }
    }

    public float GetCurrentSpeed() { return sf2D.speed; }
    public bool GetControlActive() { return controlActive; }
}
