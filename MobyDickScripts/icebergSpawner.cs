using UnityEngine;
using System.Collections;

public class icebergSpawner : MonoBehaviour {

    public GameObject[] icebergs;
    int icebergNum;
    public float delayTimer = 0.5f;
    public float maxPos = 9.5f;
    float timer;

	// Use this for initialization
	void Start () {

        timer = delayTimer;
	
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Vector3 icebergPos = new Vector3(Random.Range(-9.5f, 9.5f), transform.position.y, transform.position.z);
            icebergNum = Random.Range(0,2);
            Instantiate(icebergs[icebergNum], icebergPos, transform.rotation);
            timer = delayTimer;
        }


    }

}
