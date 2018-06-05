using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeOlhoNoLobo : MonoBehaviour {

	[SerializeField]
	private GameObject[] spawns, arbustos;

	[SerializeField]
	private GameObject lobo,fumOvelha;

	[SerializeField]
	private float delay, time, moveSpeed;

	[SerializeField]
	private Text cronometro;
	public GameObject[] ovelhaCena;
	public int ovelhas;
	public bool comeca;


	[Header("Tutorial")]
	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;
	[SerializeField]
	GameObject tutorial;
	[SerializeField]
	GameObject[] boardsTutorial;
	[SerializeField]
	GameObject[] imagesTutorial;


	// Use this for initialization
	void Start () {
		time = 45f;
		delay = 3f;
		ovelhas = 0;
		moveSpeed = 1.5f;
		comeca = false;
		tutorial.SetActive (true);
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);imagesTutorial [2].SetActive (false);
	}

	public void ChangeTextTutorialForward(){
		indexTutorial++;
		infoTutorial.text = txtTutorial [indexTutorial];
		if(indexTutorial == 0){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
		}
		if(indexTutorial == 1){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
			imagesTutorial [2].SetActive (false);
		}
		if(indexTutorial == 2){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (true);
		}
		if(indexTutorial == 3){
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
		}
	}

	public void ChangeTextTutorialBack(){
		indexTutorial--;
		infoTutorial.text = txtTutorial [indexTutorial];
		if(indexTutorial == 0){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
		}
		if(indexTutorial == 1){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (true);
			imagesTutorial [2].SetActive (false);
		}
		if(indexTutorial == 2){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (true);
		}
		if(indexTutorial == 3){
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (true);
			imagesTutorial [1].SetActive (false);
			imagesTutorial [2].SetActive (false);
		}

	}


	// Update is called once per frame
	void Update () {
		
		if (comeca) {
			if (time > 0) {
				time -= Time.deltaTime;
				cronometro.text = time.ToString ("f0");
			} else {
				time = 0;
			}

			if (time <= 30) {
				delay = 2.75f;
				moveSpeed = 2.0f;
			}
		
			if (time <= 20) {
				delay = 2.5f;
				moveSpeed = 2.3f;
			}
		
			if (time <= 10) {
				delay = 2.25f;
				moveSpeed = 2.7f;
			}

		}
		if(ovelhas == 10)
			StartCoroutine("GameOver");
	}




	public void StartGame(){
		comeca = true;
		tutorial.SetActive (false);
		StartCoroutine("SpawnLobo");
	}

	IEnumerator SpawnLobo(){
		int spawnPointIndex = Random.Range (0, spawns.Length);
		GameObject loboGO = Instantiate (lobo, spawns[spawnPointIndex].transform.position, spawns[spawnPointIndex].transform.rotation);
		StartCoroutine("Arbusto", spawnPointIndex);
		yield return new WaitForSeconds(0.1f);
		loboGO.GetComponent<LoboBehavior>().SetWaypointIndex(spawnPointIndex, moveSpeed);
		yield return new WaitForSeconds(delay);
		
		if(time > 0){
			StartCoroutine("SpawnLobo");
		} else{
			StartCoroutine("GameOver");
		}
	}

	IEnumerator Arbusto(int index){
		arbustos[index].GetComponent<Animator>().SetBool("Mexe",true);
		yield return new WaitForSeconds(2f);
		arbustos[index].GetComponent<Animator>().SetBool("Mexe",false);
	}

	IEnumerator GameOver(){
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(8);
	}

	public void SetOvelhas(){
		Vector3 pos = new Vector3 (this.transform.position.x + 0.4f, this.transform.position.y + 1, this.transform.position.z);
		Instantiate (fumOvelha, pos, this.transform.rotation);
		Destroy (ovelhaCena [ovelhas]);
		ovelhas++;
	}
}
