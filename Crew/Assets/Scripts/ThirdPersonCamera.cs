using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")] 
    public Transform _orienttation;
    public Transform _player;
    /*public Transform _playerObject;*/
    public Rigidbody rb;

    public float _rotationSpeed;
    
    public CameraStyle currenStyle;

    public enum CameraStyle
    {
        Basic,
        Topdown
    }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void FixedUpdate()
    {
        //rotation or
        Vector3 view = _player.position - new Vector3(transform.position.x, _player.position.y, transform.position.z);
        _orienttation.forward = view.normalized;

        if (currenStyle == CameraStyle.Basic||currenStyle == CameraStyle.Topdown)
        {
            //rotaion player
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = _orienttation.forward * verticalInput + _orienttation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                _player.forward =
                    Vector3.Slerp(_player.forward, inputDir.normalized, Time.deltaTime * _rotationSpeed);
            }
        }
        
        
    }
}
