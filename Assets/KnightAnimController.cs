using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAnimController : MonoBehaviour
{

    public Animator KnightAnim;
    // Start is called before the first frame update
    void Start()
    {
        KnightAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("u"))
        {
            KnightAnim.Play("Dancing");
        }
        
    }
}
