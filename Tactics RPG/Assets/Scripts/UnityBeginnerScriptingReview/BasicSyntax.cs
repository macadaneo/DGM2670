using UnityEngine;

public class BasicSyntax : MonoBehaviour
{ 
    void Start()
    {
        //This line is there to tell me the X position of my object
        
        /* This is to practice my multi-line comment
         skills */
        Debug.Log(transform.position.x);

        if (transform.position.y <= 5f)
        {
            Debug.Log("I'm about to hit the ground!");
        }
    }
}
