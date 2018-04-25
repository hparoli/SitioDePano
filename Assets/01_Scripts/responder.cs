using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour {

	private int idTema;

	[SerializeField]
	SpriteRenderer pergunta;
	[SerializeField]
	Button[] answerButtons;
	[SerializeField]
	Text[] answerTexts;
	[SerializeField]
	Text infoResposta;
	[SerializeField]
	QuestionData[] questions;
	[SerializeField]
	GameObject tutorial;

	[Header("Feedback")]
	[SerializeField, Range(0.0f, 5.0f)]
	float feedbackDuration = 1.0f;
	[SerializeField]
	Color defaultColor = Color.white;
	[SerializeField]
	Color correctColor = Color.green;
	[SerializeField]
	Color incorrectColor = Color.red;
	[SerializeField]
	AudioClip clip;

	QuestionData[] shuffledQuestions;
	int questionIndex;

	float acertos;
	float media;
	int notaFinal;

	Coroutine feedbackCorout;


	int QuestionsAmount { get { return questions.Length; } }
	QuestionData CurrentQuestion { get { return shuffledQuestions [questionIndex]; } } 

	void Start () 
	{

		idTema = PlayerPrefs.GetInt ("idTema");

		questionIndex = 0;
		SetShuffledQuestions ();
		UpdateQuestionOutput ();

		infoResposta.text = string.Format ("Respondendo {0} de {1} perguntas ", questionIndex + 1, QuestionsAmount);
		
	}

	void SetShuffledQuestions()
	{
		var questionsList = new List<QuestionData> ();

		QuestionData question = questions [Random.Range (0, questions.Length)];
		for (int i = 0; i < questions.Length; i++) 
		{
			while (questionsList.Contains (question)) 
			{
				question = questions [Random.Range (0, questions.Length)];
			}

			questionsList.Add (question);
			
		}

		shuffledQuestions = questionsList.ToArray ();

	}

	void UpdateQuestionOutput(QuestionData question)
	{
		pergunta.sprite = question.avatar;

		for (int i = 0; i < answerTexts.Length && i < question.answers.Length; i++) 
		{
			answerTexts [i].text = question.answers [i];
		}

	}
	void UpdateQuestionOutput()
	{
		UpdateQuestionOutput (CurrentQuestion);
	}
		
	public void PromptAnswer(int index)
	{
		if (feedbackCorout != null)
			return;

		if(CurrentQuestion.answers [index] == CurrentQuestion.correctAnswer)
		{
			acertos++;
		}

		feedbackCorout = StartCoroutine (PromptAnswer_Routine (index));

	}

	void NextQuestion()
	{
		questionIndex++;

		if (questionIndex < QuestionsAmount)
		{

			UpdateQuestionOutput ();
			infoResposta.text = string.Format ("Respondendo {0} de {1} perguntas ", questionIndex + 1, QuestionsAmount);

		}

		else 
		{
			media = 10 * (acertos / QuestionsAmount);
			notaFinal = Mathf.RoundToInt (media);

			if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString()))
			{

				PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString (), (int) acertos);

			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int) acertos);

			SceneManager.LoadScene("Score");
		}

	}

	public void Comecar()
	{
		tutorial.SetActive (false);
	}

	IEnumerator PromptAnswer_Routine(int index)
	{
			
		for (int i = 0; i < answerButtons.Length; i++) 
		{
			if (CurrentQuestion.answers [i] == CurrentQuestion.correctAnswer)
				answerButtons [i].image.color = correctColor;
			
			else 
			{
				if (i == index)
					answerButtons [i].image.color = incorrectColor;
			}
		}

		yield return new WaitForSeconds (feedbackDuration);

		for (int i = 0; i < answerButtons.Length; i++) 
		{
			answerButtons [i].image.color = defaultColor;
		}

		//Code feedback coroutine here
		feedbackCorout = null;
		NextQuestion ();
	}
		
}
