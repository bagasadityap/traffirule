using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement3 : MonoBehaviour
{
    private bool isDragging = false;
    public bool isWin = false;
    private Vector3 offset;
    public Collider2D restrictedArea1;
    public Collider2D restrictedArea2;
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (FindObjectOfType<BusMovement3>().isFinish)
        {
            this.isWin = true;
            animator.SetBool("IsHappy", true);
        }

        if (isDragging && FindObjectOfType<Timer>().timeLeft > 0)
        {
            Vector3 desiredPosition = GetMouseWorldPosition() + offset;

            if (!IsPositionWithinRestrictedArea(desiredPosition))
            {
                transform.position = desiredPosition;
            }
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private bool IsPositionWithinRestrictedArea(Vector3 position)
    {
        if (restrictedArea1 != null && restrictedArea1.bounds.Contains(position))
        {
            return true;
        }

        if (restrictedArea2 != null && restrictedArea2.bounds.Contains(position))
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bus"))
        {
            animator.SetBool("IsFall", true);
            StartCoroutine(RestartLevel());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trotoar"))
        {
            animator.SetBool("IsHappy", false);
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(3);
    }
}
