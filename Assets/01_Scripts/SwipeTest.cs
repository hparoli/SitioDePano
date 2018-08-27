using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeTest : MonoBehaviour {

	public Swipe swipeControl;
	public Transform background;
	private Vector3 desiredPosition;

	[SerializeField]
	string SwipeCheck;


	void Update () 
	{
		MovimentCheck();
	}

	public void MovimentCheck()
	{
		if (SwipeCheck == "Hide")
		{
			if (swipeControl.SwipeLeft)
				desiredPosition += Vector3.left;
			if (swipeControl.SwipeRight)
				desiredPosition += Vector3.right;

		background.transform.position = Vector3.MoveTowards (background.transform.position, desiredPosition * 2, 5f * Time.deltaTime);
		}

		if (SwipeCheck == "Menu")
		{
			if (swipeControl.SwipeLeft)
				desiredPosition += Vector3.left;
			if (swipeControl.SwipeRight)
				desiredPosition += Vector3.right;
			if (swipeControl.SwipeUp)
				desiredPosition += Vector3.up;
			if (swipeControl.SwipeDown)
				desiredPosition += Vector3.down;
		

		background.transform.position = Vector3.MoveTowards (background.transform.position, desiredPosition * 2, 5f * Time.deltaTime);
		}
	}


}
