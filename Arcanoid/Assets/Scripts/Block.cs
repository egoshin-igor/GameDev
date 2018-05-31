using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int hitsToKill;
    public int points;

    private int numberOfHits;

    void Start () {
        numberOfHits = 0;
    }
	
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        //GameObject.Find("ball").GetComponent<Rigidbody>().AddForce(transform.forward * 1.2f, ForceMode.Impulse);
        if (collision.gameObject.tag == "Ball")
        {
            numberOfHits++;
            if (numberOfHits == hitsToKill)
            {
                Destroy(gameObject);
            }
            else
            {
                ColorDown(gameObject);
            }
        }
    }

    private void ColorDown(GameObject obj)
    {
        var currentColor = obj.GetComponent<Renderer>().material.color;
        if (currentColor == Color.red)
        {
            obj.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (currentColor == Color.green)
        {
            obj.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}
