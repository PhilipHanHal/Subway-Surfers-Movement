using UnityEngine;


public class PlayerMovement : MonoBehaviour
{


    public float frontSpeed; 
    public float sideSpeed; 
    public float jump; 
    private int currentLane = 2; 
    private int desiredLane = 2; 

    private Vector3 LeftLane = Vector3.zero; 
    private Vector3 MidLane = Vector3.zero; 
    private Vector3 RightLane = Vector3.zero; 

    private Rigidbody rb;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>(); 
        LeftLane = GameObject.Find("LeftLane").transform.position; 
        MidLane = GameObject.Find("MidLane").transform.position; 
        RightLane = GameObject.Find("RightLane").transform.position; 
    }

    void FixedUpdate()
    {
        LaneCheck();
        Side();
        Forward();
        StopPlayer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Right();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit; 
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                if (hit.distance < 1f)
                {
                    Jump(); 
                }
            }
        }
    }

    void Forward()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, frontSpeed);
    }

    void Left()
    {
       if (Input.GetKeyDown(KeyCode.A)) 
       {
            rb.velocity = new Vector3(-sideSpeed, rb.velocity.y, rb.velocity.z);
       }
       
    }

    void Right()
    {
        if (Input.GetKeyDown(KeyCode.D) )
        {        
            rb.velocity = new Vector3(sideSpeed, rb.velocity.y, rb.velocity.z);  
        }
        
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
    }

    void Stop()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Lane"))
        {
            if (collision.gameObject.name == "LeftLane")
            {
                currentLane = 1; 
            }

            if (collision.gameObject.name == "MidLane")
            {
                currentLane = 2; 
            }

            if (collision .gameObject.name == "RightLane")
            {
                currentLane = 3;
            }

        }
    }

    void LaneCheck()
    {
        if (Mathf.Round(rb.position.x) == LeftLane.x & desiredLane == 1) 
        {
            Stop();
            rb.position = new Vector3(LeftLane.x, rb.position.y, rb.position.z); 
        }

        if (Mathf.Round(rb.position.x) == MidLane.x & desiredLane == 2)
        {
            Stop();
            rb.position = new Vector3(MidLane.x, rb.position.y, rb.position.z); 
        }

        if (Mathf.Round(rb.position.x) == RightLane.x & desiredLane == 3)
        {
            Stop();
             rb.position = new Vector3(RightLane.x, rb.position.y, rb.position.z); 
        }
    }

    void StopPlayer()
    {
        if (rb.position.x < RightLane.x & currentLane == 3)
        {
            Stop();
            rb.position = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }

        if (rb.position.x > LeftLane.x & currentLane == 3)
        {
            Stop();
            rb.position = new Vector3(rb.position.x, rb.velocity.y, rb.velocity.z); 
        }
    }

    void Side()
    {
        if (desiredLane != currentLane)
        {
            if (desiredLane < currentLane)
            {
                Left();
            }

            if (desiredLane > currentLane)
            {
                  Right();
            }
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Train") 
        { 
         frontSpeed = 0f; 
         Stop();
         
        } 
    } 




   
}