using System;
using Unity.VisualScripting;
using UnityEngine;

public class PivotPointMRU : MonoBehaviour
{
    public int id;
    public float timeToNextPoint;
    private float speed;
    private float distance;
    public static event Action<int, float> OnCollisionBetweenPointAndNext;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnCollisionBetweenPointAndNext?.Invoke(id, timeToNextPoint);
        }
    }
}