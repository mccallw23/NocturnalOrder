using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumButton : MonoBehaviour
{
    private Vector3 startPos; 
    private Vector3 endPos;
    public float movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
       {
           RaycastHit hit; 
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           if(Physics.Raycast(ray, out hit))
           {
               if(hit.transform.gameObject == this.transform.gameObject)
               {
                   Debug.Log("You clicked the " + hit.transform.name);
                   StartCoroutine(ButtonPush(0.5f));
               }
           }
       }
        
    }

    IEnumerator ButtonPush(float seconds)
    {
        startPos = this.transform.position;
        endPos = new Vector3(startPos.x, startPos.y - movement, startPos.z);
        this.transform.position = endPos;
        yield return new WaitForSeconds(seconds);
        this.transform.position = startPos;
    }
}
