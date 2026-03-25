using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float force = 10;
    public float currentSpeed = 0;

    private Rigidbody rb;
    public GameObject player;
    private InputAction moveUp;
    private InputAction moveLeft;
    private InputAction moveRight;
    private InputAction moveDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    void Start()
    {
        moveUp = InputSystem.actions.FindAction("MoveUp");
        moveLeft = InputSystem.actions.FindAction("MoveLeft");
        moveRight = InputSystem.actions.FindAction("MoveRight");
        moveDown = InputSystem.actions.FindAction("MoveDown");
    }

    void Update()
    {
        if (currentSpeed <= 0.1 && moveUp.triggered)
        {
            player.transform.Rotate(0, 0, 0);
            rb.AddForce(transform.forward * force, ForceMode.Impulse);

        }
        else if (currentSpeed <= 0.1 && moveLeft.triggered)
        {
            player.transform.Rotate(0, -90, 0);
            rb.AddForce(transform.forward * force, ForceMode.Impulse);

        }
        else if (currentSpeed <= 0.1 && moveRight.triggered)
        {
            player.transform.Rotate(0, 90, 0);
            rb.AddForce(transform.forward * force, ForceMode.Impulse);

        }
        else if (currentSpeed <= 0.1 && moveDown.triggered)
        {
            player.transform.Rotate(0, 180, 0);
            rb.AddForce(transform.forward * force, ForceMode.Impulse);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentSpeed = rb.linearVelocity.magnitude;
    }
}
