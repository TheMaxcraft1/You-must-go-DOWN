using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] private float platformSpeed;
    // Start is called before the first frame update
    void MoveUp()
    {
        transform.Translate(Vector3.up * (Time.deltaTime * platformSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
    }
    
    
}
