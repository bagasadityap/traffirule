using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement1 : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] float playerSpeed = 3f;
    private bool isFinish = false;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown() {
        if (!isFinish)
        {
            myRigidBody.velocity = new Vector2(0f, playerSpeed * 1);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bus"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            isFinish = true;
            myRigidBody.velocity = new Vector2(0f, 0f);
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene() {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(0);
    }
}
