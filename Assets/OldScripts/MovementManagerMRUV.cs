using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementManagerMRUV : MonoBehaviour
{
    public GameObject pivotPointA;
    public GameObject pivotPointB;
    public int aceleration;
    public static event Action OnStartMovement;
    public bool StartMovement;

    private void Start()
    {
        StartMovement = false;
    }
    public void OnSpacePlay(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartMovement = true;
            OnStartMovement?.Invoke();
        }
    }
}