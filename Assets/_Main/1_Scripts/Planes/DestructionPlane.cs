using System;
using UnityEngine;

public class DestructionPlane : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.ResetStreak();
        Destroy(other.gameObject);
    }
}
