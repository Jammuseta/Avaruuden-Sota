using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    public float topBound;
    public float bottomBound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
    }
}