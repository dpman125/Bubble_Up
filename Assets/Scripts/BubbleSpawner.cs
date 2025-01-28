using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float AimSpeed;
    public float PowerSpeed;
    public float LaunchMod;
    public GameObject Bubble;
    public Vector2 Aim;
    public Vector2 Launch;
    public Animator ShootAnim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var _b = Instantiate(Bubble, transform.position, Quaternion.identity);
            _b.GetComponent<Rigidbody2D>().linearVelocity = Launch;

            ShootAnim.SetTrigger("Fire");
            AudioSource Spawnaudio = GetComponent<AudioSource>();
            Spawnaudio.Play();
        }

        //Aim
        if (Input.GetKey(KeyCode.RightArrow) /*&& Aim.x < 90*/)
        {
            Aim.x += AimSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) /*&& Aim.x > 0*/)
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


        //Spawnaudio.Play();

        transform.rotation = Quaternion.Euler(0f, 0f, -Aim.x);
        Launch = transform.up * Aim.y * LaunchMod;
    }
}