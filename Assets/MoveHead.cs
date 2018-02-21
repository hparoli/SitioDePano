using UnityEngine;
using System.Collections;

public class MoveHead : MonoBehaviour {

	public GameObject head1;
	public GameObject head2;

	void Update () {
	
		StartCoroutine (RotationTimer ());

	}
	

	IEnumerator RotationTimer(){

		yield return new WaitForSeconds (1);
		head1.SetActive (false);
		head2.SetActive (true);

	}
}
