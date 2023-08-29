using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Keyblind")]
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode defendKey = KeyCode.Mouse1;

    [Header("Attack Setup")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    public static int totalThrows;
    public int maxThrows;
    public float cooldownToThrow;
    public float cooldowbToAddThrow;
    bool readyToThrow;

    [Header("Boomerang Setup")]
    public float throwForce;
    public float returnForce;
    public float maxDistance;
    public float throwUpwardForce;
    
    [Header("Sheild")]
    public GameObject sheild;
    private bool isSheild;

   
    
    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;

        totalThrows = maxThrows;


    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Defend();
    }
    
    public void Attack(){
        if(Input.GetKeyDown(attackKey) && readyToThrow && totalThrows>0 && !isSheild)
        {
            Debug.Log("Attacking Use Cube : " +totalThrows);
            Throw();
        }
    }

    public void Throw(){
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // Vector3 forceDirection = cam.transform.forward;

        // RaycastHit hit;

        // if(Physics.Raycast(cam.position, cam.forward, out hit, 5f)){
        //      forceDirection = (hit.point - attackPoint.position).normalized;
        // }

        // Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        // projectileRb.AddForce(forceToAdd, ForceMode.Impulse);


        totalThrows--;

        Invoke(nameof(ResetThrow), cooldownToThrow);
        
    }

    public void ResetThrow(){
        readyToThrow = true;
        //Invoke(nameof(AddTotalThrow), cooldowbToAddThrow);
    }



    public void Defend(){
        if(Input.GetKeyDown(defendKey))
        {
            Debug.Log("Blocking");
            sheild.SetActive(true);
            isSheild = true;
        }
        else if(Input.GetKeyUp(defendKey)){
            Debug.Log("Unblocking");
            sheild.SetActive(false);
            isSheild = false;
        }
    }
}
