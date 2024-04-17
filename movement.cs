using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed = 2;
    public int currentLane = 1;
    public int numLanes = 3;
    private bool canMove = true;

    void Update()
{
    if (canMove == true)
    {
        // Move forward automatically
     transform.position += transform.forward * speed * Time.deltaTime;

     // Check for input to change lanes
     if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
       { 
            currentLane--;
         transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
       }

     else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < numLanes - 1)
       {
            currentLane++;
         transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
       }

    }
}

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Train") 
        { // Stop the player object speed = 0; 
         speed = 0f; 
         canMove = false; 
        } 
    } 
    
}

