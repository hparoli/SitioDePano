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

	private Animator anim;

	[SerializeField]
	private string spawn;

	// Use this for initialization
	void Start () {
		anim = this.gameObject.GetComponent<Animator>();
		gm = GameObject.Find("GameManager");
		delaySpawn = 3;
		moveSpeed = 2.5f;
		move = false;
		waypoints = new GameObject[6];
		waypoints[0] = GameObject.Find("waypoint1");
		waypoints[1] = GameObject.Find("waypoint2");
		waypoints[2] = GameObject.Find("waypoint3");
		waypoints[3] = GameObject.Find("waypoint4");
		waypoints[4] = GameObject.Find("waypoint5");
		waypoints[5] = GameObject.Find("waypoint6");
		
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
				if(click.transform.gameObject.tag == "lobo" && click.transform.gameObject.GetInstanceID() == this.gameObject.GetInstanceID()){
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

	void SetWaypointIndex(string spawn){

		if(spawn == "spawn1"){
			waypointIndex = (int)Random.Range(4, 6);
			anim.SetInteger("Lado", 2);
		}

		if(spawn == "spawn2"){
			waypointIndex = (int)Random.Range(3, 5);
			if(waypointIndex == 4)
				anim.SetInteger("Lado", 1);
			else
				anim.SetInteger("Lado", 2);
		}

		if(spawn == "spawn3"){
			waypointIndex = (int)Random.Range(2, 4);
			if(waypointIndex == 2)
				anim.SetInteger("Lado", 1);
			else
				anim.SetInteger("Lado", 0);
		}

		if(spawn == "spawn4" || spawn == "spawn5"){
			waypointIndex = (int)Random.Range(1, 3);
			anim.SetInteger("Lado", 0);
		}

		if(spawn == "spawn6"){
			waypointIndex = (int)Random.Range(0, 2);
			anim.SetInteger("Lado", 3);
		}

		if(spawn == "spawn7"){
			int i = (int)Random.Range(0, 2);
			if (i == 0)
				waypointIndex = i;
			else 
				waypointIndex = 5;
			anim.SetInteger("Lado", 2);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "waypoints"){
			gm.GetComponent<DeOlhoNoLobo>().SetOvelhas();
			//feedback lobo pegando ovelha
			Destroy(this.gameObject, 1);
		}

		if(col.tag == "spawn"){
			spawn = col.gameObject.name;
			Debug.Log(spawn);
			SetWaypointIndex(spawn);
		}
	}

}
