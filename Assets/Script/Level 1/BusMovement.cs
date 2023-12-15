using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    
    [SerializeField] private float speed = 10f;
    public bool isStopped = false;
    
    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isStopped)
        {
            myRigidBody.velocity = new Vector2(0f, 0f);
            return;
        }
        myRigidBody.velocity = new Vector2(speed * -1, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ZebraCross"))
        {
            if (FindObjectOfType<TrafficController>().canWalk)
            {
                isStopped = true; 
            }
        }

        if (other.CompareTag("Player"))
        {
            isStopped = true;
            FindObjectOfType<TrafficController>().canWalk = true;
        }

        if (other.CompareTag("Stop"))
        {
            Destroy(gameObject);
        }
    }

}
