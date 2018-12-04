using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class AcertaSequenciaController : MonoBehaviour
{

    private int idTema, acerto;

    //[SerializeField]
    //private AllBolosData gameData;


    //private DataController dataController;

    //TrilhaSonora
    public AudioSource audio;

    [SerializeField]
    private Formas[] formas;

    [SerializeField]
    private GameObject[] formasPergunta, formasResposta, formasEscolha;

    [SerializeField]
    private GameObject forma, destaque;

    [SerializeField]
    private Transform pos, posR;

    [SerializeField]
    private int level, ind, qtdFormas, tipos, qtdExtra;

    [SerializeField]
    private Color standard;

    [SerializeField]
    private Text Txt;

    [SerializeField]
    private Button btn;

    [SerializeField]
    private SpriteRenderer bolo;

    [SerializeField]
    private Sprite[] bolosBons, bolosRuins;

    public AudioClip[] sons;
    private AudioSource fonteAudio;

    [Header("DificultControl")]
    [Space(10)]
    [SerializeField]
    GameDificultScripting[] gamedificultScripiting;
    [Space(10)]
    [SerializeField]
    GameObject DificultGameObject;

    [SerializeField]
    Button[] gameButtons;

    int gamelevel;
    int notaFinal;

    private float tempo;

    [SerializeField]
    GameObject ExitBoard;
    [SerializeField]
    GameObject ExitBoard2;
    [SerializeField]
    GameObject TutorialPrefab;
    [SerializeField]
    GameObject tutButton;
    bool isgame = false;


    [Space(10)]
    [Header("Celeiro")]
    public Animator[] barnAnims;

    [Header("Feedback Aninha")]
    public Animator aninha;


    void Start()
    {
        /*
		dataController = GameObject.Find("DataController").GetComponent<DataController>();
		gameData.bolosDatas = dataController.GetBolosData();
		gameData.notaFacil = dataController.GetBoloFacil();
		gameData.notaMedio = dataController.GetBoloMedio();
		gameData.notaDificil = dataController.GetBoloDificil();*/

        idTema = PlayerPrefs.GetInt("idTema");

        acerto = 0;
        tempo = 0;
        audio.Pause();

        ind = 1;
        fonteAudio = GetComponent<AudioSource>();
    }
    public void OpenTutorial()
    {
        ExitBoard.SetActive(false);
        tutButton.SetActive(false);
        TutorialPrefab.SetActive(true);
        Time.timeScale = 0;
        SoundManager.instance.Play("Player", SoundManager.instance.clipList.speekBolos);
        isgame = true;
    }
    public void BarnAnin()
    {
        for (int i = 0; i < barnAnims.Length; i++)
        {
            barnAnims[i].SetBool("Active", true);
        }
    }

    void Update()
    {
        EscolherForma();
        Cronometro();
        OpenLevel();
        StarsPointsControl();
    }
    public void GameDificultControl(int GameDificultValue)
    {
        gamelevel = GameDificultValue;

        for (int i = 0; i < gamedificultScripiting.Length; i++)
        {
            if (gamedificultScripiting[i].gameValue == GameDificultValue)
            {
                gamedificultScripiting[i].gamePrefabDificult.SetActive(true);

            }

            DificultGameObject.SetActive(false);
            ExitBoard.SetActive(false);
            ExitBoard2.SetActive(false);
            tutButton.SetActive(false);
        }
        if (gamelevel == 0)
        {
            SoundManager.instance.Play("Player", SoundManager.instance.clipList.speekBolos);

            level = 0;
        }
        else if (gamelevel == 1)
        {

            level = 3;
        }
        else if (gamelevel == 2)
        {
            level = 6;
        }

        Debug.Log(level);
    }
    public void OpenLevel()
    {
        string dif = PlayerPrefs.GetString("dificuldade" + idTema);

        if (dif == "F" || dif == "")
        {
            gameButtons[1].interactable = false;
            gameButtons[2].interactable = false;
        }
        else if (dif == "M")
        {
            gameButtons[2].interactable = false;
        }
        /* bool hasF = false;
		bool hasM = false;
		for (int i = 0; i < gameData.bolosDatas.Count; i++)
		{
			if(gameData.bolosDatas[i].level == "F") {
				hasF = true;
			}
			if(gameData.bolosDatas[i].level == "M"){
				hasM = true;
			}
		}
		
		if (!hasF)
		{
			gameButtons[1].interactable = false;
			gameButtons[2].interactable = false;
		}
		
		if (!hasM) 
		{
			gameButtons[2].interactable = false;
		}*/
    }

    public void StarsPointsControl()
    {

        for (int i = 0; i < gamedificultScripiting.Length; i++)
        {
            if (i == 0)
            {

                notaFinal = PlayerPrefs.GetInt("piqueFacil" + idTema.ToString());//gameData.notaFacil;
            }
            else if (i == 1)
            {
                notaFinal = PlayerPrefs.GetInt("piqueMedio" + idTema.ToString());//gameData.notaMedio;
            }

            else if (i == 2)
            {
                notaFinal = PlayerPrefs.GetInt("piqueDificil" + idTema.ToString());//gameData.notaDificil;
            }

            for (int j = 0; j < gamedificultScripiting[i].stars.Length; j++)
            {
                if ((notaFinal == 0 || notaFinal == null) || (notaFinal == 5 && j > 0) || (notaFinal == 7 && j > 1) || (notaFinal == 10 && j > 2) || (notaFinal == 20 && j > 3))
                {
                    break;
                }
                gamedificultScripiting[i].stars[j].SetActive(true);
            }
        }
    }
    public void StartGame()
    {
        if (level == 0)
        {
            SoundManager.instance.Stop("Player", SoundManager.instance.clipList.speekBolos);
            qtdFormas = 3;
            tipos = 3;
        }
        else if (level == 1)
        {
            qtdFormas = 4;
            tipos = 3;
        }
        else if (level == 2)
        {
            qtdFormas = 4;
            tipos = 4;
        }
        else if (level == 3)
        {
            qtdFormas = 5;
            tipos = 4;
        }
        else if (level == 4)
        {
            qtdFormas = 5;
            tipos = 4;
            qtdExtra = 2;
        }
        else if (level == 5)
        {
            qtdFormas = 6;
            tipos = 4;
            qtdExtra = 2;
        }
        else if (level == 6)
        {
            qtdFormas = 6;
            tipos = 4;
            qtdExtra = 3;
        }
        else if (level == 7)
        {
            qtdFormas = 6;
            tipos = 4;
            qtdExtra = 3;
        }
        else if (level == 8)
        {
            qtdFormas = 6;
            tipos = 4;
            qtdExtra = 4;
        }
        formasPergunta = new GameObject[qtdFormas];
        formasResposta = new GameObject[qtdFormas];
        btn.gameObject.SetActive(false);
        if (!isgame)
        {
            ExitBoard.SetActive(true);
            tutButton.SetActive(true);
            TutorialPrefab.SetActive(false);
            Time.timeScale = 1;
            StartCoroutine("MostraSequencia");
            audio.Play();
        }
        else
        {
            ExitBoard.SetActive(true);
            tutButton.SetActive(true);
            TutorialPrefab.SetActive(false);
            Time.timeScale = 1;

            SoundManager.instance.Stop("Player", SoundManager.instance.clipList.speekBolos);
        }

    }

    private IEnumerator MostraSequencia()
    {
        Txt.text = "Memorize a Sequência";
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        int index = -1;
        for (int i = 0; i < qtdFormas; i++)
        {
            formasPergunta[i] = GameObject.Instantiate(forma, new Vector3(pos.position.x - qtdFormas + (i * 2), pos.position.y, pos.position.z), pos.rotation);
            formasResposta[i] = GameObject.Instantiate(forma, new Vector3(pos.position.x - qtdFormas + (i * 2), pos.position.y, pos.position.z), pos.rotation);
            if (index < 0) index = UnityEngine.Random.Range(0, tipos);
            formasPergunta[i].GetComponent<SpriteRenderer>().sprite = formas[index].imagem;
            formasPergunta[i].GetComponent<FormasInfos>().SetValues(formas[index].forma, i);
            formasResposta[i].GetComponent<FormasInfos>().SetValues("", i);
            if (i < formas.Length - 1)
            {
                if (index < tipos - 1) index++;
                else index = 0;
            }
            else
            {
                index = UnityEngine.Random.Range(0, 4);
            }
            formasPergunta[i].gameObject.tag = "Pergunta";
            formasResposta[i].gameObject.tag = "Resposta";
            GameObject.Instantiate(destaque, formasResposta[i].transform);
        }
        Embaralha("P");
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < formasPergunta.Length; i++)
        {
            formasPergunta[i].GetComponent<SpriteRenderer>().enabled = false;
            formasPergunta[i].transform.position = new Vector3(formasPergunta[i].transform.position.x, formasPergunta[i].transform.position.y - 2, formasPergunta[i].transform.position.z);
        }
        StartCoroutine("Responde");

    }

    private void Embaralha(string param)
    {
        if (param == "P")
        {
            for (int i = 0; i < formasPergunta.Length; i++)
            {
                string tmp = formasPergunta[i].GetComponent<FormasInfos>().GetForma();
                int idx = formasPergunta[i].GetComponent<FormasInfos>().GetIndex();
                Sprite spt = formasPergunta[i].GetComponent<SpriteRenderer>().sprite;
                int r = UnityEngine.Random.Range(0, formasPergunta.Length);
                formasPergunta[i].GetComponent<FormasInfos>().SetValues(formasPergunta[r].GetComponent<FormasInfos>().GetForma(), formasPergunta[r].GetComponent<FormasInfos>().GetIndex());
                formasPergunta[i].GetComponent<SpriteRenderer>().sprite = formasPergunta[r].GetComponent<SpriteRenderer>().sprite;
                formasPergunta[r].GetComponent<FormasInfos>().SetValues(tmp, idx);
                formasPergunta[r].GetComponent<SpriteRenderer>().sprite = spt;
            }
        }

        if (param == "R")
        {
            for (int i = 0; i < formasEscolha.Length; i++)
            {
                string tmp = formasEscolha[i].GetComponent<FormasInfos>().GetForma();
                int idx = formasEscolha[i].GetComponent<FormasInfos>().GetIndex();
                Sprite spt = formasEscolha[i].GetComponent<SpriteRenderer>().sprite;
                int r = UnityEngine.Random.Range(0, formasEscolha.Length);
                formasEscolha[i].GetComponent<FormasInfos>().SetValues(formasEscolha[r].GetComponent<FormasInfos>().GetForma(), formasEscolha[r].GetComponent<FormasInfos>().GetIndex());
                formasEscolha[i].GetComponent<SpriteRenderer>().sprite = formasEscolha[r].GetComponent<SpriteRenderer>().sprite;
                formasEscolha[r].GetComponent<FormasInfos>().SetValues(tmp, idx);
                formasEscolha[r].GetComponent<SpriteRenderer>().sprite = spt;
            }
        }
    }

    private IEnumerator Responde()
    {
        StopCoroutine("GameStart");
        Txt.text = "Coloque os ingredientes na ordem";
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        formasEscolha = new GameObject[formasPergunta.Length + qtdExtra];
        int index = 0;
        for (int i = 0; i < formasPergunta.Length + qtdExtra; i++)
        {
            if (i < 5)
                formasEscolha[i] = GameObject.Instantiate(forma, new Vector3(posR.position.x, posR.position.y - (i * 2f), posR.position.z), posR.rotation);
            else
                formasEscolha[i] = GameObject.Instantiate(forma, new Vector3(posR.position.x + 1.8f, posR.position.y - ((i - 5) * 2), posR.position.z), posR.rotation);
            if (i < formasPergunta.Length)
            {
                formasEscolha[i].GetComponent<SpriteRenderer>().sprite = formasPergunta[i].GetComponent<SpriteRenderer>().sprite;
                formasEscolha[i].GetComponent<FormasInfos>().SetValues(formasPergunta[i].GetComponent<FormasInfos>().GetForma(), i);
            }
            else
            {
                index = UnityEngine.Random.Range(0, tipos);
                formasEscolha[i].GetComponent<SpriteRenderer>().sprite = formas[index].imagem;
                formasEscolha[i].GetComponent<FormasInfos>().SetValues(formas[index].forma, i);
            }
            formasEscolha[i].gameObject.tag = "Escolha";
            GameObject.Instantiate(destaque, formasEscolha[i].transform);
        }
        btn.gameObject.SetActive(true);
        Embaralha("R");
    }

    void EscolherForma()
    {
        RaycastHit formaClick = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out formaClick);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit)
            {
                //som de click no ingrediente
                if (formaClick.transform.tag == "Escolha")
                {
                    for (int i = 0; i < formasEscolha.Length; i++)
                    {
                        if (formaClick.transform.gameObject.GetComponent<FormasInfos>().GetIndex()
                           == formasEscolha[i].GetComponent<FormasInfos>().GetIndex())
                        {
                            for (int j = 0; j < formasResposta.Length; j++)
                            {
                                if (formasResposta[j].GetComponent<FormasInfos>().GetForma() == "")
                                {
                                    formasResposta[j].GetComponent<FormasInfos>().SetValues(formasEscolha[i].GetComponent<FormasInfos>().GetForma()
                                    , formasResposta[j].GetComponent<FormasInfos>().GetIndex());
                                    formasResposta[j].GetComponent<SpriteRenderer>().sprite = formasEscolha[i].GetComponent<SpriteRenderer>().sprite;
                                    formasEscolha[i].GetComponent<FormasInfos>().SetValues("", formasEscolha[i].GetComponent<FormasInfos>().GetIndex());
                                    formasEscolha[i].GetComponent<SpriteRenderer>().sprite = null;
                                    break;
                                }

                            }

                        }
                    }
                }
                if (formaClick.transform.tag == "Resposta")
                {
                    for (int i = 0; i < formasResposta.Length; i++)
                    {
                        if (formaClick.transform.gameObject.GetComponent<FormasInfos>().GetIndex()
                           == formasResposta[i].GetComponent<FormasInfos>().GetIndex())
                        {
                            for (int j = 0; j < formasEscolha.Length; j++)
                            {
                                if (formasEscolha[j].GetComponent<FormasInfos>().GetForma() == "")
                                {
                                    formasEscolha[j].GetComponent<FormasInfos>().SetValues(formasResposta[i].GetComponent<FormasInfos>().GetForma()
                                    , formasEscolha[j].GetComponent<FormasInfos>().GetIndex());
                                    formasEscolha[j].GetComponent<SpriteRenderer>().sprite = formasResposta[i].GetComponent<SpriteRenderer>().sprite;
                                    formasResposta[i].GetComponent<FormasInfos>().SetValues("", formasResposta[i].GetComponent<FormasInfos>().GetIndex());
                                    formasResposta[i].GetComponent<SpriteRenderer>().sprite = null;
                                    break;
                                }

                            }
                        }
                    }
                }
            }
        }
    }

    public IEnumerator C_Compara()
    {
        int count = 0;
        //som de click no botão
        for (int i = 0; i < formasPergunta.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            formasPergunta[i].GetComponent<SpriteRenderer>().enabled = true;
            if (formasPergunta[i].GetComponent<FormasInfos>().GetForma() == formasResposta[i].GetComponent<FormasInfos>().GetForma())
            {
                count++;
            }
        }
        yield return new WaitForSeconds(1f);
        if (count == formasPergunta.Length)
        {
            Txt.text = "Parabéns! Você acertou!";
            aninha.SetTrigger("Palma");
            acerto++;
            bolo.sprite = bolosBons[level];
            //acerto
            fonteAudio.PlayOneShot(sons[0]);
        }
        else
        {
            Txt.text = "Ahh... que pena";
            aninha.SetTrigger("Triste");
            bolo.sprite = bolosRuins[level];
            //bolosData.erros++;
            //erro
            fonteAudio.PlayOneShot(sons[1]);
        }
        yield return new WaitForSeconds(0.5f);
        Clear();
        bolo.enabled = true;
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        /*if(count == formasPergunta.Length){
			if(ind == 1) {*/
        yield return new WaitForSeconds(.5f);
        bolo.enabled = false;

        if (gamelevel == 0)
        {
            if (level < 2)
            {
                Txt.text = "Vamos para a próxima receita!";
            }
            else
            {
                Txt.text = "Parabéns! Você completou o nível.";
            }
        }
        else if (gamelevel == 1)
        {
            if (level < 5)
            {
                Txt.text = "Vamos para a próxima receita!";
            }
            else
            {
                Txt.text = "Parabéns! Você completou o nível.";
            }
        }
        else if (gamelevel == 2)
        {
            if (level < 8)
            {
                Txt.text = "Vamos para a próxima receita!";
            }
            else
            {
                Txt.text = "Parabéns! Você completou o nível.";
            }
        }
        yield return new WaitForSeconds(0.2f);
        for (float f = 0f; f <= standard.a; f += 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        yield return new WaitForSeconds(.5f);
        for (float f = 1f; f >= 0; f -= 0.01f)
        {
            Color c = Txt.color;
            c.a = f;
            Txt.color = c;
            new WaitForSeconds(.2f);
            yield return null;
        }
        /*if(ind == 1) {
            ind++;*/
        if (gamelevel == 0)
        {
            if (level < 2)
            {
                level++;
                yield return new WaitForSeconds(2f);
                StartGame();
                StopCoroutine("C_Compara");
            }
            else // Escrever Sistema de Score aqui !! 
            {
                BarnAnin();
                if (acerto == 3)
                {
                    notaFinal = 20;
                }
                else if (acerto == 2)
                {
                    notaFinal = 10;
                }
                else if (acerto == 1)
                {
                    notaFinal = 7;
                }
                else if (acerto == 0)
                {
                    notaFinal = 5;
                }
                PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
                if (notaFinal > PlayerPrefs.GetInt("piqueFacil" + idTema.ToString()))
                {
                    PlayerPrefs.SetInt("piqueFacil" + idTema.ToString(), notaFinal);
                }
                if (PlayerPrefs.GetString("dificuldade" + idTema) == "F" || PlayerPrefs.GetString("dificuldade" + idTema) == "")
                {
                    PlayerPrefs.SetString("dificuldade" + idTema, "M");
                }
                yield return new WaitForSeconds(2f);
                LoadingScreenManager.LoadScene(10);
            }
        }
        else if (gamelevel == 1)
        {
            if (level < 5)
            {
                level++;
                yield return new WaitForSeconds(2f);
                StartGame();
                StopCoroutine("C_Compara");
            }
            else // Escrever Sistema de Score aqui !! 
            {
                BarnAnin();
                if (acerto == 3)
                {
                    notaFinal = 20;
                }
                else if (acerto == 2)
                {
                    notaFinal = 10;
                }
                else if (acerto == 1)
                {
                    notaFinal = 7;
                }
                else if (acerto == 0)
                {
                    notaFinal = 5;
                }
                if (notaFinal > PlayerPrefs.GetInt("piqueMedio" + idTema.ToString()))
                {
                    PlayerPrefs.SetInt("piqueMedio" + idTema.ToString(), notaFinal);
                }

                if (PlayerPrefs.GetString("dificuldade" + idTema) == "M")
                {
                    PlayerPrefs.SetString("dificuldade" + idTema, "D");
                }
                PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);

                yield return new WaitForSeconds(2f);
                LoadingScreenManager.LoadScene(10);
            }
        }
        else if (gamelevel == 2)
        {
            if (level < 8)
            {
                level++;
                yield return new WaitForSeconds(2f);
                StartGame();
                StopCoroutine("C_Compara");
            }
            else // Escrever Sistema de Score aqui !! 
            {
                BarnAnin();
                if (acerto == 3)
                {
                    notaFinal = 20;
                }
                else if (acerto == 2)
                {
                    notaFinal = 10;
                }
                else if (acerto == 1)
                {
                    notaFinal = 7;
                }
                else if (acerto == 0)
                {
                    notaFinal = 5;
                }
                if (notaFinal > PlayerPrefs.GetInt("piqueDificil" + idTema.ToString()))
                {
                    PlayerPrefs.SetInt("piqueDificil" + idTema.ToString(), notaFinal);
                }
                PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);

                yield return new WaitForSeconds(2f);
                LoadingScreenManager.LoadScene(10);
            }
        }

    }

    public void Compara()
    {
        StartCoroutine("C_Compara");
        btn.gameObject.SetActive(false);
    }

    private void Clear()
    {
        for (int i = 0; i < formasPergunta.Length; i++)
        {
            Destroy(formasPergunta[i]);
            Destroy(formasResposta[i]);
        }
        for (int i = 0; i < formasEscolha.Length; i++)
        {
            Destroy(formasEscolha[i]);
        }
        Array.Clear(formasPergunta, 0, formasPergunta.Length);
        Array.Clear(formasResposta, 0, formasResposta.Length);
        Array.Clear(formasEscolha, 0, formasEscolha.Length);
    }

    void Cronometro()
    {
        tempo += 1 * Time.deltaTime;
    }
}