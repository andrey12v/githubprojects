using UnityEngine;
using System.Collections;

public class Swimming : MonoBehaviour
{
    Rigidbody2D fish;

    public float speed;

    void Start()
    {
        fish = GetComponent<Rigidbody2D>();
        fish.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Force);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fish")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    
        /*
        void Update()
        {
            Vector2 position = transform.position;
            position = new Vector2(position.x, position.y - speed * Time.deltaTime);
            transform.position = position;

            GameObject clone = Instantiate(fish, new Vector2(launch.position.x, launch.position.y - 1.5f), launch.rotation) as GameObject;

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "edge")
            {

                Destroy(gameObject);
            }
        }*/
    }
