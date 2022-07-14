using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float steerSpeed = 1f;

    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;

    [SerializeField] float timeDespawn = 0.3f;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Slow")
        {
            moveSpeed = slowSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SpeedBoost")
        {
            Debug.Log("Going fast!");
            Destroy(collision.gameObject, timeDespawn);
            moveSpeed = boostSpeed;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}
