using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAble : MonoBehaviour {

    public GameObject canvasObject;

    public void EnableCanvas()
    {
        canvasObject.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }

    public void Degug() { Debug.Log("HI"); }

}
