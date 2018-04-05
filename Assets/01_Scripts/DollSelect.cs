using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DollSelect : MonoBehaviour {

	private int idTema;

	private int notaFinal;

	private float tempo;


	void Start(){
		idTema = PlayerPrefs.GetInt ("idTema");
	}

	void Update()
	{
		Cronometro ();
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
                    Invoke("ToScore", 0.2f);
                }
                else {
                    StartCoroutine ("MissClick");
                }
            }
        }
	}

    private IEnumerator MissClick()
    {
        yield return new WaitForSeconds(1);
        SoundManager.instance.Play("Player", SoundManager.instance.clipList.MissClick);
    }

	void Cronometro(){

		tempo += 1 * Time.deltaTime;
}

	void ToScore(){

		if (tempo < 2f){

			notaFinal = 10;

		}

		else if (tempo <= 10f) {

			notaFinal = 5;
		}


		PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
		SceneManager.LoadScene ("Score");

	}
}

