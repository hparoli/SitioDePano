using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataController : MonoBehaviour {

	
	private AllAlimentosData alimentosDatas;
	private AllBolosData bolosDatas;
	private AllCaminhosData caminhosDatas;
	private AllColetandoOvosData coletandoOvosDatas;
	private AllContandoBixosData contandoBixosDatas;
	private AllDitadosData ditadosDatas;
	private AllHortaData hortaDatas;
	private AllMemoriaData memoriaDatas;
	private AllOlhoNoLoboData olhoNoLoboDatas;
	private AllPastoreiraData pastoreiraDatas;
	private AllPiqueData piqueDatas;
	private AllSequenciaSonoraData sequenciaSonoraDatas;
	

	private string gameDataAlimentos = "/StreamingAssets/alimentosSave.json";
	private string gameDataPique = "/StreamingAssets/piqueSave.json";
	private string gameDataHorta = "/StreamingAssets/hortaSave.json";
	private string gameDataOlhoNosLobos = "/StreamingAssets/olhoNoLoboSave.json";
	private string gameDataMemoria = "/StreamingAssets/memoriaSave.json";
	private string gameDataBolos = "/StreamingAssets/bolosSave.json";
	private string gameDataPastoreira = "/StreamingAssets/pastoreiraSave.json";
	private string gameDataContandoBixos = "/StreamingAssets/contandoBixosSave.json";
	private string gameDataColetandoOvos = "/StreamingAssets/coletandoOvosSave.json";
	private string gameDataCaminhos = "/StreamingAssets/caminhosSave.json";
	private string gameDataSequenciaSonora = "/StreamingAssets/sequenciaSonoraSave.json";
	private string gameDataDitados = "/StreamingAssets/ditadosSave.json";


	// Use this for initialization
	void Start ()
	 {
		DontDestroyOnLoad(gameObject);
		alimentosDatas = new AllAlimentosData();
		bolosDatas = new AllBolosData();
		caminhosDatas = new AllCaminhosData();
		coletandoOvosDatas = new AllColetandoOvosData();
		contandoBixosDatas = new AllContandoBixosData();
		ditadosDatas = new AllDitadosData();
		hortaDatas = new AllHortaData();
		memoriaDatas = new AllMemoriaData();
		olhoNoLoboDatas = new AllOlhoNoLoboData();
		pastoreiraDatas = new AllPastoreiraData();
		piqueDatas = new AllPiqueData();
		sequenciaSonoraDatas = new AllSequenciaSonoraData();


		LoadAlimentosData();
	}
	
	#region Jogo dos Alimentos	
	private void LoadAlimentosData(){
		string filePath = Application.dataPath + gameDataAlimentos;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllAlimentosData loadedData = (JsonUtility.FromJson<AllAlimentosData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) alimentosDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save dos alimentos");
		}
	}


	private void SaveAlimentosData(){
		string dataAsJson = JsonUtility.ToJson(alimentosDatas);
		string filePath = Application.dataPath + gameDataAlimentos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}

	public void SetAlimentosData(AlimentosData alimentosData){
		alimentosDatas.alimentosDatas.Add(alimentosData);
		SaveAlimentosData();
	}

	public List<AlimentosData> GetAlimentosDatas(){
		LoadAlimentosData();
		return alimentosDatas.alimentosDatas;		
	}
	#endregion

	#region Jogo da Memória	
	// Update is called once per frame
	private void LoadMemoriaData(){
		string filePath = Application.dataPath + gameDataMemoria;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllMemoriaData loadedData = (JsonUtility.FromJson<AllMemoriaData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) memoriaDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}


	private void SaveMemoriaData(){
		string dataAsJson = JsonUtility.ToJson(memoriaDatas);
		string filePath = Application.dataPath + gameDataMemoria;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}

	public void SetMemoriaData(MemoriaData memoriaData){
		memoriaDatas.memoriaDatas.Add(memoriaData);
		SaveMemoriaData();
	}

	public List<MemoriaData> GetMemoriaDatas(){
		LoadMemoriaData();
		return memoriaDatas.memoriaDatas;		
	}
	#endregion 

	#region  PiqueEsconde
	private void LoadPiqueData()
	{
		string filePath = Application.dataPath + gameDataPique;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllPiqueData loadedData = (JsonUtility.FromJson<AllPiqueData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) piqueDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}

	private void SavePiqueData(){
		string dataAsJson = JsonUtility.ToJson(piqueDatas);
		string filePath = Application.dataPath + gameDataPique;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}

	public void SetPiqueData(PiqueData piqueData){
		piqueDatas.piqueDatas.Add(piqueData);
		SavePiqueData();
	}
	public List<PiqueData> GetPiqueData(){
		LoadPiqueData();
		return piqueDatas.piqueDatas;		
	}


	#endregion

	#region Horta
	private void LoadHortaData()
	{
		string filePath = Application.dataPath + gameDataHorta;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllHortaData loadedData = (JsonUtility.FromJson<AllHortaData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) hortaDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}
	private void SaveHortaData(){
		string dataAsJson = JsonUtility.ToJson(hortaDatas);
		string filePath = Application.dataPath + gameDataHorta;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetHortaData(HortaData hortaData){
		hortaDatas.hortaDatas.Add(hortaData);
		SaveHortaData();
	}
	public List<HortaData> GetHortaData(){
		LoadHortaData();
		return hortaDatas.hortaDatas;		
	}
	#endregion
	
	#region Olho nos Lobos
	private void LoadOlhoLoboData()
	{
		string filePath = Application.dataPath + gameDataOlhoNosLobos;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllOlhoNoLoboData loadedData = (JsonUtility.FromJson<AllOlhoNoLoboData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) olhoNoLoboDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}
	private void SaveOlhoLobosData(){
		string dataAsJson = JsonUtility.ToJson(olhoNoLoboDatas);
		string filePath = Application.dataPath + gameDataOlhoNosLobos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetOlhoLobosData(OlhoNoLoboData olhoNoLoboData){
		olhoNoLoboDatas.olhoNoLoboDatas.Add(olhoNoLoboData);
		SaveOlhoLobosData();
	}
	public List<OlhoNoLoboData> GetOlhoLobosData(){
		LoadOlhoLoboData();
		return olhoNoLoboDatas.olhoNoLoboDatas;		
	}


#endregion

	#region Bolos
	private void LoadBolosData()
	{
		string filePath = Application.dataPath + gameDataBolos;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllBolosData loadedData = (JsonUtility.FromJson<AllBolosData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) bolosDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}
	private void SaveBolosData(){
		string dataAsJson = JsonUtility.ToJson(bolosDatas);
		string filePath = Application.dataPath + gameDataBolos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetBolosDara(BolosData bolosData){
		bolosDatas.bolosDatas.Add(bolosData);
		SaveBolosData();
	}
	public List<BolosData> GetBolosData(){
		LoadOlhoLoboData();
		return bolosDatas.bolosDatas;		
	}

	#endregion

	#region Pastoreia
	private void LoadPastoreiraData()
	{
		string filePath = Application.dataPath + gameDataPastoreira;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllPastoreiraData loadedData = (JsonUtility.FromJson<AllPastoreiraData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) pastoreiraDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}
	private void SavePastoreiraData(){
		string dataAsJson = JsonUtility.ToJson(pastoreiraDatas);
		string filePath = Application.dataPath + gameDataPastoreira;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetPastoreiraDatas(PastoreiraData pastoreiraData){
		pastoreiraDatas.pastoreiraDatas.Add(pastoreiraData);
		SavePastoreiraData();
	}
	public List<PastoreiraData> GetPastoreiraData(){
		LoadOlhoLoboData();
		return pastoreiraDatas.pastoreiraDatas;		
	}
	#endregion
	
	#region Contando os Bichos
	private void LoadContandoBichosData()
	{
		string filePath = Application.dataPath + gameDataContandoBixos;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllContandoBixosData loadedData = (JsonUtility.FromJson<AllContandoBixosData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) contandoBixosDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}
	private void SaveContandoBichosData(){
		string dataAsJson = JsonUtility.ToJson(contandoBixosDatas);
		string filePath = Application.dataPath + gameDataContandoBixos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetContandoBichosData(ContandoBixosData contandoBixosData){
		contandoBixosDatas.contandoBixosDatas.Add(contandoBixosData);
		SaveContandoBichosData();
	}
	public List<ContandoBixosData> GetContandoBichosData(){
		LoadContandoBichosData();
		return contandoBixosDatas.contandoBixosDatas;		
	}
	#endregion

	























}