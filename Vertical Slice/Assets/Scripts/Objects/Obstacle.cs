using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private float health;

    public Sprite Spr100_50;
    public Sprite Spr49_25;
    public Sprite Spr24_0;

    void Start () {
		
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
        else if (health > 0 && health < 25) 
        {
            currentSprite.sprite = Spr24_0;
        }
        else if (health >= 25 && health < 50)
        {
            currentSprite.sprite = Spr49_25;
        }
        else if (health >= 50 && health <= 100)
        {
            currentSprite.sprite = Spr100_50;
        }


    }
}
