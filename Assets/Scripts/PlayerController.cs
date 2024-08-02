using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 7f;
    private Rigidbody2D rb2D;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.Q))
            rb2D.AddTorque(torqueAmount);
        else if (UnityEngine.Input.GetKey(KeyCode.E))
            rb2D.AddTorque(-torqueAmount);
    }
}
