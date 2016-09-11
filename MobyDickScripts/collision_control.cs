using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class collision_control : MonoBehaviour
{

    // Use this for initialization

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Moby")
        {
            Destroy(other.gameObject);
            //int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Level 1");
            
        }
        if (other.gameObject.tag == "fish")
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
        
    }
}