using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGame : MonoBehaviour
{
	public static SaveGame instance {get; private set;}//instância do SaveGame
	string path;//local do arquivo de save
	
	//língua do texto do jogo, 0 english 1 portugues
	public string language;
	
	//níveis que o player pode jogar com Load Level
	public int levelsUnlocked;
	
	//opções do main menu
	public int graphicQuality;
	public bool fullScreen;
	public int resolution;
	public float mainVolume;
	
	void Awake()
	{
		path = Application.persistentDataPath + "/SaveInfo.topologix";
		
		//se tiver outra instância desse objeto
		if(instance != null && instance != this)
		{
			Destroy(gameObject);
		}
		//se não
		else
		{
			instance = this;
		}
		
		Load();
		
		print("Save File " + File.Exists(path));
	}
	
	public void Load()
	{
		if(File.Exists(path))
		{
			//variáveis da formatação binária
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(path, FileMode.Open);
			SaveData data = (SaveData)bf.Deserialize(file);
			
			//variáveis loadadas
			language = data.language;
			levelsUnlocked = data.levelsUnlocked;
			graphicQuality = data.graphicQuality;
			fullScreen = data.fullScreen;
			resolution = data.resolution;
			mainVolume = data.mainVolume;
			
			file.Close();
		}
	}
	
	public void Save()
	{
		//variáveis da formatação binária
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(path);
		SaveData data = new SaveData();
		
		//variáveis salvas
		data.language = language;
		data.levelsUnlocked = levelsUnlocked;
		data.graphicQuality = graphicQuality;
		data.fullScreen = fullScreen;
		data.resolution = resolution;
		data.mainVolume = mainVolume;
		
		//formatação binária das variáveis salvas
		bf.Serialize(file, data);
		
		file.Close();
	}
	
	[Serializable]
	class SaveData
	{
		public string language;
		public int levelsUnlocked;
		public int graphicQuality;
		public bool fullScreen;
		public int resolution;
		public float mainVolume;
	}
}
