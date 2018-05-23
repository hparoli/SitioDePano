using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehavior : MonoBehaviour {

	[SerializeField]
	private GameObject waypoint, gm;

	[SerializeField]
	private float moveSpeed;

	// Use this for initialization
	void Start () {
		waypoint = GameObject.Find("waypoint");
		gm = GameObject.Find("GameManager");
		moveSpeed = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	public void Move(){
		this.transform.position = Vector2.MoveTowards(this.transform.position, waypoint.transform.position, moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		gm.GetComponent<ContandoOsBichos>().Conta();
		Destroy(this.gameObject);
	}
}
