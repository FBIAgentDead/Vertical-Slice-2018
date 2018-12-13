using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

    private float paralaxSpeed = 2f;
    public GameObject background;
    public GameObject camera;
       
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = camera.transform.position / paralaxSpeed;
	}
}
