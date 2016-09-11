using UnityEngine;
using System.Collections;

public class fire_control : MonoBehaviour
{

    Rigidbody2D fireObject;

    public float speed;
    public float aliveTime;



    // Use this for initialization
    void Awake()
    {

        fireObject = GetComponent<Rigidbody2D>();
        fireObject.AddForce(new Vector2(0, -3) * speed, ForceMode2D.Impulse);
        
      
        Destroy(gameObject, aliveTime);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
   
    }

