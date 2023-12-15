using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Image timer;
    [SerializeField] float maxTime = 5f;
    public float timeLeft;

    void Start()
    {
        timer = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if (FindObjectOfType<LevelManager>().canvasDisabled)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timer.fillAmount = timeLeft/maxTime;
            }
        }
    }
}
