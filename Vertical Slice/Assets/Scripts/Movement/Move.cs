using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();

	}
	
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rb2d.AddForce(move * speed);

    }
}
