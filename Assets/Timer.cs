using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public GameObject gameOver;

	public GameObject goldMedal;
	public GameObject silverMedal;
	public GameObject bronzeMedal;

	public Text timerText;
	private float startTime;
	private bool finished = false;

	void Start () {
	
		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {

		if (finished)
			return;

		float t = Time.time - startTime;

		string minutes = ((int)t / 60).ToString ();
		string seconds = (t % 60).ToString ("f0");
	
		timerText.text = minutes + ":" + seconds;

		if (gameOver.activeSelf)
			finished = true;

		if (t <= 30 && gameOver.activeSelf) {
			goldMedal.SetActive (true);
			silverMedal.SetActive (true);
			bronzeMedal.SetActive (true);
		} else if (t <= 60 && t >= 31 && gameOver.activeSelf) {
			silverMedal.SetActive (true);
			bronzeMedal.SetActive (true);
		}
		else if (t >= 61 && gameOver.activeSelf)
			bronzeMedal.SetActive (true);
	}
}
