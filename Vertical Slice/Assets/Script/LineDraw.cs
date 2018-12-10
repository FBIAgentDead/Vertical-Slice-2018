using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDraw : MonoBehaviour {

    public GameObject puntje;
    private bool firstPoint = true;
    List<GameObject> points = new List<GameObject>();
    private bool isFired;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFired)
            DrawPoints();
    }

    void DrawPoints()
    {
        if (firstPoint == true || Vector2.Distance(transform.position, points[points.Count - 1].transform.position) > 1)
        {
            points.Add(Instantiate(puntje, new Vector3(transform.position.x, transform.position.y, transform.position.z + 2), Quaternion.identity));
            firstPoint = false;
        }
    }

    public void DestroyPoints()
    {
        for(int i = 0; i < points.Count; i++)
        {
            Destroy(points[i].gameObject);
        }
    }

}
