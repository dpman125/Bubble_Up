using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class Bubble : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    public float lifeTime;
    private IEnumerator coroutine;
    public AudioSource audio;
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
            
            coroutine = DeleteBubble();
            StartCoroutine(coroutine);
        }
        
    }

    IEnumerator DeleteBubble()
    {
        
        audio.Play();
        float timeToWait = .3f;
        // play audio
        
        yield return new WaitForSeconds(timeToWait);
        Destroy(gameObject);
        
        
    }
}
