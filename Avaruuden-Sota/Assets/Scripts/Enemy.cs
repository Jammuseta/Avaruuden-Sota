using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private float speed = 20f;
    private Rigidbody vihu1;
    private GameObject pelaaja;

    // Start is called before the first frame update
    void Start()
    {    
        // Haetaan vihollisen Rigidbody ja Haetaan pelaaja
        vihu1 = GetComponent<Rigidbody>();  
        pelaaja = GameObject.Find("pelaaja");

    }

    // Update is called once per frame
    void Update()
    {
        if (pelaaja != null && vihu1 != null)
        {
            // Laske suunta pelaajaa kohti ja Asetetaan vihollisen nopeus suoraan pelaajaa kohti

            Vector3 lookDirection = (pelaaja.transform.position - transform.position).normalized;
            vihu1.velocity = lookDirection * speed;
        }
    }
}
