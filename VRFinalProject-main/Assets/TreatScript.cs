using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatScript : MonoBehaviour
{
    //Creating a static variable to keep track of how many treats the dog has consumed throughout all of the scripts
    public static int treatCounter = 0;
    public GameObject Treat;
    public TextManager textManager;
    public ScoreManager scoreManager;
    //Storing both of the colliders as variables as static so it goes to all the scripts that have this script on it 
    public static Collider treatCapsuleCollider;
    public static Collider treatSphereCollider;
    

    void Start()
    {
        
        treatCounter = 0;
        treatCapsuleCollider = GetComponent<CapsuleCollider>(); //Taking both of the colliders off of the treat object so it cannot collide which destroys the object
        treatSphereCollider = GetComponent<SphereCollider>();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Dog_001" && treatCounter < 3)
        {
            treatCounter++; // Increment the treat counter
            Debug.Log("Treat counter is now" + treatCounter);

            if (treatCounter == 3) // If the dog has received 3 treats 
            {
                scoreManager.IncrementScore();
                textManager.SetText("Enough, Stop");
                //Destroying the treat that it ate
                Destroy(gameObject);
                //This is where I disable all the colliders for every object that has this script on it 
                treatCapsuleCollider.enabled = false;
                treatSphereCollider.enabled = false;
            }
            else
            {
                
                Destroy(gameObject);
                textManager.SetText("Bark Bark");
                scoreManager.IncrementScore();
            }
        }
    }



}
