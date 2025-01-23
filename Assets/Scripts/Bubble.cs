using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float BubbleSpeed;
    public BoxCollider2D Player;
    void Start()
    {
        DeleteBubble();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, BubbleSpeed * Time.deltaTime, 0f);
        
    }

    IEnumerator DeleteBubble()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }


    }

    //private void OnCollisionEnter2D(Collision2D Player)
    //{
    //    Destroy(gameObject);
    //}
}
