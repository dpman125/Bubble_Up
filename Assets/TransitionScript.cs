using UnityEngine;

public class TransitionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public BoxCollider2D Player;
    public GameObject Camera;
    public float CameraPanSpeed = 100f;
    public bool isCamTarget;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.transform.position.y > transform.position.y && isCamTarget)
        Camera.transform.Translate(new Vector3(0f, -CameraPanSpeed * Time.deltaTime, 0f));
        if(Camera.transform.position.y < transform.position.y && isCamTarget)
        Camera.transform.Translate(new Vector3(0f, CameraPanSpeed * Time.deltaTime, 0f));
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        // if player is within this collider, the camera must move to it
        isCamTarget = true;
    }
    private void OnTriggerExit2D(Collider2D Player)
    {
        // if player is not within this collider, the camera must move to a different one
        isCamTarget = false;
    }

}
