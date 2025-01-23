using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    //public float BubbleSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(BubbleSpawner.Launch);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0f, BubbleSpeed * Time.deltaTime, 0f);
        DeleteBubble();
    }

    IEnumerator DeleteBubble()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }


    }
}
