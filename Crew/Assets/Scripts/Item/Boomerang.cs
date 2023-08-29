using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [Header("Boomerang Setup")]
    public float throwForce = 10f; 
    public float returnForce = 20f;
    public float returnTime ;
    private Transform player;
    private bool isReturning = false;
    private Vector3 initialPosition;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;
    }

    void Update()
    {
        if(!isReturning)
        {
            Throw();
        }
        else{
            Return();
        }
    }

    void Throw(){
        Rigidbody rb = GetComponent<Rigidbody>();
        gameObject.transform.Rotate(0, Time.deltaTime * 300, 0);
        rb.velocity = player.forward * throwForce; 
        //rb.AddForce(throwForce*player.forward, ForceMode.Impulse);
        StartCoroutine(DelayReturn());
    }

    IEnumerator DelayReturn(){
        yield return new WaitForSeconds(returnTime);
        isReturning = true;
    }

    void Return(){
        gameObject.transform.Rotate(0, Time.deltaTime * 200, 0);
        transform.position = Vector3.MoveTowards(transform.position, player.position, returnForce * Time.deltaTime);

        if(Vector3.Distance(player.transform.position, transform.position) <1.5){
            Destroy(this.gameObject);
            PlayerCombat.totalThrows++;
        }
    }
}