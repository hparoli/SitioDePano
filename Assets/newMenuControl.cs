using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class newMenuControl : MonoBehaviour {

	[SerializeField]
	GameObject ButtonsMovimentControl;
	[SerializeField]
	GameObject[] ButtonsCotrol;
	[SerializeField]
	GameObject[] miniGameButtons;
	[SerializeField]
	GameObject FadeControl;
	[SerializeField]
	Animator FadeAnim;

	Vector3 centerPosition = new Vector3 (0,0,0);
	Vector3 startPosition = new Vector3 (15,0,0);



	// Use this for initialization
	void Start ()
	 {
		 FadeControl.SetActive(false);

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void ButtonsMoviment(string Control)
	{
		Vector3 axisButtons = Vector3.up;
		if (Control == "Up")
		{
		ButtonsMovimentControl.transform.position = Vector3.MoveTowards(ButtonsMovimentControl.transform.position, axisButtons * 500, 7f * Time.deltaTime);
		}
		if (Control == "Down")
		{
		ButtonsMovimentControl.transform.position = Vector3.MoveTowards(ButtonsMovimentControl.transform.position, -axisButtons * 500, 7f * Time.deltaTime);
		}
	}
	IEnumerator ControlMoviment()
{	
	
	FadeControl.SetActive(true);
	FadeAnim.SetBool("doFade", true);
	yield return new WaitForSeconds (1f);
	FadeControl.SetActive(false);
	yield return new WaitForSeconds (1f);
}
   public void sceneMoviment(int gameNumber)
	{

		StartCoroutine("ControlMoviment");
		
		if (gameNumber == 0)
		{
			ButtonsCotrol[0].transform.position = centerPosition;
			ButtonsCotrol[1].transform.position = startPosition;
		}	

		if (gameNumber == 1)
		{
			ButtonsCotrol[0].transform.position = startPosition;
			ButtonsCotrol[1].transform.position = centerPosition;
		}		
	}

	public void StartGame(int gameValue)
	{
		LoadingScreenManager.LoadScene(gameValue);
	}
	
}
