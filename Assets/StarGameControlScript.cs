using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarGameControlScript : MonoBehaviour 
{
	public void StartGame()
	{
		LoadingScreenManager.LoadScene(1);

	}
	
}
