using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwitcher : MonoBehaviour {

    public Sprite sprite1;
    public Sprite sprite2;

    private Image spriteRenderer;

    void Start () {

        spriteRenderer = GetComponent<Image>();

        if (spriteRenderer.sprite == null)
            spriteRenderer.sprite = sprite1;

	}

    public void ChangeTheDamnSprite()
    {
        if(spriteRenderer.sprite == sprite1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }
}
