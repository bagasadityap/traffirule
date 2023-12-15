using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusMovement3 : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    
    [SerializeField] private float speed = 10f;
    public bool isFinish = false;
    public bool isStopped = false;
    AudioSource source;
    [SerializeField] AudioClip winSound;
    
    private void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isStopped)
        {
            myRigidBody.velocity = new Vector2(0f, 0f);
            return;
        }

        if (FindObjectOfType<Timer>().timeLeft <= 0)
        {
            myRigidBody.velocity = new Vector2(speed * -1, 0f);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isStopped = true;
        }

        if (other.CompareTag("Stop"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene(4);
        }
        
        if (other.CompareTag("WinCheck"))
        {
            source.PlayOneShot(winSound);
            this.isFinish = true;
        }
    }

}
