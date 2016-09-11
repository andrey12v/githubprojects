using UnityEngine;
using System.Collections;


public class throwing : MonoBehaviour {

    public Sprite ahabStanding;
    public Sprite ahabThrown;
    public Sprite ahabReload;
    public GameObject harpoon;
    public float fireRate = 1f;
    private float nextFire = 0.0f;

    void Start ()
    {
        harpoon = GameObject.Find("harpooncolor");
    }

    void Update()
    {
        if (Input.GetKeyDown("x") && (Time.time > nextFire))
        {
            nextFire = Time.time + fireRate;
            harpoon.SetActive(false);
            StartCoroutine(waitForIt());            
        }
    }
    IEnumerator waitForIt()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = ahabThrown;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().sprite = ahabReload;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().sprite = ahabStanding;
        harpoon.SetActive(true);
    }
}

    
