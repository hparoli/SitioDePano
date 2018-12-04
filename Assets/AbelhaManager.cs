using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbelhaManager : MonoBehaviour 
{

	[SerializeField]
	private int numColunas,numLinhas,level,resp,waypoint,btn, movimentos;

	[SerializeField]
	private GameObject seta,abelha,ab,cm,es,colmeia,estrela;

	[SerializeField]
	public List<GameObject> setas,caminho;

	[SerializeField]
	private Transform pos;

	[SerializeField]
	private Sprite img;

	[SerializeField]
	private float marg;

	[SerializeField]
	private Vector3 tam;

	[SerializeField]
	private Text texto, moviTxt;

	public AudioClip[] sons;
	private AudioSource fonteAudio;

	[SerializeField]
	private Color standard;

	public bool respondeu,fimCaminho,acertouCaminho,destino;
	public bool work,click;

	public float moveSpeed;

	private string[] ladoLvl;

	[Header("DificultControl")]
	[Space(10)]
	[SerializeField]
	GameDificultScripting[] gamedificultScripiting;
	[Space(10)]
	[SerializeField]
	GameObject DificultGameObject;

	[SerializeField]
	Button[] gameButtons;
	int notaFinal;

	[SerializeField]
	GameObject ExitBoard;
	[SerializeField]
	GameObject TutorialPrefab;
	[SerializeField]
	GameObject tutButton;
	bool isgame = false;
	int idTema;
	int gamelevel;

	[Space(10)]
	[Header("Celeiro")]
	public Animator[] barnAnims;

	void Start()
	{
		idTema = PlayerPrefs.GetInt ("idTema");
	    
		respondeu = false;
		waypoint = 0;
		fonteAudio = GetComponent<AudioSource> ();
		click = work = true;
		fimCaminho = false;
		destino = true;
		
	}
	public void OpenTutorial()
	{
		ExitBoard.SetActive(false);
		tutButton.SetActive(false);
		TutorialPrefab.SetActive(true);
		Time.timeScale = 0;
		SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialCaminhos);
		isgame = true;
	}
	public void BarnAnin()
	{
		for (int i = 0; i < barnAnims.Length; i++) 
		{
			barnAnims [i].SetBool ("Active", true);
		}
	}

	void Update()
	{
        OpenLevel();
        StarsPointsControl();

        Comportamento();
		if(!destino){
			ab.GetComponent<CaminhosManager>().Move(caminho);
		}
	}
	public void GameDificultControl(int GameDificultValue)
	{	
		level = gamelevel = GameDificultValue;
		for (int i = 0; i < gamedificultScripiting.Length; i++)
		{
			if(gamedificultScripiting[i].gameValue == GameDificultValue)
			{
				gamedificultScripiting[i].gamePrefabDificult.SetActive(true);

			}
			DificultGameObject.SetActive(false);
			ExitBoard.SetActive(false);
		}
		if (gamelevel == 1)
		{
			SoundManager.instance.Play("Player", SoundManager.instance.clipList.TutorialCaminhos);
		}
		InicializaLevel(level);
		
	}
	public void OpenLevel()
	{
		string dif = PlayerPrefs.GetString("dificuldade" + idTema);
		
		if (dif == "F" ||  dif == "")
		{
			gameButtons[1].interactable = false;
			gameButtons[2].interactable = false;
		}
		else if (dif == "M") 
		{
			gameButtons[2].interactable = false;
		}
	}

	public void StarsPointsControl()
	{
		
		for (int i = 0; i < gamedificultScripiting.Length; i++)
		{
			if(i == 0)
			{

				notaFinal = PlayerPrefs.GetInt ("piqueFacil" + idTema.ToString ());
			}
			else if(i == 1)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueMedio" + idTema.ToString ());
			}

			else if (i == 2)
			{
				notaFinal = PlayerPrefs.GetInt ("piqueDificil" + idTema.ToString ());
			}
			
			for (int j = 0; j < gamedificultScripiting[i].stars.Length; j++)
			{
 				if ((notaFinal == 0 || notaFinal == null) || ( notaFinal == 5 && j > 0 ) || ( notaFinal == 7 && j > 1 ) || ( notaFinal == 10 && j > 2 ) || ( notaFinal == 20 && j > 3 ) ) 				{
					break;
				}
				gamedificultScripiting[i].stars[j].SetActive(true);
			}
		}
	}

	public void StartGameButton()
	{
		if (!isgame)
		{
			ExitBoard.SetActive(true);
			tutButton.SetActive(true);
			Time.timeScale = 1;
			TutorialPrefab.SetActive(false);
			SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialCaminhos);
		}
		else
		{
			ExitBoard.SetActive(true);
			tutButton.SetActive(true);
			Time.timeScale = 1;
			TutorialPrefab.SetActive(false);
			SoundManager.instance.Stop("Player", SoundManager.instance.clipList.TutorialCaminhos);
		}
		
	}

	private void InicializaLevel(int lvl){
		if (lvl == 1){
			numColunas = 4;
			numLinhas = 2;
			marg = 1.7f;
			movimentos = 4;
			ladoLvl = new string[] {"left","left","down","right","down","down","right","left"};
		}
		else if (lvl == 2){
			numColunas = 4;
			numLinhas = 3;
			marg = 1.7f;
			movimentos = 5;
			ladoLvl = new string[] {"left","down","right","up","down","right","down","left","right","up","left","left"};
		}
		else if (lvl == 3){
			numColunas = 5;
			numLinhas = 3;
			marg = 1.7f;
			movimentos = 7;
			ladoLvl = new string[] {"up","right","up","right","right","left","up","up","right","up","down","right","left","down","up"};
		}
	

		int index = 0;
		for (int i = 0; i < numLinhas; i++)
		{
			for (int j = 0; j < numColunas; j++)
			{
				setas.Add(GameObject.Instantiate(seta, new Vector3(pos.position.x + (numColunas/2) - (j*marg)
				                                                 , pos.position.y + (numLinhas/2) - (i*marg)
																 , pos.position.z) ,pos.rotation));
				setas[index].GetComponent<SetaBehavior>().x = j;
				setas[index].GetComponent<SetaBehavior>().y = i;
				setas[index].GetComponent<SetaBehavior>().tipoSeta = "flor";
				setas[index].gameObject.name = i+""+j;
				index++;
			}
		}
		OrganizaSetas(lvl);
		Debug.Log(index);
	}

	private void OrganizaSetas(int lvl){
		
		for(int i = 0; i < setas.Count; i++){
				if(ladoLvl[i] == "up"){
					setas[i].transform.eulerAngles = new Vector3(0,0,90);
				} else if (ladoLvl[i] == "down"){
					setas[i].transform.eulerAngles = new Vector3(0,0,270);
				} else if (ladoLvl[i] == "right"){
					setas[i].transform.eulerAngles = new Vector3(0,0,0);
				} else if (ladoLvl[i] == "left"){
					setas[i].transform.eulerAngles = new Vector3(0,0,180);
				}
				setas[i].GetComponent<SetaBehavior>().lado = ladoLvl[i];
			}
		
		if (lvl == 1){
			Vector3 pos1;
			pos1 = setas[4].transform.position;
			ab = GameObject.Instantiate(abelha, new Vector3(pos1.x + marg
				                                                 , pos1.y
																 , pos1.z) ,Quaternion.EulerAngles(0,0,0));
			
			Vector3 pos2;
			pos2 = setas[3].transform.position;
			es = GameObject.Instantiate(estrela, new Vector3(pos2.x  - 0.25f
				                                                 , pos2.y + 0.25f
																 , pos2.z) ,Quaternion.EulerAngles(0,0,0));

			Vector3 pos3;
			pos3 = setas[7].transform.position;
			cm = GameObject.Instantiate(colmeia, new Vector3(pos3.x  - marg
				                                                 , pos3.y
																 , pos3.z) ,Quaternion.EulerAngles(0,0,0));
			cm.GetComponent<SetaBehavior>().tipoSeta = "colmeia";
			cm.GetComponent<SetaBehavior>().x = setas[7].GetComponent<SetaBehavior>().x+1;
			cm.GetComponent<SetaBehavior>().y = setas[7].GetComponent<SetaBehavior>().y;
			cm.name = cm.GetComponent<SetaBehavior>().y+""+cm.GetComponent<SetaBehavior>().x;

		}
		else if (lvl == 2){
			Vector3 pos1 = setas[4].transform.position;
			ab = GameObject.Instantiate(abelha, new Vector3(pos1.x + marg
				                                                 , pos1.y
																 , pos1.z) ,Quaternion.EulerAngles(0,0,0));
			
			setas[5].GetComponent<SetaBehavior>().tipoSeta = "barreira";
			setas[5].GetComponent<SpriteRenderer>().sprite = img;
			setas[5].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			
			Vector3 pos2 = setas[7].transform.position;
			
			cm = GameObject.Instantiate(colmeia, new Vector3(pos2.x  - marg
				                                                 , pos2.y
																 , pos2.z) ,Quaternion.EulerAngles(0,0,0));
			cm.GetComponent<SetaBehavior>().tipoSeta = "colmeia";
			cm.GetComponent<SetaBehavior>().x = setas[7].GetComponent<SetaBehavior>().x+1;
			cm.GetComponent<SetaBehavior>().y = setas[7].GetComponent<SetaBehavior>().y;
			cm.name = cm.GetComponent<SetaBehavior>().y+""+cm.GetComponent<SetaBehavior>().x;
			
			Vector3 pos3 = setas[11].transform.position;
			es = GameObject.Instantiate(estrela, new Vector3(pos3.x  - 0.25f
				                                                 , pos3.y + 0.25f 
																 , pos3.z) ,Quaternion.EulerAngles(0,0,0));
																 
		}
		else if (lvl == 3){
			Vector3 pos1 = setas[4].transform.position;
			es = GameObject.Instantiate(estrela, new Vector3(pos1.x  - 0.25f
				                                                 , pos1.y + 0.25f
																 , pos1.z) ,Quaternion.EulerAngles(0,0,0));
			
			Vector3 pos2 = setas[5].transform.position;
			ab = GameObject.Instantiate(abelha, new Vector3(pos2.x + marg
				                                                 , pos2.y
																 , pos2.z) ,Quaternion.EulerAngles(0,0,0));

			Vector3 pos3 = setas[8].transform.position;
			cm = GameObject.Instantiate(colmeia, new Vector3(pos3.x
				                                      , pos3.y
													  , pos3.z) ,Quaternion.EulerAngles(0,0,0));
			cm.GetComponent<SetaBehavior>().tipoSeta = "colmeia";
			setas[8].GetComponent<SetaBehavior>().tipoSeta = "colmeia";
			setas[8].name = "colmeia";
			cm.GetComponent<SetaBehavior>().x = setas[8].GetComponent<SetaBehavior>().x;
			cm.GetComponent<SetaBehavior>().y = setas[8].GetComponent<SetaBehavior>().y;
			cm.name = cm.GetComponent<SetaBehavior>().y+""+cm.GetComponent<SetaBehavior>().x;
			setas[8].GetComponent<SpriteRenderer>().sprite = null;
			setas[8].GetComponentsInChildren<SpriteRenderer>()[1].sprite = null;
			setas[8].GetComponent<BoxCollider>().enabled = false;

		}
		moviTxt.text = string.Format("{0}",movimentos);
	}

	public void Responde(){
		if(!respondeu){
			respondeu = true;
			if(level == 1 || level == 2){
				caminho.Add(setas[4]);
			} else if(level == 3) {
				caminho.Add(setas[5]);
			}
			int idx = 0;
			string tipo;
			while(!fimCaminho){
				Debug.Log(caminho[idx].GetComponent<SetaBehavior>().lado);
				Debug.Log("Ultima Posição: " + caminho[idx].name + " posicao: " + idx);
				tipo = caminho[idx].GetComponent<SetaBehavior>().tipoSeta;
				if(tipo == "flor"){
					if(caminho[idx].GetComponent<SetaBehavior>().lado == "up"){
						if(caminho[idx].GetComponent<SetaBehavior>().y == 0){
							fimCaminho = true;
						} else{
							caminho.Add(GameObject.Find((caminho[idx].GetComponent<SetaBehavior>().y-1)+
														""+caminho[idx].GetComponent<SetaBehavior>().x));
							idx++;
							for (int i = 0; i < caminho.Count-1; i++)
							{
								if(caminho[i] == caminho[idx]){
									fimCaminho = true;
									break;
								}
							}
						}
					} else if(caminho[idx].GetComponent<SetaBehavior>().lado == "down"){
						if(caminho[idx].GetComponent<SetaBehavior>().y == numLinhas-1){
							fimCaminho = true;
						} else{
							caminho.Add(GameObject.Find((caminho[idx].GetComponent<SetaBehavior>().y+1)+
														""+caminho[idx].GetComponent<SetaBehavior>().x));
							idx++;
							for (int i = 0; i < caminho.Count-1; i++)
							{
								if(caminho[i] == caminho[idx]){
									fimCaminho = true;
									break;
								}
							}
							
						}
					} else if(caminho[idx].GetComponent<SetaBehavior>().lado == "right"){
						if(caminho[idx].GetComponent<SetaBehavior>().x == 0){
							fimCaminho = true;
						} else{
							caminho.Add(GameObject.Find((caminho[idx].GetComponent<SetaBehavior>().y)+
														""+(caminho[idx].GetComponent<SetaBehavior>().x-1)));
							idx++;
							for (int i = 0; i < caminho.Count-1; i++)
							{
								if(caminho[i] == caminho[idx]){
									fimCaminho = true;
									break;
								}
							}
						}
					} else if(caminho[idx].GetComponent<SetaBehavior>().lado == "left"){
						if(caminho[idx].GetComponent<SetaBehavior>().x == numColunas-1){
							if((level == 1 || level == 2) && caminho[idx].GetComponent<SetaBehavior>().y == 1){
								caminho.Add(GameObject.Find((caminho[idx].GetComponent<SetaBehavior>().y)+
														""+(caminho[idx].GetComponent<SetaBehavior>().x+1)));
								idx++;
							}
							fimCaminho = true;
						} else{
							caminho.Add(GameObject.Find((caminho[idx].GetComponent<SetaBehavior>().y)+
														""+(caminho[idx].GetComponent<SetaBehavior>().x+1)));
							idx++;
							for (int i = 0; i < caminho.Count-1; i++)
							{
								if(caminho[i] == caminho[idx]){
									fimCaminho = true;
									break;
								}
							}
						}
					}
					
				} else {
					fimCaminho = true;
				}
			} //fim while
			if(caminho[idx].GetComponent<SetaBehavior>().tipoSeta != "colmeia"){
						acertouCaminho = false;
					} else {
						acertouCaminho = true;
					}
			
			if(acertouCaminho){
				texto.text = "Parabéns! Você acertou!";
				//fonteAudio.PlayOneShot(sons[0]);
			} 
			else{
				texto.text = "Que pena, você errou!";
				//fonteAudio.PlayOneShot(sons[1]);
			}
		}
		//som de click do botão
		destino = false;
	}


	

	public IEnumerator FeedBack(){

		yield return new WaitForSeconds(0.5f);
		for (float f = 0f; f <= standard.a; f += 0.01f)
		{
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.2f);
			yield return null;
		}
		yield return new WaitForSeconds(.5f);
		for (float f = 1f; f >= 0; f -= 0.01f)
		{
			Color c = texto.color;
			c.a = f;
			texto.color = c;
			new WaitForSeconds(.2f);
			yield return null;
		}
		if(/*level == 1 || level == 3 || level == 5 || level == 7*/level < 3){
			level++;
			Clear();
			InicializaLevel(level);
		} 
		else{
			BarnAnin();
			new WaitForSeconds(.2f);
			GameOver();
		} 
	}

	public void Clear(){
		for (int i = 0; i < setas.Count; i++)
		{
			Destroy(setas[i]);
		}
		Destroy(ab);
		Destroy(cm);
		Destroy(es);
		setas.Clear();
		caminho.Clear();
		fimCaminho = false;
		click = true;
		destino = true;
	}

	public void GameOver()
	{
		//SceneManager.LoadScene("Score");
		LoadingScreenManager.LoadScene(10);
	}

	void Comportamento(){
		if(work)
		{
			RaycastHit setaClick = new RaycastHit();
			bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out setaClick);
			if (Input.GetMouseButtonDown (0)) {
				Debug.Log("clicou");
				if (hit) {
					if(setaClick.transform.gameObject.GetComponent<SetaBehavior>().tipoSeta == "flor"){
						if(click){
							click = false;
							Debug.Log("acertou");
							if(movimentos > 0){
								movimentos--;
								moviTxt.text = string.Format("{0}",movimentos); 
								
								if(movimentos == 0){
									moviTxt.color = Color.red;
								}
								for (int i = 0; i < setas.Count; i++)
								{
									if(setas[i].transform.gameObject.name == setaClick.transform.gameObject.name){
											
												StartCoroutine(setas[i].GetComponent<SetaBehavior>().Rotate());
												Debug.Log("girou");
									}
								}
							}
						}
					}
				
				}
			}
			
		}
	}
}
