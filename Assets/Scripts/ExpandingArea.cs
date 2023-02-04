using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandingArea : MonoBehaviour
{
    public float expandRate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(expandRate, expandRate, 0) * Time.deltaTime;
    }
    
}
