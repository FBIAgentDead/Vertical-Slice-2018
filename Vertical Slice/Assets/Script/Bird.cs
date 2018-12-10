using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour {

    private int damage;
    private int velocity;
    private bool isShot;
    private float timer = 5.0f;

    public AudioSource schietGeluid;
    public AudioSource die;

    public GameObject Vogel;

	// Use this for initialization
	void Start (){

	}
	
	// Update is called once per frame
	void Update (){
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        
        if (isShot)

        {
            StartCoroutine(KillBird());
        }
    }

    private IEnumerator KillBird()
    {
        timer -= 1;
        yield return new WaitForSeconds(1);
    }

    public void BirdDie()
    {
        //Verwijder Object
        GameObject.Destroy(Vogel);
        //Speel particle effect

        //geluidseffecten
        die.Play();
    }

    public void Shoot()
    {
        //katapult function

        //geluidseffecten
        schietGeluid.Play();
    }

}
