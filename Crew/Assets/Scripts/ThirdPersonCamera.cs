using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")] 
    public Transform _orienttation;
    public Transform _player;
    public Transform _playerObject;
    public Rigidbody rb;

    public float _rotationSpeed;
    void Update()
    {
        //rotation or
        Vector3 view = _player.position - new Vector3(transform.position.x, _player.position.y, transform.position.z);
        _orienttation.forward = view.normalized;
        
        //rotaion player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir
    }
}
