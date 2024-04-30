using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lighting : MonoBehaviour
{

    public Light pointLight;
    // Start is called before the first frame update
    void Start()
    {
        pointLight.enabled = false;
    }
}
