using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMovementMRU : MonoBehaviour
{
    private Rigidbody myrb;
    private MovementManagerMRUV manager;
    float distance;
    int time;
    Vector3 velocity;
    private void OnEnable()
    {
        MovementManagerMRU.OnSpeedCalculation += GetVelocityComponent;
        MovementManagerMRU.OnStartMovement += UpdatePositionOnStart;
    }
    private void OnDisable()
    {
        MovementManagerMRU.OnSpeedCalculation -= GetVelocityComponent;
        MovementManagerMRU.OnStartMovement -= UpdatePositionOnStart;
    }
    private void Awake()
    {
        myrb = GetComponent<Rigidbody>();
        velocity = new Vector3(0,0,0);
    }
    private void FixedUpdate()
    {
        myrb.linearVelocity = velocity;
    }
    public void GetVelocityComponent(Vector3 speed)
    {
        velocity = speed;
    }
    public void UpdatePositionOnStart(PivotPointMRU[] pivots)
    {
        transform.position = pivots[0].transform.position;
    }
}