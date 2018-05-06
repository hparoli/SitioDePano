using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour {

	[SerializeField]
	private GameObject[] waypoints;
	
	[SerializeField]
	private int waypointIndex, porteiraIndex;
	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private GameObject[] porteirasWaypoints, porteiras, casasWaypoints;

	// Use this for initialization
	void Start () {
		waypointIndex = 0;
		
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Debug.Log(waypointIndex + ", " + porteiraIndex);
	}

	public void Move(){
		this.transform.position = Vector2.MoveTowards(this.transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		Debug.Log(col.gameObject.name);
		for(int i = 0; i < porteirasWaypoints.Length; i++){
			if(col.gameObject.name == porteirasWaypoints[i].name){
				porteiraIndex = i;
			}
		}
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.name == porteirasWaypoints[porteiraIndex].name){
			if(this.transform.position == waypoints[waypointIndex].transform.position){
				porteiras[porteiraIndex].GetComponent<Porteira>().canMove = false;
				if(porteiras[porteiraIndex].GetComponent<Porteira>().fechada)
					waypointIndex++;
				else
					waypointIndex += 4;				
			}
		}
	}

	void OnTriggerExit(Collider col){
		porteiras[porteiraIndex].GetComponent<Porteira>().canMove = true;
	}
}
