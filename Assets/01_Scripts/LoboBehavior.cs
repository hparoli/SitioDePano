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

	private AudioSource source;
	public AudioClip Feed_som;

	private Animator anim;

	[SerializeField]
	private string spawn;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		anim = this.gameObject.GetComponent<Animator>();
		gm = GameObject.Find("GameManager");
		delaySpawn = 3;
		move = false;
		waypoints = new GameObject[4];
		waypoints[0] = GameObject.Find("waypoint1");
		waypoints[1] = GameObject.Find("waypoint2");
		waypoints[2] = GameObject.Find("waypoint3");
		waypoints[3] = GameObject.Find("waypoint4");
		
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
					source.PlayOneShot (Feed_som);
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

	public void SetWaypointIndex(int spawn, float speed){
		moveSpeed = speed;
		waypointIndex = spawn;		
		anim.SetInteger("Lado", spawn);
	}

	void OnTriggerEnter(Collider col){
		

		if(col.tag == "waypoints"){
			//feedback lobo pegando ovelha
			source.PlayOneShot (Feed_som);

			gm.GetComponent<DeOlhoNoLobo>().SetOvelhas();
			Destroy(gameObject, .5f);

		}
	}

}
