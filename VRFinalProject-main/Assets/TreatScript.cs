using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatScript : MonoBehaviour
{
    //Creating a variable to keep track of how many treats the dog has consumed
    public int treatCounter;
    public GameObject Treat;
    public TextManager textManager;
    public ScoreManager scoreManager;
    //Storing both of the colliders as variables 
    private Collider treatCollider;
    private Collider treatCollider2;
    

    void Start()
    {
        
        treatCounter = 0;
        treatCollider = GetComponent<CapsuleCollider>(); //Taking both of the colliders off of the treat object so it cannot collide which destroys the object
        treatCollider2 = GetComponent<SphereCollider>();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Dog_001")
        {
            //treatCounter += 1; 
            treatCounter = treatCounter + 1; //Incrementing the treatCounter to keep track of how many times the treat is given to the dog
            Debug.Log(treatCounter); //testing to see if it is counting the treat
            if (treatCounter == 3) //Conditional so when the dog has recived 3 treats then it updates the text and takes away the colliders so the dog cant recieve any more treats 
            {
                textManager.SetText("Enough, Stop");
                // Disable the collider to prevent further collisions
                Destroy(treatCollider);
                Destroy(treatCollider2);
                treatCollider.enabled = false;
                treatCollider2.enabled = false;
                return; // Exit the method to prevent further execution
            }

              
            Destroy(gameObject); //This destroys the treat for the dog
            textManager.SetText("Bark Bark"); 
            scoreManager.IncrementScore(); //Incrementing the score that allows the scene to change
        }
    } 
 
}
