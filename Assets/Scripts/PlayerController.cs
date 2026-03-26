using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float force = 10;
    public float currentSpeed = 0;
    public bool gameOver = false;
    public bool gameEnd = false;

    private Rigidbody rb;
    private GameObject player;
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

        gameOver = false;
    }
    void Move()
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    void Update()
    {
        if (currentSpeed <= 0.1 && moveUp.triggered)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            Invoke("Move", 0.1f);

        }
        else if (currentSpeed <= 0.1 && moveLeft.triggered)
        {
            transform.eulerAngles = new Vector3(0f, -90f, 0f);
            Invoke("Move", 0.1f);

        }
        else if (currentSpeed <= 0.1 && moveRight.triggered)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
            Invoke("Move", 0.1f);

        }
        else if (currentSpeed <= 0.1 && moveDown.triggered)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Invoke("Move", 0.1f);

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentSpeed = rb.linearVelocity.magnitude;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Game Over");
            Destroy(player);
            gameOver = true;
            Time.timeScale = 0;
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Game End");
            gameEnd = true;
            Time.timeScale = 0;
        }
    }
}
