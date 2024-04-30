using UnityEngine;

public class RockStacking : MonoBehaviour
{
    public ScoreManager scoreManager;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the specified tag
        if (collision.gameObject.CompareTag("Rock"))
        {
            scoreManager.IncrementScore();
            // Get the rigidbody of the collided object
            Rigidbody collidedRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Check if the collided object has a rigidbody
            if (collidedRigidbody != null)
            {
                // Destroy the rigidbody component
                Destroy(collidedRigidbody);
            }
        }
    }
}
