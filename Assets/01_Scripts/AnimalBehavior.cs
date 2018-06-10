using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehavior : MonoBehaviour {

	[SerializeField]
	private GameObject waypoint;
	[SerializeField]
	private GameObject gm;

	private float moveSpeed;

	// Use this for initialization
	void Start () {
		waypoint = null;
		moveSpeed = 0;
		gm = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		if(waypoint != null)
			Move();
	}

	public void Move(){
		this.transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, moveSpeed * Time.deltaTime);
	}

	public void SetAnimal(GameObject wp, int speed){
		if(moveSpeed == 0 && waypoint == null){
			waypoint = wp;
			moveSpeed = speed;
		}
	}
}
