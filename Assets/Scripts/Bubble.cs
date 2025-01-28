using UnityEngine;
using System;
using System.Collections;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public float lifeTime;
    public Animator anime;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anime.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0.0f)
        {
            GameObject.Find("Pop_Sound").GetComponent<PopSound>().playPop();
            anime.enabled = true;
        }
    }

    void DeleteBubble()
    {
        Destroy(gameObject);
    }
}
