using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DollSelect : MonoBehaviour {

	private int idTema;
	private int notaFinal;

	[SerializeField]
	Spawn spawn;

	[SerializeField]
	GameObject sistemControl;


	void Start(){



		spawn =  FindObjectOfType <Spawn> ();
		
		//PASTE TO CREATE DOLLS
		//spawn.CreateDolls ();
		//
	}

	void Update()
	{
		
		DollSelected ();
	}

	void DollSelected(){

		if (Input.GetMouseButtonDown (0)) {

		
            RaycastHit Doll = new RaycastHit();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out Doll);

			if (hit) {
                if (Doll.transform.gameObject.tag == "Doll")
                {
                    Debug.Log("Mouse");
                    SoundManager.instance.Play("Player", SoundManager.instance.clipList.DollClick);
					if (spawn.gamelevel == 0)
					{
						spawn.CreatDoll ();
					}
					else if (spawn.gamelevel == 1)
					{
						spawn.CreatDoll2();
					}
					else if (spawn.gamelevel == 2)
					{
						spawn.CreatDoll2();
					}
					
					
					Destroy (GameObject.Find ("Aninha(Clone)"), 0f);
						
                }
            }
		} 
	}



    private IEnumerator MissClick()
    {
        yield return new WaitForSeconds(1);
        SoundManager.instance.Play("Player", SoundManager.instance.clipList.MissClick);
    }


}



