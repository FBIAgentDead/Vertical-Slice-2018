using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float health = 100;

    public Sprite Spr100_50;
    public Sprite Spr49_00;

    void Start () {
        CheckDeath();
	}
	
	void Update () {
		
	}

    public void GetDamage(float force)
    {
        health -= force;
        CheckDeath();
    }

    public void CheckDeath()
    {
        SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        else if (health > 0  && health <= 50)
        {
            currentSprite.sprite = Spr49_00;
        }
        else if (health > 50 && health <= 100)
        {
            currentSprite.sprite = Spr100_50;
        }


    }
}
