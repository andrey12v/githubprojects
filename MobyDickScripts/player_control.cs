using UnityEngine;
using System.Collections;

public class player_control : MonoBehaviour
{

    //for shooting
    public Transform launch;
    public GameObject harpoon;
    public float fireRate = 1f;
    private float nextFire = 0.0f;
    



    // Use this for initialization
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x") && (Time.time > nextFire))
        {
            
            nextFire = Time.time + fireRate;
           
            GameObject clone = Instantiate(harpoon, new Vector2(launch.position.x, launch.position.y - 1.5f), launch.rotation) as GameObject;
        }
    }
    
}
    
    

