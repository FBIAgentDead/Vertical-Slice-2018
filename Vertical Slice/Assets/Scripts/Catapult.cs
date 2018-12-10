using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour {

	private float dragRange;
	private bool isLoaded;
	// private List<Bird> amunition = new List<Bird>();

	void Update()
	{
		if(!isLoaded){
			loadCatapult();
		}
	}

	private void loadCatapult(){
		isLoaded = false;
	}

	void Drag(){
		
	}

	void WhenReleased(){

	}
	
	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		
	}

}
