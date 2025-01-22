using System.Collections;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Speed;
    public GameObject Bubble;
    private Vector3 offset;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            offset = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Instantiate(Bubble, offset, transform.rotation);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Speed * Time.deltaTime, 0f, 0f);
        }
    }

   
}
