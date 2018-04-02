using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void GoToMainMenu(){
		SceneManager.LoadScene(0);
	}
}
