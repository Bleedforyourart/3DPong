using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour
{

	public float speed = 1.0f;

	private Transform ballTransform;

	void Start()
	{
		GameObject ballGameObject = GameObject.Find("Ball");
		if (ballGameObject == null)
		{
			Debug.LogWarning("PlayerAI cannot find Ball.");
			enabled = false;
		}
		else
		{
			ballTransform = ballGameObject.transform;
		}
	}
	void FixedUpdate()
	{
	
		float inputSpeed = 0f;

		if (ballTransform.position.z > transform.position.z)
		{
			inputSpeed = 0.8f;
		}
		else if (ballTransform.position.z < transform.position.z)
		{
			inputSpeed = -.8f;
		}


		Vector3 position = transform.position + new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);


		if (inputSpeed > .8f)
		{
			if (position.z > ballTransform.position.z)
			{
				position.z = ballTransform.position.z;
			}
		}
		else if (inputSpeed < .8f)
		{
			if (position.z < ballTransform.position.z)
			{
				position.z = ballTransform.position.z;
			}
		}

		transform.position = position;
	}
}