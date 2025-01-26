using UnityEngine;
using UnityEngine.SceneManagement;


public class endGame : MonoBehaviour
{
    public BoxCollider2D Player;
    private void OnTriggerEnter2D(Collider2D Player)
    {
        SceneManager.LoadScene("TheEnd");
    }
}
