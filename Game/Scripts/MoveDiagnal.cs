using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagnal : MonoBehaviour {

	public GameObject[] points;
	private float speed = 1f;
	public Vector3 startPosition;
	public Vector3 endPosition;
	private float time;
	public float angle;
	public int n = 0;


		

	void Start()
	{
		transform.position = points [0].transform.position;
		// spawn a random number of enemies at a random time between x-y range
		//spawn time between 3 and 5 seconds

	

	    // when button is clicked
	}

	void OnBecameInvisible()
	{
		if(Vector3.Distance(startPosition,gameObject.transform.position) > Vector3.Distance(startPosition,points[1].transform.position))
		{

			Debug.Log ("Use transparency here");

		}

	}
		
	public void move(){
		startPosition = points [0].transform.position;
		endPosition = points [1].transform.position;
		float pathLength = Vector3.Distance (startPosition, endPosition);
		angle = Vector3.Angle (startPosition, endPosition);
		float step = speed * Time.deltaTime;

		// add speed/slow object later and to decrease health faster etc

		if (!(gameObject.transform.position.Equals(endPosition))) {

			transform.position = Vector3.MoveTowards(transform.position,endPosition , step);
	
		} else if(gameObject.transform.position.Equals(endPosition))
		{
			//addcomponent for health
			// add health script here
			Destroy (gameObject);
		}

	}
		
	void FixedUpdate()
	{
		move();
		OnBecameInvisible ();
	
	}







}
