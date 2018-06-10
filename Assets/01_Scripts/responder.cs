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

	public AudioClip C_Answer;
	public AudioClip W_Answer;
	private AudioSource source;

	QuestionData[] shuffledQuestions;
	int questionIndex;

	float acertos;
	float media;
	int notaFinal;

	[Header("Tutorial")]
	public string [] txtTutorial;
	public Text infoTutorial;
	int indexTutorial = 0;
	[SerializeField]
	GameObject tutorial;
	[SerializeField]
	GameObject[] boardsTutorial;
	[SerializeField]
	GameObject[] imagesTutorial;

	[Header("Celeiro")]
	public Animator[] barnAnims;
	public GameObject ExitBoard;
	public Text statickText;



	Coroutine feedbackCorout;


	int QuestionsAmount { get { return questions.Length; } }
	QuestionData CurrentQuestion { get { return shuffledQuestions [questionIndex]; } } 

	void Start () 
	{

		idTema = PlayerPrefs.GetInt ("idTema");

		source = GetComponent<AudioSource> ();
		questionIndex = 0;
		infoTutorial.text = txtTutorial [indexTutorial];
		boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
		imagesTutorial [0].SetActive (false);imagesTutorial [1].SetActive (false);
		tutorial.SetActive (true);
		infoResposta.text = string.Format ("Respondendo {0} de {1} perguntas ", questionIndex + 1, QuestionsAmount);
		
	}

	public void ChangeTextTutorialForward(){
		indexTutorial++;
		infoTutorial.text = txtTutorial [indexTutorial];

		if (indexTutorial >= 1){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);
		}

		if (indexTutorial >= 2) {
			boardsTutorial [0].SetActive (false);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);imagesTutorial [1].SetActive (true);
		}
	}

	public void ChangeTextTutorialBack(){
		indexTutorial--;
		infoTutorial.text = txtTutorial [indexTutorial];

		if (indexTutorial == 0){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (false);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (false);imagesTutorial [1].SetActive (false);
		}

		if (indexTutorial == 1){
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (false);
			imagesTutorial [0].SetActive (true);imagesTutorial [1].SetActive (false);
		}

		if (indexTutorial == 2) {
			boardsTutorial [0].SetActive (true);boardsTutorial [1].SetActive (true);boardsTutorial [2].SetActive (true);
			imagesTutorial [0].SetActive (false);imagesTutorial [1].SetActive (true);
		}
	}
		
	public void StartGame(){
		tutorial.SetActive (false);
		SetShuffledQuestions ();
		UpdateQuestionOutput ();
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
		
		for (int t = 0; t < answerTexts.Length; t++ )
        {
            string tmp = answerTexts[t].text;
            int r = Random.Range(t, question.answers.Length);
            answerTexts[t].text = answerTexts[r].text;
            answerTexts[r].text = tmp;
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

		if (answerTexts [index].text == CurrentQuestion.correctAnswer) {
			acertos++;
			source.PlayOneShot (C_Answer, 1);
		} else {
			source.PlayOneShot(W_Answer, 1);
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
//			media = 10 * (acertos / QuestionsAmount);
//			notaFinal = Mathf.RoundToInt (media);
			if (acertos == 10)
			{
				notaFinal = 20;
			} 
			else if (acertos == 9)
			{
				notaFinal = 10;
			}
			else if (acertos == 7)
			{
				notaFinal = 7;
			}
			else if (acertos == 4)
			{
				notaFinal = 5;
			}
			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
//			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int) acertos);
//			Score.infoValue = string.Format ("Você acertou {0} questões de {1}, sua nota final é {2}!", acertos, QuestionsAmount, notaFinal);
			BarnAnin ();
			StartCoroutine ("StartScore");
		}

	}

	public IEnumerator StartScore(){
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene("Score");
	}

	public void BarnAnin(){
		for (int i = 0; i < barnAnims.Length; i++) {
			barnAnims [i].SetBool ("Active", true);
		}
		ExitBoard.SetActive (false);
		for (int i = 0; i < answerButtons.Length ; i++) {
			answerButtons [i].gameObject.SetActive (false);
		}
		statickText.text = "";
		infoResposta.text = "";
	}


	public void Comecar()
	{
		tutorial.SetActive (false);
	}

	IEnumerator PromptAnswer_Routine(int index)
	{
			
		for (int i = 0; i < answerButtons.Length; i++) 
		{
			if (answerTexts [i].text == CurrentQuestion.correctAnswer) {
				answerButtons [i].image.color = correctColor;
			}
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
