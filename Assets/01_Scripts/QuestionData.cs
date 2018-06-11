using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestionData
{
	#if UNITY_EDITOR
	public string question;
	#endif

	public Sprite avatar;
	public string[] answers;
	public string correctAnswer;
	public Animator anins;
}
