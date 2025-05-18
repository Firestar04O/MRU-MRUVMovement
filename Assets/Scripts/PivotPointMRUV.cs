using System;
using Unity.VisualScripting;
using UnityEngine;

public class PivotPointMRUV : MonoBehaviour
{
    public int id;
    public float timeToNextPoint;
    public int aceleration;
    private float speed;
    private float distance;
    public static event Action<int, float, int> OnCollisionBetweenPointAndNext;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnCollisionBetweenPointAndNext?.Invoke(id, timeToNextPoint, aceleration);
        }
    }
}