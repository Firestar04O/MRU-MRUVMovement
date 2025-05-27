using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] private Rigidbody myRB;
    private void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (myRB.linearVelocity.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(myRB.linearVelocity.y, myRB.linearVelocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
