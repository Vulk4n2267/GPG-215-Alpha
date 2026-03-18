using System;
using UnityEngine;


public class PlaneCollision : UnityEngine.MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        print("Collided with " + other.gameObject.name);
    }
}