using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laaseri : MonoBehaviour
{
    public float speed = 60f;
    private GameObject vihu1;
    private bool hasHit = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Time.timeScale == 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (Time.timeScale == 0)
        {
            return;
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider other)
    {   // Tuhoaa vihollisen ja Tuhoaa pelaajan

        if (hasHit) {
            return;
        }

        if (other.CompareTag("vihu"))
        {
            hasHit = true;
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
