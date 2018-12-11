using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katapult : MonoBehaviour {

	private float dragRange;
	private bool isLoaded = true;
	[SerializeField]
	private Transform startPosition;
	[SerializeField]
	private List<Bird> amunition = new List<Bird>();

	void Start()
	{
        StartCoroutine(loadCatapult(0));
	}

	void Update()
	{
		if(amunition.Count > 0){
			if(!isLoaded){
				StartCoroutine(loadCatapult(3));
			}
			amunition[0].StartCoroutine("Drag");
			if(amunition[0].released){
				amunition[0].StartCoroutine(amunition[0].Shoot(startPosition));
				amunition.RemoveAt(0);
				isLoaded = false;
			}
		}
	}

	private IEnumerator loadCatapult(int time){
		isLoaded = true;
		yield return new WaitForSeconds(time);
		amunition[0].LoadBird(startPosition);
	}

}
