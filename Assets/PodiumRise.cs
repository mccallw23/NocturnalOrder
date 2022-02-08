using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumRise : MonoBehaviour
{
    private Vector3 permaStart;
    private Vector3 permaEnd;
    private Vector3 startPos;
    private Vector3 endPos;
    public float riseAmount;
    public float riseSpeed;
    private float startTime;
    private bool go;


    // Start is called before the first frame update
    void Start()
    {
        permaStart = this.transform.position;
        permaEnd = new Vector3(permaStart.x, permaStart.y + riseAmount, permaStart.z);
        startPos = permaStart;
        endPos = permaEnd;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(go)
        {
            float distCovered =(Time.time - startTime) * riseSpeed;
            float fracJourney = distCovered / riseAmount;
            transform.position = Vector3.Lerp(startPos,endPos, fracJourney);

            if (fracJourney > .99)
            {
                go = false;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        startPos = this.transform.position;
        endPos = permaEnd;
        startTime = Time.time;
        if(other.tag == "Player")
        {
            go = true;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        startPos = this.transform.position;
        endPos = permaStart;
        startTime = Time.time;
        if(other.tag == "Player")
        {
            go = true;
        }
    }
}
