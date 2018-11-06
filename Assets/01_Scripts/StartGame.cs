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
		
		if (gameController.gamelevel == 1)
		{
			tutorial.SetActive (false);
			ExitBoardPrefab.SetActive(true);
		}	
	}
	public void Comecar()
	{	
		SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialSequencia);
		ExitBoardPrefab.SetActive(true);
		tutorial.SetActive (false);
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
