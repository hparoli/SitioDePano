using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    public SequenciaController gameController;
	[Space(10)]
	[SerializeField]
	GameObject tutorial;
	[SerializeField]
	GameObject ExitBoardPrefab;



	void Start () 
	{
		
	}

	private void Update() 
	{
		
	}
	public void Comecar()
	{	
		if(gameController.isgame == false)
		{
			SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialSequencia);
			gameController.tutButton.SetActive(true);
			tutorial.SetActive (false);
			ExitBoardPrefab.SetActive(true);
			Time.timeScale = 1;
			ExitBoardPrefab.SetActive(true);
			tutorial.SetActive (false);
		}
		else 
		{
			SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialSequencia);
			gameController.tutButton.SetActive(true);
			tutorial.SetActive (false);
			ExitBoardPrefab.SetActive(true);
			Time.timeScale = 1;
			ExitBoardPrefab.SetActive(true);
			tutorial.SetActive (false);
		}
		
	}
    private void OnMouseDown()
    {
		StartCoroutine(gameController.StartGame());
    }

    public void StartTutorial(){
        //StartCoroutine(gameController.StartGameTutorial());
		StartCoroutine("tutorialTextChanges");
    }


		
}
