using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour {

	[SerializeField]
	private GameObject[] waypoints = new GameObject[7];
	
	[SerializeField]
	private int waypointIndex, porteiraIndex, casasIndex;
	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private GameObject[] porteirasWaypoints, porteiras, casasWaypoints;

	
	[SerializeField]
	private string animal;

	[SerializeField]
	private GameObject aninha;

	public AudioClip[] sons;
	private AudioSource AudioSRC;

	





	// Use this for initialization
	void Start () 
	{
		
		AudioSRC = GetComponent<AudioSource> ();

		waypointIndex = 0;
		
		casasIndex = 4;
		
		waypoints = new GameObject[7];
		waypoints[0] = GameObject.Find("waypoint1");
		waypoints[1] = GameObject.Find("waypoint2");
		waypoints[2] = GameObject.Find("waypoint3");
		waypoints[3] = GameObject.Find("waypointSaida");
		waypoints[4] = GameObject.Find("waypointOvelha");
		waypoints[5] = GameObject.Find("waypointVaca");
		waypoints[6] = GameObject.Find("waypointCavalo");
		
		porteirasWaypoints = new GameObject[3];
		porteirasWaypoints[0] = GameObject.Find("waypoint1");
		porteirasWaypoints[1] = GameObject.Find("waypoint2");
		porteirasWaypoints[2] = GameObject.Find("waypoint3");
		
		porteiras = new GameObject[3];
		porteiras[0] = GameObject.Find("Porteira1");
		porteiras[1] = GameObject.Find("Porteira2");
		porteiras[2] = GameObject.Find("Porteira3");
		
		casasWaypoints = new GameObject[4];
		casasWaypoints[0] = GameObject.Find("waypointOvelha");
		casasWaypoints[1] = GameObject.Find("waypointVaca");
		casasWaypoints[2] = GameObject.Find("waypointCavalo");
		casasWaypoints[3] = GameObject.Find("waypointSaida");
		
		animal = this.gameObject.GetComponent<AnimalDisplay>().anim;
		aninha = GameObject.Find("GameManager");


	


	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	public void Move(){
		this.transform.position = Vector2.MoveTowards(this.transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		
		for(int i = 0; i < porteirasWaypoints.Length; i++){
			if(col.gameObject.name == porteirasWaypoints[i].name){
				porteiraIndex = i;
			}
		}

		for(int i = 0; i < casasWaypoints.Length; i++){
			if(col.gameObject.name == casasWaypoints[i].name){
				casasIndex = i;
			}
		}
		
		VerificaWayPoint();
		
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.name == porteirasWaypoints[porteiraIndex].name){
			float posx = Mathf.Abs(this.transform.position.x - waypoints[waypointIndex].transform.position.x);
			float posy = Mathf.Abs(this.transform.position.y - waypoints[waypointIndex].transform.position.y);
			if(posx <= 0.1f && posy <= 0.1f){
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

	void VerificaWayPoint(){
		if((animal == "ovelha" && casasIndex == 0) || (animal == "vaca" && casasIndex == 1) ||
		  (animal == "cavalo" && casasIndex == 2) || animal == "lobo" &&  casasIndex == 3){
			    aninha.GetComponent<AninhaPastoreira>().Pontua(1);
			    aninha.GetComponent<AninhaPastoreira>().Conta();
				aninha.GetComponent<AninhaPastoreira>().aninhaFeedBacks.SetTrigger("Palma");
			  //som de acerto
				AudioSRC.PlayOneShot(sons[0]);
			    Debug.Log(aninha.GetComponent<AninhaPastoreira>().notaFinal);
			    Destroy(this.gameObject, 1f);
		} else if((animal == "vaca" || animal == "ovelha" || animal == "cavalo") && casasIndex == 3){
			//som de erro
			AudioSRC.PlayOneShot(sons[1]);
			aninha.GetComponent<AninhaPastoreira>().Pontua(0);
			aninha.GetComponent<AninhaPastoreira>().Conta();
			aninha.GetComponent<AninhaPastoreira>().aninhaFeedBacks.SetTrigger("Triste");
			
			Debug.Log(aninha.GetComponent<AninhaPastoreira>().notaFinal);

			Destroy(this.gameObject, 1f);
		} else if (animal == "lobo" && (casasIndex == 0 || casasIndex == 1 || casasIndex == 2)){
			//som de erro
			AudioSRC.PlayOneShot(sons[1]);
			aninha.GetComponent<AninhaPastoreira>().Pontua(0);
			aninha.GetComponent<AninhaPastoreira>().Conta();
			aninha.GetComponent<AninhaPastoreira>().aninhaFeedBacks.SetTrigger("Triste");
			
			Debug.Log(aninha.GetComponent<AninhaPastoreira>().notaFinal);

			Destroy(this.gameObject, 1f);
		} else if(((animal == "ovelha" && casasIndex != 0) || (animal == "vaca" && casasIndex != 1) || 
		         (animal == "cavalo" && casasIndex != 2)) && casasIndex != 4){
			aninha.GetComponent<AninhaPastoreira>().aninhaFeedBacks.SetTrigger("Triste");
			//som de erro
			AudioSRC.PlayOneShot(sons[1]);
			Debug.Log(aninha.GetComponent<AninhaPastoreira>().notaFinal);
			aninha.GetComponent<AninhaPastoreira>().Conta();

			Destroy(this.gameObject, 1f);
 		}
	}
}
