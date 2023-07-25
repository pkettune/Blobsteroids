using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float thrustSpeed = 1.0f;
	public float turnSpeed = 1.0f;
	private Rigidbody2D rigidbody;
	private bool thrusting;
	private float turnDirection;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}
	void Update()
    {
        thrusting = (Input.GetKey(KeyCode.W));

		if (Input.GetKey(KeyCode.A))
		{
			turnDirection = 1.0f;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			turnDirection = -1.0f;
		}
		else
		{
			turnDirection = 0.0f;
		}

    }
	private void FixedUpdate()
	{
		if (thrusting)
		{
			rigidbody.AddForce(this.transform.up * this.thrustSpeed);
		}

		if (turnDirection != 0.0f)
		{
			rigidbody.AddTorque(turnDirection * this.turnSpeed);
		}
	}
}
