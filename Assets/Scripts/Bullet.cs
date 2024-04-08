using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rb;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
    } 

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate()
	{
		Vector3 moveDirection = transform.forward * speed;
		rb.velocity = moveDirection;
	}
}
