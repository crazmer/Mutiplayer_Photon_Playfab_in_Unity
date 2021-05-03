using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour

{

	public float speed = 10.0f;
	public float accuracy = 0.01f;
	public Transform goal;


	void LateUpdate()
	{
		this.transform.LookAt(goal.position);
		Vector3 direction = goal.position - this.transform.position; //This is the vector between the goal position and the Character.
		//Debug.DrawRay(this.transform.position, direction, Color.red);

		if (direction.magnitude > accuracy)
		{
			this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
		}

	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
			Destroy(gameObject);
        }
    }
}
