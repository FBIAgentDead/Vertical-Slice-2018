using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

    private Animator camMove;
    [SerializeField]
    Katapult checkState;

    void Awake()
    {
        camMove = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if(checkState.isLoaded){
            if(transform.position.x > 8){
                camMove.SetFloat("reverse", -1);
                camMove.Play("Paralax");
            }
        }
        else
        {
            camMove.SetFloat("reverse", 1);
            camMove.Play("Paralax");
        }
    }
	
}
