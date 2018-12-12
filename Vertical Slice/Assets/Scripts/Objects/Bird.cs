using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour {

    [SerializeField]
    float force = 400;
    [SerializeField]
    Vector2 clampX;
    [SerializeField]
    Vector2 clampY;
    private int damage;
    [SerializeField]
    private Transform moveTowards;
    private int velocity;
    public bool isShot;
    public bool released = false;
    private float timer = 5.0f;

    public AudioSource schietGeluid;
    Rigidbody2D birdBody;
    public AudioSource die;

    public GameObject vogel;

	// Use this for initialization
	void Start (){
        vogel = this.gameObject;
        birdBody = GetComponent<Rigidbody2D>();
        birdBody.gravityScale = 0;
	}

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (isShot)
        {
            StartCoroutine(KillBird());
        }
    }

    public IEnumerator Drag()
    {
        bool temp = false;
        float t = 0; 
        while(Input.GetKey(KeyCode.Mouse0)){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // mousePosition = new Vector2(Mathf.Clamp(mousePosition.x, -6.15f, -1.94f), Mathf.Clamp(mousePosition.y, -2.73f, 2.67f));
            mousePosition = new Vector2(Mathf.Clamp(mousePosition.x, clampX.x, clampX.y), Mathf.Clamp(mousePosition.y, clampY.x, clampY.y));
            transform.position = Vector2.Lerp(transform.position, mousePosition , t);
            //transform.position = Vector2.MoveTowards(transform.position, mousePosition, t);
            temp = true;
            t += 0.01f;
            yield return new WaitForSeconds(0.000000001f);
        }
        if(temp)
        released = true;
    }

    private IEnumerator KillBird()
    {
        timer -= 1;
        yield return new WaitForSeconds(1);
    }

    public void BirdDie()
    {
        //Verwijder Object
        GameObject.Destroy(vogel);
        //Speel particle effect

        //geluidseffecten
        die.Play();
    }

    void Update()
    {
        if(isShot){
            birdBody.gravityScale = 1;
        }
    }

    public void LoadBird(Transform moveTo){
        vogel.transform.position = new Vector2(moveTo.position.x, moveTo.position.y);
    }

    public IEnumerator Shoot(Transform flyTowards)
    {
        isShot = true;
        while(transform.position.x < -2.04f){
            birdBody.AddForce((moveTowards.transform.position - transform.position).normalized * force);
            yield return new WaitForSeconds(0.1f);
        }
        //katapult function
        //geluidseffecten
        // schietGeluid.Play();
    }

}
