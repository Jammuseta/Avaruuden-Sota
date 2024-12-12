using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    public float xRange = 90;
    public float YRange = 10;
    public float bottomrange = 1;
    Rigidbody rb;
    public float currentSpeed;

    [Header("Laaseri")]
    public Transform LaaseriSpawnTransform;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movSpeed;
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
}
