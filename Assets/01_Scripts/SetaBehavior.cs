using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaBehavior : MonoBehaviour{

	public int x, y;

	public string tipoSeta, lado;

		

	public AbelhaManager abelhaManager;

	private Quaternion startingRotation;
	public float speed = 10f;

	void Start(){
		
		
		abelhaManager = GameObject.Find("GameManager").GetComponent<AbelhaManager>();
	}

	void Update(){
		
	}

	

	public IEnumerator Rotate(){
		
		Quaternion startingRotation = this.transform.rotation;
		Quaternion finalRotation = Quaternion.Euler( 0, 0, -90 ) * this.transform.rotation;
		if(lado == "left") lado = "up";
		else if(lado == "up") lado = "right";
		else if(lado == "right") lado = "down";
		else if(lado == "down") lado = "left";
		while(this.transform.rotation != finalRotation){
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime*speed);
			yield return 0;
		}
		abelhaManager.click = true;
		StopCoroutine(Rotate());	
	}
}