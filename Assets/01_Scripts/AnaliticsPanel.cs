using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnaliticsPanel : MonoBehaviour
 {
	 [SerializeField]
	 Text[] timeOutput;

	 [SerializeField]
	 AnalitcsSystem[] analitcsSystem;
	  
	// Use this for initialization
	void Start () 
	{
		ditadosTime();
		memoriaTime();
		sequenciaTime();
		playTime();
		pastoreiraTime();
		ovosTime();
		lobosTime();
		bichosTime();
	}

	public void GoToMenu()
	{
		Application.LoadLevel("newMenu");
	}

	public void GameInfoSelected(string IDgame)
	{
		for (int i = 0; i < analitcsSystem.Length; i++)
		{
			if (analitcsSystem[i].Id == IDgame)
			{
				analitcsSystem[i].analiticsGameObject.SetActive(true);
			}
			else
			{
				analitcsSystem[i].analiticsGameObject.SetActive(false);
			}
		}
	}

	


	#region  Save Information all games
	void ditadosTime()
	{
		int seconds = (int)AnaliticsControl.ditadosTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[0].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void memoriaTime()
	{
		int seconds = (int)AnaliticsControl.memoriaTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[1].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void sequenciaTime()
	{
		int seconds = (int)AnaliticsControl.sequenciaTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[2].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void playTime()
	{
		int seconds = (int)AnaliticsControl.playTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[3].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void pastoreiraTime()
	{
		int seconds = (int)AnaliticsControl.pastoreiraTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[4].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void ovosTime()
	{
		int seconds = (int)AnaliticsControl.ovosTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[5].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void lobosTime()
	{
		int seconds = (int)AnaliticsControl.lobosTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[6].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
	void bichosTime()
	{
		int seconds = (int)AnaliticsControl.bichosTime;
		int minutes = seconds / 60;
		seconds = seconds % 60;
		timeOutput[7].text = string.Format("{0}:{1}", minutes.ToString("00"), seconds.ToString("00"));
	}
#endregion

	
	
	
}
