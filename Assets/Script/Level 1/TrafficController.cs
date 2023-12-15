using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    SpriteRenderer lightColor;
    [SerializeField] Color originalColor;
    [SerializeField] Color clickedColor;
    public bool canWalk = false;
    Animator animator;
        
    void Start()
    {
        lightColor = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        lightColor.color = clickedColor;
        canWalk = true;
        animator.SetBool("IsGreen", true);
    }

}
