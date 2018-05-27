using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	[SerializeField]
	private GameObject minigame;
	
	[SerializeField]
	private int idGame, idTema, noJogo;
	
	[SerializeField]
	private GameObject inicio;
	
	[SerializeField]
	private GameObject mainMenu;

	[SerializeField]
	private Text text;
	
	[SerializeField]
	private Text text2;
	
	[SerializeField]
	public Color standard;
	
	[SerializeField]
	private bool canPress;

	[SerializeField]
	private string[] btnTexts;

	[SerializeField]
	private Button[] btnPlay;

	[SerializeField]
	private GameObject exitConfirmation, playConfirmation;

	[SerializeField]
	public GameObject Maozinha;

	void Start () {
		noJogo = PlayerPrefs.GetInt ("NoJogo", 0);
		canPress = false;
		idGame = 1;
		if(noJogo == 0){
			StartCoroutine("ApareceInicio");
		} else {
			inicio.SetActive(false);
			mainMenu.SetActive(true);
			Maozinha.SetActive(false);
		}
		MudaBotoes(idGame);
	}
	
	void Update(){
		if(canPress){
			if(Input.anyKeyDown){
				Maozinha.SetActive (false);
				inicio.SetActive(false);
				mainMenu.SetActive(true);
			}
		}
	}

	public void SelectRight(){
		if(idGame == 2){
			idGame --;
		} else {
			idGame++;
		}
		MudaBotoes(idGame);
	}

	public void SelectLeft(){
		if(idGame == 1){
			idGame++;
		} else {
			idGame--;
		}
		MudaBotoes(idGame);
	}

	public void Exit(){
		PlayerPrefs.SetInt ("NoJogo", 0);
		Application.Quit();
	}

	public void ExitConfirmation(){
		if(!exitConfirmation.activeSelf){
			exitConfirmation.SetActive(true);
		} else {
			exitConfirmation.SetActive(false);
		}
	}
	
	public void PlayConfirmation(int game){
		if(!playConfirmation.activeSelf){
			playConfirmation.SetActive(true);
		} else {
			playConfirmation.SetActive(false);
		}
		int j;
		if(idGame == 1)
		   j = game;
		else 
		   j = game + 4;
		minigame.GetComponent<GameSelect>().MiniGameSelected(j);
	}

	public void MudaBotoes(int num){
		for(int i = 0; i < btnPlay.Length; i++){
			int j;
			if(num == 1){
				j = i;
				btnPlay[i].interactable = true;
			} else {
				j = i + 4;
				if(i > 1){
					btnPlay[i].interactable = false;
				}

			}
			btnPlay[i].GetComponentInChildren<Text>().text = btnTexts[j];
		}
	}
	private IEnumerator ApareceInicio(){
		yield return new WaitForSeconds(2f);
		for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = text.color;
			Color d = text2.color;
            c.a = f;
			d.a = f;
            text.color = c;
			text2.color = d;
            new WaitForSeconds(.5f);
            yield return null;
        }
		yield return new WaitForSeconds(.5f);
		text2.GetComponent<Animator>().enabled = true;
		yield return new WaitForSeconds(.2f);
		canPress = true;
	}
}
