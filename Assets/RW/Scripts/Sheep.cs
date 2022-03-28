using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;
    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);

    }
    private void Drop()
    {
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;

    }
    private void HitBtHay()
    {
        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay); //1
    }

    private void OnTriggerEnter(Collider other)//2
    {
        if (other.CompareTag("Hay") && !hitByHay) //3
        {
            Destroy(gameObject, dropDestroyDelay);

            HitBtHay(); //4
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }
       
        
}



