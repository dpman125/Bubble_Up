using System.Collections;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float AimSpeed;
    public float PowerSpeed;
    public float LaunchMod;
    public GameObject Bubble;
    private Vector3 offset;
    public Vector2 Aim;
    public Vector2 Launch;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {  
        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            offset = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            var _b = Instantiate(Bubble, offset, transform.rotation);
            _b.GetComponent<Rigidbody2D>().linearVelocity = Launch;
        }
        
        //Aim
        if (Input.GetKey(KeyCode.RightArrow) && Aim.x < 90)
        {
            Aim.x += AimSpeed * Time.deltaTime;
        }        
        if (Input.GetKey(KeyCode.LeftArrow) && Aim.x > 0)
        {
            Aim.x -= AimSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) && Aim.y < 1)
        {
            Aim.y += PowerSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) && Aim.y > 0)
        {
            Aim.y -= PowerSpeed * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, -Aim.x);
        Launch = transform.up * Aim.y * LaunchMod;
    }

   

}
