using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBlaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(40 * Time.deltaTime,0,0);
    }
}