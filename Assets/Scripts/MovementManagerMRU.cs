using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManagerMRU
    : MonoBehaviour
{
    Vector3 speedVector;
    float speed;
    public int currentPoint;
    public PivotPointMRU[] pivotPoints;
    public static event Action<Vector3> OnSpeedCalculation;
    public static event Action<PivotPointMRU[]> OnStartMovement;
    float distanceX;
    float distanceY;
    float distanceZ;
    float distance;
    private void Start()
    {
        currentPoint = 0;
    }
    private void OnEnable()
    {
        PivotPointMRU.OnCollisionBetweenPointAndNext += OnClollisionCharacterToNextPoint;
    }
    private void OnDisable()
    {
        PivotPointMRU.OnCollisionBetweenPointAndNext -= OnClollisionCharacterToNextPoint;
    }
    public void OnSpacePlay(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnStartMovement?.Invoke(pivotPoints);
            currentPoint = 0;
        }
    }
    public void OnClollisionCharacterToNextPoint(int id, float time)
    {
        GetDistanceFromPointToNextPoint(id, time);
        //GetDistanceFromPointToNextPoint
        //Setthevelocitytocharacter
        OnSpeedCalculation?.Invoke(speedVector);
    }
    public void GetDistanceFromPointToNextPoint(int id, float time)
    {
        if(id+1 < pivotPoints.Length)
        {
            distanceX = pivotPoints[id + 1].transform.position.x - pivotPoints[id].transform.position.x;
            distanceY = pivotPoints[id + 1].transform.position.y - pivotPoints[id].transform.position.y;
            distanceZ = pivotPoints[id + 1].transform.position.z - pivotPoints[id].transform.position.z;
            //MRUFormula
            speedVector = new Vector3(distanceX / time, distanceY / time, distanceZ / time);
            //Other calculations
            speed = Mathf.Sqrt(Mathf.Pow(distanceX / time, 2) + Mathf.Pow(distanceY / time, 2) + Mathf.Pow(distanceZ / time, 2));
            distance = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceY, 2) + Mathf.Pow(distanceZ, 2));
            Debug.Log("La velocidad es: " + speed);
            currentPoint++;
        }
        else
        {
            speedVector = Vector3.zero;
            Debug.Log("Finalizó el viaje");
        }
    }
    //I need a and b position/distance
    //i need time
    //i get velocity
}