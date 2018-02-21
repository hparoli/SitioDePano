using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardMed : MonoBehaviour {

	public static bool DO_NOT = false;

	public AudioClip shuffleCards;
	private AudioSource source;

	[SerializeField]
	private int _state;
	[SerializeField]
	private int _cardvalue;
	[SerializeField]
	private bool _initialized = false;

	private Sprite _cardBack;
	private Sprite _cardFace;

	private GameObject _Manager;

	void Start(){
		_state = 0;
		_Manager = GameObject.FindGameObjectWithTag ("Manager");
		source = GetComponent<AudioSource> ();
	}


	public void SetupGraphics() {
		_cardBack = _Manager.GetComponent<GameManagerMed> ().getCardBack ();
		_cardFace = _Manager.GetComponent<GameManagerMed> ().getCardFace(_cardvalue);

	}

	public void flipCard() {

		if (_state == 0) {
			_state = 1;
			source.PlayOneShot (shuffleCards, 1);
		} else if (_state == 1) {
			_state = 0;
			source.PlayOneShot (shuffleCards, 1);
		}
		if (_state == 0 && !DO_NOT) {
			source.PlayOneShot (shuffleCards, 1);
			GetComponent<Image> ().sprite = _cardBack;
		} else if (_state == 1 && !DO_NOT) {
			source.PlayOneShot (shuffleCards, 1);
			GetComponent<Image> ().sprite = _cardFace;
		}
	}

	public int cardValue {
		get { return _cardvalue; }
		set { _cardvalue = value; }
	}

	public int state {
		get { return _state; }
		set { _state = value;}

	}

	public bool initialized {
		get { return _initialized; }
		set { _initialized = value; }
	}

	public void falseCheck(){
		StartCoroutine (pause ());
	}

	IEnumerator pause(){
		yield return new WaitForSeconds (1);
		if (_state == 0)
			GetComponent<Image> ().sprite = _cardBack;
		else if (_state == 1)
			GetComponent<Image> ().sprite = _cardFace;
		DO_NOT = false;
	}

}
