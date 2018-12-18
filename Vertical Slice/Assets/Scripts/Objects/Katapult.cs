using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katapult : MonoBehaviour
{

    private float dragRange;
    public bool isLoaded = true;
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private List<Bird> amunition = new List<Bird>();
    [SerializeField]
    private List<GameObject> dragLines;
    [SerializeField]
    private GameObject slingHolder;

    void Start()
    {
        StartCoroutine(loadCatapult(0));
    }

    void Update()
    {
        if (amunition.Count > 0)
        {
            if (!isLoaded)
            {
                StartCoroutine(loadCatapult(3));
            }
            amunition[0].StartCoroutine("Drag");
            if (amunition[0].released)
            {
                amunition[0].StartCoroutine(amunition[0].Shoot(startPosition));
                amunition.RemoveAt(0);
                isLoaded = false;
            }
            DragLines();
        }
        if (!isLoaded)
        {
            for (int i = 0; i < dragLines.Count; i++)
            {
                dragLines[i].SetActive(false);
            }
            slingHolder.SetActive(true);
        }
        else
        {
            for (int i = 0; i < dragLines.Count; i++)
            {
                dragLines[i].SetActive(true);
            }
            slingHolder.SetActive(false);
        }

    }

    void DragLines()
    {
        for (int i = 0; i < dragLines.Count; i++)
        {
            if (amunition.Count > 0)
            {
                Vector2 distance = amunition[0].transform.position - dragLines[i].transform.position;
                dragLines[0].transform.localScale = new Vector2(distance.magnitude / 1.23f, 1);
                dragLines[1].transform.localScale = new Vector2(distance.magnitude / 1.13f, 1);
                float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
                angle += 180;
                dragLines[i].transform.localEulerAngles = new Vector3(0, 0, angle);
            }
        }
    }

    private IEnumerator loadCatapult(int time)
    {
        isLoaded = true;
        yield return new WaitForSeconds(time);
        amunition[0].LoadBird(startPosition);
    }

}