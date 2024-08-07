using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] const float torqueAmount = 5f;
    [SerializeField] const float boostSpeed = 0.5f;
    [SerializeField] const float baseSpeed = 20f;

    private Rigidbody2D rb2D;
    private SurfaceEffector2D sf2D;

    private bool controlActive = true;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sf2D = FindObjectOfType<SurfaceEffector2D>(); //works only because there is only one surface effector component in the scene
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
                rb2D.AddTorque((torqueAmount + Random.Range(0f, 15f)) * sf2D.speed / (sf2D.speed - 1f));
            else if (UnityEngine.Input.GetKey(KeyCode.D))
                rb2D.AddTorque(-(torqueAmount + Random.Range(0f, 15f)) * sf2D.speed / (sf2D.speed - 1f));
        }
    }

    public float GetCurrentSpeed() { return sf2D.speed; }
}
