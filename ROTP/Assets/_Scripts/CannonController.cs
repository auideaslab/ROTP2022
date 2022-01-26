using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dot product of two vectors is a cosine of angle between them. So, arccosine of the dot product is the actual angle between them
// float angle = Mathf.Acos (Vector3.Dot ( Vector3.right , direction.normalized)) ∗ Mathf . Rad2Deg ;

public class CannonController : MonoBehaviour
{
    public Rigidbody2D piggyRigid;
    public float power = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        Vector3 mouseOnScreen = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, -(Camera.main.transform.position.z));

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(mouseOnScreen);
        
        Vector3 directionIn3D = mousePosition - transform.position;

        // Dot product of two vectors is a cosine of angle between them. So, arccosine of the dot product is the actual angle between them
        float dotProduct = Vector2.Dot(Vector2.right, new Vector2(directionIn3D.x, directionIn3D.y).normalized); 

        float angleAroundZAxis = Mathf.Acos(dotProduct)*Mathf.Rad2Deg; // now we have an angle between direction of mouse and direction of cannon

        if (mousePosition.y - transform.position.y > 0 && angleAroundZAxis < 80 && angleAroundZAxis > 10)
        {
            transform.rotation = Quaternion.Euler(0, 0, angleAroundZAxis);
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            piggyRigid.transform.parent = null;
            piggyRigid.gravityScale = 1;
            piggyRigid.AddForce(directionIn3D*power);
        }        
    }
}

