using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider teleportationProvider;
    private InputAction _thumbstick;
    private InputAction activate;
    private InputAction cancel;
    private bool _isActive;
    
    

    // Start is called before the first frame update
    void Start()
    {
        //rayInteractor = GameObject.Find("LeftHand Ray").GetComponent<XRRayInteractor>();
        rayInteractor.enabled = false;
        
       
    }

    private void OnEnable()
    {
       
        activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivate;
        
        cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportCancel;
       
        _thumbstick = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Move");
        _thumbstick.Enable();
    }

    private void OnDisable()
    {
        activate.Disable();
        activate.performed -= OnTeleportActivate;
        cancel.Disable();
        cancel.performed -= OnTeleportCancel;
        _thumbstick.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isActive)
        {
            return;
        }

        if (_thumbstick.ReadValue<Vector2>()!= Vector2.zero)
        {
            return;
        }

        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }

        if (!hit.transform.CompareTag("Floor"))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }
        
        TeleportRequest request = new TeleportRequest()
        {
            destinationPosition = hit.point
        };
        teleportationProvider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        _isActive = false;
    }

    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }

    private void OnTeleportCancel(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = false;
        _isActive = false;
    }
}
