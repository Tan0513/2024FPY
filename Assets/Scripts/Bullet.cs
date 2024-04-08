using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float recycleTime;

	private Rigidbody rb;

    private float timer;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
        timer += Time.deltaTime;
        if (timer >= recycleTime)
        {
			rb.velocity = Vector3.zero;
			timer = 0f;
			this.gameObject.SetActive(false);
        }
    }

	private void FixedUpdate()
	{
		Vector3 moveDirection = transform.forward * speed;
		rb.velocity = moveDirection;
	}

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.layer == 6)
        {
			rb.velocity = Vector3.zero;
			timer = 0f;
			this.gameObject.SetActive(false);
		}
	}
}
