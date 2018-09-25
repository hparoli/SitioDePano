using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class newMenuControl : MonoBehaviour 
{
	[SerializeField]
	public Image fade;
	[SerializeField]
	GameObject StartPos;
	

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
				GameObject copy = Instantiate (menuManagerScripti[i].roonPrefab, StartPos.transform.position, StartPos.transform.rotation) as GameObject;
				copy.transform.parent = StartPos.transform;
			}
		}
	 }


}
