using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float force = 5f;
    public float currentSpeed = 0f;
    public float stepTaken = 0f;
    public bool gameOver = false;
    public bool gameEnd = false;
    public GameObject pauseMenu;
    public GameObject gameOverUI;
    public TMP_Text stepText;

    private Rigidbody rb;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }
    void Start()
    {
        gameOver = false;
        stepText.text = "Step Taken: " + stepTaken.ToString();
    }
    void Move()
    {
        stepTaken++;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        stepText.text = "Step Taken: " + stepTaken.ToString();
    }

    void Update()
    {
        if (Keyboard.current.shiftKey.isPressed)
        {
            force = 7f;
        }
        else
        {
            force = 5f;
        }

        if (currentSpeed <= 0.1 && Keyboard.current.wKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            Invoke("Move", 0.1f);

        }
        else if (currentSpeed <= 0.1 && Keyboard.current.aKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0f, -90f, 0f);
            Invoke("Move", 0.1f);

        }
        else if (currentSpeed <= 0.1 && Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
            Invoke("Move", 0.1f);

        }
        else if (currentSpeed <= 0.1 && Keyboard.current.sKey.wasPressedThisFrame)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            Invoke("Move", 0.1f);

        }

        if (!gameEnd || !gameOver)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame && !pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else if (Keyboard.current.escapeKey.wasPressedThisFrame && pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
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
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
        else if (other.gameObject.CompareTag("Goal"))
        {
            Destroy(player);
            SceneManager.LoadScene("Level2");
        }
        else if (other.gameObject.CompareTag("Exit"))
        {
            Debug.Log("Game End");
            Destroy(player);
            gameEnd = true;
            SceneManager.LoadScene("Credit");
        }
    }
}
