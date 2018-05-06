using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	[SerializeField]
	private GameObject minigame;
	
	[SerializeField]
	private int idGame;
	
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
	private Sprite[] sprites;

	[SerializeField]
	private Image btnPlay;

	[SerializeField]
	private GameObject exitConfirmation, playConfirmation;

	[SerializeField]
	public GameObject Maozinha;

	void Start () {
		canPress = false;
		StartCoroutine("ApareceInicio");
		idGame = 0;
		btnPlay.sprite = sprites[idGame];
	}
	
	void Update(){
		if(canPress){
			if(Input.anyKeyDown){
				Maozinha.SetActive (false);
				inicio.SetActive(false);
				mainMenu.SetActive(true);
				minigame.GetComponent<GameSelect>().MiniGameSelected(idGame + 1);
			}
		}
	}

	public void SelectRight(){
		if(idGame == (sprites.Length - 1)){
			idGame = 0;
		} else {
			idGame++;
		}
		btnPlay.sprite = sprites[idGame];
		minigame.GetComponent<GameSelect>().MiniGameSelected(idGame + 1);
	}

	public void SelectLeft(){
		if(idGame == 0){
			idGame = (sprites.Length - 1);
		} else {
			idGame--;
		}
		btnPlay.sprite = sprites[idGame];
		minigame.GetComponent<GameSelect>().MiniGameSelected(idGame + 1);
	}

	public void Exit(){
		Application.Quit();
	}

	public void ExitConfirmation(){
		if(!exitConfirmation.activeSelf){
			exitConfirmation.SetActive(true);
		} else {
			exitConfirmation.SetActive(false);
		}
	}
	
	public void PlayConfirmation(){
		if(!playConfirmation.activeSelf){
			playConfirmation.SetActive(true);
		} else {
			playConfirmation.SetActive(false);
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
		yield return new WaitForSeconds(.5f);
		canPress = true;
	}
}
