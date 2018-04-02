using UnityEngine;
using System.Collections;

public class ObjectSelection : MonoBehaviour {

	public GameObject gameOver;

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("Pressed left click, casting ray.");
			CastRay();
		}       
	}

	void CastRay() {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Infinity);
		if (hit.collider != null && hit.transform == transform) {
			Debug.Log (hit.collider.gameObject.name);
			gameOver.SetActive (true);
		}
	}			
}