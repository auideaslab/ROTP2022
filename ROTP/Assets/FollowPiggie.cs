using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPiggie : MonoBehaviour
{
    public Transform piggie;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 18)
        {
            Vector3 newPositionOfCamera = new Vector3(piggie.position.x, transform.position.y, transform.position.z);
            transform.position = newPositionOfCamera;
        }
    }
}
