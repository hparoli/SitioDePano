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


	public GameObject Tutorial;
	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;


	// Use this for initialization
	void Start () {
		time = 45f;
		delay = 3f;
		ovelhas = 0;
		moveSpeed = 1.5f;
		StartTutorial ();
		Tutorial.SetActive (true);
		comeca = false;
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

	public void StartTutorial(){
	
		StartCoroutine("tutorialTextChanges");
	}

	public IEnumerator tutorialTextChanges(){


		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 4){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);

		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 4){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);

		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 4){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);

		infoTutorial.text = txtTutorial [indexTutorial];
		if (indexTutorial < 4){
			indexTutorial++;
		}
		yield return new WaitForSeconds (3);
	}


	public void StartGame(){
		comeca = true;
		Tutorial.SetActive (false);
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
