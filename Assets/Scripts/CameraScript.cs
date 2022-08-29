using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Lion;

    void Update()
    {
        if(Lion != null)
        {
            Vector3 position = transform.position;
            position.x = Lion.transform.position.x; 
            transform.position = position;
        }
    }
}
