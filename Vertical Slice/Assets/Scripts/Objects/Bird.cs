using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Bird : MonoBehaviour {
    [SerializeField]
    float damageMultiplier;
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

    public Animation paralax;
    public AudioSource schietGeluid;
    Rigidbody2D birdBody;
    public AudioSource die;

    public GameObject vogel;
    [SerializeField]
    private ParticleSystem feathers;
    bool featherOnce = true;

	// Use this for initialization
	void Start (){
        vogel = this.gameObject;
        birdBody = GetComponent<Rigidbody2D>();
        birdBody.gravityScale = 0;
	}

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (featherOnce)
        {
            feathers.Play();
            featherOnce = false;
        }
        if (isShot)
        {
            StartCoroutine(KillBird());
        }
        if(collisionInfo.gameObject.tag == "obstacle"){
            Obstacle setDamage = collisionInfo.gameObject.GetComponent<Obstacle>();
            setDamage.GetDamage(birdBody.velocity.magnitude*birdBody.mass*damageMultiplier);
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
        int timer = 0;
        while(timer < 3){
            timer++;
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        while(transform.position.x < 0){
            birdBody.AddForce((moveTowards.transform.position - transform.position).normalized * force);
            yield return new WaitForSeconds(0.1f);
        }
        //katapult function
        //geluidseffecten
        // schietGeluid.Play();
    }

}
