using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class captainController : MonoBehaviour {

    public float captainSpeed;
    Vector3 position;
    public float maxPos = 9.7f;
    public uiManager ui;


    // Use this for initialization
	void Start () {
        //ui = GetComponent<uiManager>();
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        position.x += Input.GetAxis("Horizontal") * captainSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -9.7f, 9.7f);
        transform.position = position;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy Iceberg")
        {
            Destroy(gameObject);
            ui.gameOverActivated();
        }
    }


}
