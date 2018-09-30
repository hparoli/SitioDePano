using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class newMenuControl : MonoBehaviour 
{
	[SerializeField]
	GameObject minigame;
	 int idGame, idTema, noJogo;

	[SerializeField]
	public Image fade;
	[SerializeField]
	int prafabsScale;

	

	[SerializeField]
	public GameObject exitConfirmation, playConfirmation;
	
	

	float duration = 2.5f;

	[SerializeField]
	MenuManagerScripti[] menuManagerScripti;

	 void Start() 
	 {

		
		 if (fade != null)
		 {
			 fade.color = Color.black;
			 StartCoroutine ("Fade");
		 }

		menuManagerScripti[0].roonPrefab.SetActive(true);
		
	 }

	 void Update() 
	 {
		 
	 }

	 public void DoFade()
	 {	
		 fade.color = Color.black;
		 StartCoroutine ("Fade");
	 }

	 IEnumerator Fade()
	 {
		 float count = 0;
		 while (fade.color.a > 0)
		 {
			 count += Time.deltaTime;
			 float value = count / duration;
			 Color color = Color.Lerp(Color.black, Color.clear, value);
			 fade.color = color;
			 yield return null;
		}
		fade.color = Color.clear;
	 }

	 public void InstanceRoom(string RoomName)
	 {
		for (int i = 0; i < menuManagerScripti.Length; i++)
		{
			if (menuManagerScripti[i].roonId == RoomName)
			{
				menuManagerScripti[i].roonPrefab.SetActive(true);
			}
			else 
			{
				menuManagerScripti[i].roonPrefab.SetActive(false);
			}
		}
	 }

	 public void ExitConfirmation()
	 {
		if(!exitConfirmation.activeSelf){
			exitConfirmation.SetActive(true);
		} else {
			exitConfirmation.SetActive(false);
		}
	}
	
	public void PlayConfirmation(int game)
	{
		if(!playConfirmation.activeSelf){
			playConfirmation.SetActive(true);
		} 
		else {
			playConfirmation.SetActive(false);
		}
		
		minigame.GetComponent<GameSelect>().MiniGameSelected(game);
	}

	 public void playGame(int gameValue)
	 {
		 SceneManager.LoadScene (gameValue);	
	 }

	 public void ExitGame()
	 {
		Application.Quit();
	 }


}
