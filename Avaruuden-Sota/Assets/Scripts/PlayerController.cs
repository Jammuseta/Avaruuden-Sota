using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    public float xRange = 90;
    public float YRange = 10;
    public float bottomrange = 1;
    Rigidbody rb;
    public float currentSpeed;
    public GameObject gameOverUI;
    public AudioClip DeathSound;
    private AudioSource audioSource;
    public TextMeshProUGUI finalScoreText; // Reference to the Final Score text

    [Header("Laaseri")]
    public Transform LaaseriSpawnTransform;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            currentSpeed = movSpeed * 2f;  // Tuplataan nopeus
        }
        else
        {
            currentSpeed = movSpeed;  // Palautetaan normaali nopeus
        }


        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < bottomrange)
        {
            transform.position = new Vector3(transform.position.x, bottomrange, transform.position.z);
        }
        if (transform.position.y > YRange)
        {
            transform.position = new Vector3(transform.position.x, YRange, transform.position.z);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(projectilePrefab, LaaseriSpawnTransform.position, projectilePrefab.transform.rotation);
    }
    void OnTriggerEnter(Collider other)

    {

        if (other.CompareTag("vihu"))
        {

            // Soitetaan kuoleman ‰‰ni kun vihollinen osuu pelaajaan
            audioSource.PlayOneShot(DeathSound);
            GameOver();

        }

    }
    void GameOver()
    {
        // N‰ytet‰‰n Game Over canvas ja pys‰ytet‰‰n peli
        int finalScore = ScoreManager.Instance.GetFinalScore();
        finalScoreText.text = "Final Score: " + finalScore;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        MainMenu.GameIsOver = true;
    }
}
