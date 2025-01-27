using UnityEngine;
using System;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public float lifeTime;
    //public float BubbleSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(BubbleSpawner.Launch);
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0.0f)
        {
            DeleteBubble();
        }
        
    }

    void DeleteBubble()
    {
        Destroy(gameObject);
    }
}
