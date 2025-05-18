//using UnityEngine;
//using UnityEngine.TextCore.Text;

//public class CharacterMovementMRUV : MonoBehaviour
//{
//    private Rigidbody myrb;
//    private MovementManagerMRUV manager;
//    float distance;
//    int time;
//    Vector3 velocity;
//    private void OnEnable()
//    {
//        MovementManagerMRUV.OnSpeedCalculation += GetVelocityComponent;
//        MovementManagerMRUV.OnStartMovement += UpdatePositionOnStart;
//    }
//    private void OnDisable()
//    {
//        MovementManagerMRUV.OnSpeedCalculation -= GetVelocityComponent;
//        MovementManagerMRUV.OnStartMovement -= UpdatePositionOnStart;
//    }
//    private void Awake()
//    {
//        myrb = GetComponent<Rigidbody>();
//        velocity = new Vector3(0,0,0);
//    }
//    private void FixedUpdate()
//    {
//        myrb.linearVelocity = velocity;
//    }
//    public void GetVelocityComponent(Vector3 speed)
//    {
//        velocity = speed;
//    }
//    public void UpdatePositionOnStart(PivotPointMRUV[] pivots)
//    {
//        transform.position = pivots[0].transform.position;
//    }
//}