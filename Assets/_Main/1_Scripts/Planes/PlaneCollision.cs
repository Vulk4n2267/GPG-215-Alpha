using System;
using UnityEngine;


public class PlaneCollision : UnityEngine.MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Collided at" + Time.deltaTime);
    }
}