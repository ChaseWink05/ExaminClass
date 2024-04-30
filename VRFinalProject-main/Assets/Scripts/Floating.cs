using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Michael
public class Floating : OVRGrabbable
{
    private Rigidbody rb;
    public float force = 10.0f;
    public Light pointLight;
    public TextManager textManager;
    public ScoreManager scoreManager;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Lighter_Prefab")
        {
            ApplyForce();
        }
    }

    public void ApplyForce()
    {
        rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        pointLight.enabled = true;
        textManager.SetText("Good Job!");
        scoreManager.IncrementScore();
    }
}

