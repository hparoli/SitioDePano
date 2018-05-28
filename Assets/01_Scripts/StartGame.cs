using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public SequenciaController gameController;
	public GameObject Tutorial;
	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;


	void Start () {
		Tutorial.SetActive (true);
		StartTutorial ();
	
	}
    private void OnMouseDown()
    {
		StartCoroutine(gameController.StartGame());
    }

    public void StartTutorial(){
        //StartCoroutine(gameController.StartGameTutorial());
		StartCoroutine("tutorialTextChanges");
    }

	public void Begin(){
		Tutorial.SetActive (false);
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
}
