using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject proyectilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private float launchSpeed;

    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private int pointCount = 20;
    [SerializeField] private float spaceBetweenPoints = 0.1f;

    private GameObject[] trayectoryPoints;
    protected Vector3 direction;
    private void Start()
    {
        trayectoryPoints = new GameObject[pointCount];
        for(int i = 0; i< pointCount; i++)
        {
            trayectoryPoints[i] = Instantiate(pointPrefab);
        }
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        direction = (mousePosition - launchPoint.position).normalized;
        transform.right = direction;
        ShowTrayectory();
    }
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject proyectile = Instantiate(proyectilePrefab, launchPoint.position, Quaternion.identity);
            Rigidbody rigidbody = proyectile.GetComponent<Rigidbody>();
            rigidbody.linearVelocity = direction * launchSpeed;
        }
    }
    public void ShowTrayectory()
    {
        for (int i = 0; i < pointCount; i++)
        {
            float t = i * spaceBetweenPoints;
            Vector3 posit = launchPoint.position + direction * launchSpeed * t + 0.5f * Physics.gravity * t * t;
            trayectoryPoints[i].transform.position = posit;
        }
    }
}