using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    [SerializeField] Sprite winSprite;
    [SerializeField] Sprite loseSprite;
    [SerializeField] float playerSpeed = 3f;
    private bool isFinish = false;
    private SpriteRenderer spriteRenderer;
    AudioSource source;
    [SerializeField] AudioClip winSound;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        if (!isFinish)
        {
            myRigidBody.velocity = new Vector2(0f, playerSpeed * -1);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bus"))
        {
            spriteRenderer.sprite = loseSprite;
            myRigidBody.velocity = new Vector2(-5f, 5f);
            StartCoroutine(RestartLevel());
        }

        if (other.CompareTag("Finish"))
        {
            isFinish = true;
            myRigidBody.velocity = new Vector2(0f, 0f);
            spriteRenderer.sprite = winSprite;
            source.PlayOneShot(winSound);
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSecondsRealtime(2f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(2);
    }

}