using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterMovementMRUV : MonoBehaviour
{
    private Rigidbody myrb;
    public GameObject pivotPointA;
    public MovementManagerMRUV manager;

    private Vector3 direction;
    private float time;
    private bool isMoving;
    private void OnEnable()
    {
        MovementManagerMRUV.OnStartMovement += StartMovement;
    }
    private void OnDisable()
    {
        MovementManagerMRUV.OnStartMovement -= StartMovement;
    }
    private void Awake()
    {
        myrb = GetComponent<Rigidbody>();
        isMoving = false;
        time = 0f;
    }
    private void FixedUpdate()
    {
        if (isMoving)
        {
            time += Time.fixedDeltaTime;
            Vector3 currentVelocity = direction * manager.aceleration * time;
            myrb.linearVelocity = currentVelocity;
        }
    }
    public void StartMovement()
    {
        transform.position = pivotPointA.transform.position;
        direction = (manager.pivotPointB.transform.position - manager.pivotPointA.transform.position).normalized;
        time = 0f;
        isMoving = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pilar"))
        {
            isMoving = false;
            myrb.linearVelocity = Vector3.zero;
        }
    }
}