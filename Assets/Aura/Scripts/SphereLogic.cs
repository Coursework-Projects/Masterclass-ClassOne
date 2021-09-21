using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereLogic : MonoBehaviour
{
    Rigidbody rigidBody;
    [SerializeField]private float jumpForce = 1000f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        //make sphere jump on space bar press
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //add force to rigidbody upwards
            rigidBody.AddForce(Vector3.up * jumpForce);
        }
    }
}
