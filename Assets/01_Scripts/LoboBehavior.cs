using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboBehavior : MonoBehaviour {

	[SerializeField]
	private int delaySpawn, waypointIndex;

	[SerializeField]
	private GameObject[] waypoints;

	[SerializeField]
	private float moveSpeed;
	
	public GameObject gm;

	[SerializeField]
	private bool move;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GameManager");
		delaySpawn = 3;
		moveSpeed = 2.5f;
		waypoints = new GameObject[5];
		move = false;
		waypoints[0] = GameObject.Find("waypoint1");
		waypoints[1] = GameObject.Find("waypoint2");
		waypoints[2] = GameObject.Find("waypoint3");
		waypoints[3] = GameObject.Find("waypoint4");
		waypoints[4] = GameObject.Find("waypoint5");
		
		this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

		StartCoroutine("Walk");
	}
	
	// Update is called once per frame
	void Update () {
		if(move)
			Move();

		RaycastHit click = new RaycastHit();
		bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out click);
		if (Input.GetMouseButtonDown (0)) {
			if(hit){
				if(click.transform.gameObject.tag == "lobo"){
					Destroy(this.gameObject);
					//feedback pegando lobo
				}
			}	
		}
	}

	
	IEnumerator Walk(){
		yield return new WaitForSeconds(delaySpawn);
		this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		move = true;
	}

	public void Move(){
		this.transform.position = Vector2.MoveTowards(this.transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "waypoints"){
			gm.GetComponent<DeOlhoNoLobo>().SetOvelhas();
			//feedback lobo pegando ovelha
			Destroy(this.gameObject, 1);
		}
	}
}
