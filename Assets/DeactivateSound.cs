using UnityEngine;
using System.Collections;

public class DeactivateSound : MonoBehaviour {

	public GameObject gameOverScreen;
	public GameObject soundObj;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (gameOverScreen.activeSelf)
			soundObj.SetActive (false);

	}
}
