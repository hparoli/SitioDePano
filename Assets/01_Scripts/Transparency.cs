using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Transparency : MonoBehaviour {

	Image image;

	void Start() {
		image = GetComponent<Image>();

		Color c = image.color;
		c.a = 0;
		image.color = c;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
