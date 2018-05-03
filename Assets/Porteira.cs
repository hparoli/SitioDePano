using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porteira : MonoBehaviour {

	public bool fechada;
	[SerializeField]
	private int abre;
	[SerializeField]
	private int fecha;
	[SerializeField]
	private GameObject porteira;
	// Use this for initialization
	void Update () {
		RaycastHit porteiraClick = new RaycastHit();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out porteiraClick);
            if (Input.GetMouseButtonDown (0)) {
				if (hit) {
                	if (porteiraClick.transform.gameObject.name == porteira.name)
                	{
	                    if(fechada){
							porteira.transform.Rotate(0,0,fecha);
						} else{
							porteira.transform.Rotate(0,0,abre);
						}
						fechada = !fechada;
                	}
				}
			}
	}

}
