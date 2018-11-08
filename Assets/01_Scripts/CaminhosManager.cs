using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhosManager : MonoBehaviour {

	public float moveSpeed;
	public GameObject game;
	public int waypoint;

	
	void Awake()
	{
		game = GameObject.Find("GameManager");	
	}
	void Start () {
		waypoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move(List<GameObject> caminho){

		transform.position = Vector2.MoveTowards(transform.position,
			                                            caminho[waypoint].transform.position,
														moveSpeed * Time.deltaTime);

			if(Mathf.Abs(transform.position.x - caminho[waypoint].transform.position.x) < 0.05 && Mathf.Abs(transform.position.y - caminho[waypoint].transform.position.y) < 0.05){
				waypoint++;
			}

			if(waypoint == caminho.Count){
				game.GetComponent<AbelhaManager>().destino = true;
			}
		
		if(game.GetComponent<AbelhaManager>().destino){
			game.GetComponent<AbelhaManager>().respondeu = false;
			game.GetComponent<AbelhaManager>().StartCoroutine("FeedBack");
		}
		
	}

}
