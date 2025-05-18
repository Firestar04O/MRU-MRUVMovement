//using System;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class MovementManagerMRUV : MonoBehaviour
//{
//    Vector3 speedVectorInitial;
//    Vector3 speedVectorFinal;
//    float speedInitial;
//    float speedFinal;
//    public int currentPoint;
//    public PivotPointMRUV[] pivotPoints;
//    public static event Action<Vector3, Vector3> OnSpeedCalculation;
//    public static event Action<PivotPointMRUV[]> OnStartMovement;
//    float distanceX;
//    float distanceY;
//    float distanceZ;
//    float distance;
//    private void Start()
//    {
//        currentPoint = 0;
//    }
//    private void OnEnable()
//    {
//        PivotPointMRUV.OnCollisionBetweenPointAndNext += OnClollisionCharacterToNextPoint;
//    }
//    private void OnDisable()
//    {
//        PivotPointMRUV.OnCollisionBetweenPointAndNext -= OnClollisionCharacterToNextPoint;
//    }
//    public void OnSpacePlay(InputAction.CallbackContext context)
//    {
//        if (context.performed)
//        {
//            OnStartMovement?.Invoke(pivotPoints);
//            currentPoint = 0;
//        }
//    }
//    public void OnClollisionCharacterToNextPoint(int id, float time, int aceleration)
//    {
//        GetDistanceFromPointToNextPoint(id, time, aceleration);
//        //GetDistanceFromPointToNextPoint
//        //Setthevelocitytocharacter
//        OnSpeedCalculation?.Invoke(speedVectorInitial, speedVectorFinal);
//    }
//    public void GetDistanceFromPointToNextPoint(int id, float time, int aceleration)
//    {
//        if(id+1 < pivotPoints.Length)
//        {
//            distanceX = pivotPoints[id + 1].transform.position.x - pivotPoints[id].transform.position.x;
//            distanceY = pivotPoints[id + 1].transform.position.y - pivotPoints[id].transform.position.y;
//            distanceZ = pivotPoints[id + 1].transform.position.z - pivotPoints[id].transform.position.z;
//            //MRUVFormula
//            speedVector = new Vector3(distanceX / time, distanceY / time, distanceZ / time);
//            //Other calculations
//            speed = Mathf.Sqrt(Mathf.Pow(distanceX / time, 2) + Mathf.Pow(distanceY / time, 2) + Mathf.Pow(distanceZ / time, 2));
//            distance = Mathf.Sqrt(Mathf.Pow(distanceX, 2) + Mathf.Pow(distanceY, 2) + Mathf.Pow(distanceZ, 2));
//            Debug.Log("La velocidad es: " + speed);
//            currentPoint++;
//        }
//        else
//        {
//            speedVector = Vector3.zero;
//            Debug.Log("Finalizó el viaje");
//        }
//    }
//    //I need a and b position/distance
//    //i need time
//    //i get velocity
}