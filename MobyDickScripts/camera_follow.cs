using UnityEngine;
using System.Collections;

public class camera_follow : MonoBehaviour {
    [SerializeField]
    private float xMax;
    [SerializeField]
    private float xMin;

    

    private Transform target;
    

	// Use this for initialization
	void Start ()
    {

        target = GameObject.Find("viking_boat").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), -1, -10);
	}
}
