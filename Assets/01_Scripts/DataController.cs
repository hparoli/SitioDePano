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
		if(alimentosData.level == "F"){
			if(alimentosData.nota > alimentosDatas.notaFacil) alimentosDatas.notaFacil = alimentosData.nota;
		} else if(alimentosData.level == "M") {
			if(alimentosData.nota > alimentosDatas.notaMedio) alimentosDatas.notaMedio = alimentosData.nota;
		} else if(alimentosData.level == "D"){
			if(alimentosData.nota > alimentosDatas.notaDificil) alimentosDatas.notaDificil = alimentosData.nota;
		}
		SaveAlimentosData();
	}

	public List<AlimentosData> GetAlimentosDatas(){
		LoadAlimentosData();
		return alimentosDatas.alimentosDatas;
	}

	public int GetAlimentosFacil(){
		return alimentosDatas.notaFacil;
	}
	public int GetAlimentosMedio(){
		return alimentosDatas.notaMedio;
	}
	public int GetAlimentosDificil(){
		return alimentosDatas.notaDificil;
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
		if(memoriaData.level == "F"){
			if(memoriaData.nota > memoriaDatas.notaFacil) memoriaDatas.notaFacil = memoriaData.nota;
		} else if(memoriaData.level == "M") {
			if(memoriaData.nota > memoriaDatas.notaMedio) memoriaDatas.notaMedio = memoriaData.nota;
		} else if(memoriaData.level == "D"){
			if(memoriaData.nota > memoriaDatas.notaDificil) memoriaDatas.notaDificil = memoriaData.nota;
		}
		memoriaDatas.memoriaDatas.Add(memoriaData);
		SaveMemoriaData();
	}

	public List<MemoriaData> GetMemoriaDatas(){
		LoadMemoriaData();
		return memoriaDatas.memoriaDatas;		
	}

	public int GetMemoriaFacil(){
		return memoriaDatas.notaFacil;
	}
	public int GetMemoriaMedio(){
		return memoriaDatas.notaMedio;
	}
	public int GetMemoriaDificil(){
		return memoriaDatas.notaDificil;
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
		if(piqueData.level == "F"){
			if(piqueData.nota > piqueDatas.notaFacil) piqueDatas.notaFacil = piqueData.nota;
		} else if(piqueData.level == "M") {
			if(piqueData.nota > piqueDatas.notaMedio) piqueDatas.notaMedio = piqueData.nota;
		} else if(piqueData.level == "D"){
			if(piqueData.nota > piqueDatas.notaDificil) piqueDatas.notaDificil = piqueData.nota;
		}
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
		if(hortaData.level == "F"){
			if(hortaData.nota > hortaDatas.notaFacil) hortaDatas.notaFacil = hortaData.nota;
		} else if(hortaData.level == "M") {
			if(hortaData.nota > hortaDatas.notaMedio) hortaDatas.notaMedio = hortaData.nota;
		} else if(hortaData.level == "D"){
			if(hortaData.nota > hortaDatas.notaDificil) hortaDatas.notaDificil = hortaData.nota;
		}
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
		if(olhoNoLoboData.level == "F"){
			if(olhoNoLoboData.nota > olhoNoLoboDatas.notaFacil) olhoNoLoboDatas.notaFacil = olhoNoLoboData.nota;
		} else if(olhoNoLoboData.level == "M") {
			if(olhoNoLoboData.nota > olhoNoLoboDatas.notaMedio) olhoNoLoboDatas.notaMedio = olhoNoLoboData.nota;
		} else if(olhoNoLoboData.level == "D"){
			if(olhoNoLoboData.nota > olhoNoLoboDatas.notaDificil) olhoNoLoboDatas.notaDificil = olhoNoLoboData.nota;
		}
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
		if(bolosData.level == "F"){
			if(bolosData.nota > bolosDatas.notaFacil) bolosDatas.notaFacil = bolosData.nota;
		} else if(bolosData.level == "M") {
			if(bolosData.nota > bolosDatas.notaMedio) bolosDatas.notaMedio = bolosData.nota;
		} else if(bolosData.level == "D"){
			if(bolosData.nota > bolosDatas.notaDificil) bolosDatas.notaDificil = bolosData.nota;
		}
		SaveBolosData();
	}
	public List<BolosData> GetBolosData(){
		LoadOlhoLoboData();
		return bolosDatas.bolosDatas;		
	}

	public int GetBoloFacil(){
		return bolosDatas.notaFacil;
	}
	public int GetBoloMedio(){
		return bolosDatas.notaMedio;
	}
	public int GetBoloDificil(){
		return bolosDatas.notaDificil;
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
		if(pastoreiraData.level == "F"){
			if(pastoreiraData.nota > pastoreiraDatas.notaFacil) pastoreiraDatas.notaFacil = pastoreiraData.nota;
		} else if(pastoreiraData.level == "M") {
			if(pastoreiraData.nota > pastoreiraDatas.notaMedio) pastoreiraDatas.notaMedio = pastoreiraData.nota;
		} else if(pastoreiraData.level == "D"){
			if(pastoreiraData.nota > pastoreiraDatas.notaDificil) pastoreiraDatas.notaDificil = pastoreiraData.nota;
		}
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
		if(contandoBixosData.level == "F"){
			if(contandoBixosData.nota > contandoBixosDatas.notaFacil) contandoBixosDatas.notaFacil = contandoBixosData.nota;
		} else if(contandoBixosData.level == "M") {
			if(contandoBixosData.nota > contandoBixosDatas.notaMedio) contandoBixosDatas.notaMedio = contandoBixosData.nota;
		} else if(contandoBixosData.level == "D"){
			if(contandoBixosData.nota > contandoBixosDatas.notaDificil) contandoBixosDatas.notaDificil = contandoBixosData.nota;
		}
		SaveContandoBichosData();
	}
	public List<ContandoBixosData> GetContandoBichosData(){
		LoadContandoBichosData();
		return contandoBixosDatas.contandoBixosDatas;		
	}
	#endregion

	#region  ColetandoOvos
	private void LoadColetandoOvosData()
	{
		string filePath = Application.dataPath + gameDataColetandoOvos;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllColetandoOvosData loadedData = (JsonUtility.FromJson<AllColetandoOvosData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) coletandoOvosDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}
	private void SaveColetandoOvosData(){
		string dataAsJson = JsonUtility.ToJson(coletandoOvosDatas);
		string filePath = Application.dataPath + gameDataColetandoOvos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetColetandOvosData(ColetandoOvosData coletandoOvosData){
		coletandoOvosDatas.coletandoOvosDatas.Add(coletandoOvosData);
		if(coletandoOvosData.level == "F"){
			if(coletandoOvosData.nota > coletandoOvosDatas.notaFacil) coletandoOvosDatas.notaFacil = coletandoOvosData.nota;
		} else if(coletandoOvosData.level == "M") {
			if(coletandoOvosData.nota > coletandoOvosDatas.notaMedio) coletandoOvosDatas.notaMedio = coletandoOvosData.nota;
		} else if(coletandoOvosData.level == "D"){
			if(coletandoOvosData.nota > coletandoOvosDatas.notaDificil) coletandoOvosDatas.notaDificil = coletandoOvosData.nota;
		}
		SaveColetandoOvosData();
	}
	public List<ColetandoOvosData> GetColetandoOvosData(){
		LoadColetandoOvosData();
		return coletandoOvosDatas.coletandoOvosDatas;		
	}
	#endregion

	#region Caminhos
	private void LoadCaminhosData()
	{
		string filePath = Application.dataPath + gameDataCaminhos;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllCaminhosData loadedData = (JsonUtility.FromJson<AllCaminhosData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) caminhosDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}
	private void SaveCaminhosData(){
		string dataAsJson = JsonUtility.ToJson(caminhosDatas);
		string filePath = Application.dataPath + gameDataCaminhos;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetCaminhosData(CaminhosData caminhosData){
		caminhosDatas.caminhosDatas.Add(caminhosData);
		if(caminhosData.level == "F"){
			if(caminhosData.nota > caminhosDatas.notaFacil) caminhosDatas.notaFacil = caminhosData.nota;
		} else if(caminhosData.level == "M") {
			if(caminhosData.nota > caminhosDatas.notaMedio) caminhosDatas.notaMedio = caminhosData.nota;
		} else if(caminhosData.level == "D"){
			if(caminhosData.nota > caminhosDatas.notaDificil) caminhosDatas.notaDificil = caminhosData.nota;
		}
		SaveCaminhosData();
	}
	public List<CaminhosData> GetCaminhosData(){
		LoadCaminhosData();
		return caminhosDatas.caminhosDatas;		
	}

	#endregion 

	#region SequenciaSonora
	private void LoadSequenciaData()
	{
		string filePath = Application.dataPath + gameDataSequenciaSonora;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllSequenciaSonoraData loadedData = (JsonUtility.FromJson<AllSequenciaSonoraData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) sequenciaSonoraDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}

	private void SaveSequenciData(){
		string dataAsJson = JsonUtility.ToJson(sequenciaSonoraDatas);
		string filePath = Application.dataPath + gameDataSequenciaSonora;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetSequenciaData(SequenciaSonoraData sequenciaSonoraData){
		sequenciaSonoraDatas.sequenciaSonoraDatas.Add(sequenciaSonoraData);
		if(sequenciaSonoraData.level == "F"){
			if(sequenciaSonoraData.nota > sequenciaSonoraDatas.notaFacil) sequenciaSonoraDatas.notaFacil = sequenciaSonoraData.nota;
		} else if(sequenciaSonoraData.level == "M") {
			if(sequenciaSonoraData.nota > sequenciaSonoraDatas.notaMedio) sequenciaSonoraDatas.notaMedio = sequenciaSonoraData.nota;
		} else if(sequenciaSonoraData.level == "D"){
			if(sequenciaSonoraData.nota > sequenciaSonoraDatas.notaDificil) sequenciaSonoraDatas.notaDificil = sequenciaSonoraData.nota;
		}
		SaveSequenciData();
	}
	public List<SequenciaSonoraData> GetSequenciData(){
		LoadSequenciaData();
		return sequenciaSonoraDatas.sequenciaSonoraDatas;		
	}

	public int GetSequenciaFacil(){
		return sequenciaSonoraDatas.notaFacil;
	}
	public int GetSequenciaMedio(){
		return sequenciaSonoraDatas.notaMedio;
	}
	public int GetSequenciaDificil(){
		return sequenciaSonoraDatas.notaDificil;
	}
	#endregion

	#region  Ditados
	private void LoadDitadosData()
	{
		string filePath = Application.dataPath + gameDataDitados;

		if(File.Exists(filePath)){
			string dataAsJson = File.ReadAllText(filePath);
			Debug.Log("Load: " + dataAsJson);
			AllDitadosData loadedData = (JsonUtility.FromJson<AllDitadosData>(dataAsJson));
			Debug.Log(loadedData);
			if(loadedData != null) ditadosDatas = loadedData;
		} else {
			Debug.LogError("Não encontrou o save da Memória");
		}
	}

	private void SaveDitadosData(){
		string dataAsJson = JsonUtility.ToJson(ditadosDatas);
		string filePath = Application.dataPath + gameDataDitados;
		Debug.Log(dataAsJson);
		File.WriteAllText(filePath, dataAsJson);
	}
	public void SetDitadosData(DitadosData ditadosData){
		ditadosDatas.ditadosDatas.Add(ditadosData);
		if(ditadosData.level == "F"){
			if(ditadosData.nota > ditadosDatas.notaFacil) ditadosDatas.notaFacil = ditadosData.nota;
		} else if(ditadosData.level == "M") {
			if(ditadosData.nota > ditadosDatas.notaMedio) ditadosDatas.notaMedio = ditadosData.nota;
		} else if(ditadosData.level == "D"){
			if(ditadosData.nota > ditadosDatas.notaDificil) ditadosDatas.notaDificil = ditadosData.nota;
		}
		SaveDitadosData();
	}
	public List<DitadosData> GetDitadosData(){
		LoadDitadosData();
		return ditadosDatas.ditadosDatas;		
	}
	#endregion

}