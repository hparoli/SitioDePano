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

			if(Mathf.Abs(transform.position.x - caminho[waypoint].transform.position.x) < 0.1 && Mathf.Abs(transform.position.y - caminho[waypoint].transform.position.y) < 0.1){
				waypoint++;
			}

			if(waypoint == caminho.Count){
				game.GetComponent<CaminhosSpawner>().fimCaminho = true;
			}
		
		if(game.GetComponent<CaminhosSpawner>().fimCaminho){
			game.GetComponent<CaminhosSpawner>().respondeu = false;
			game.GetComponent<CaminhosSpawner>().StartCoroutine("FeedBack");
		}
		
	}

}
