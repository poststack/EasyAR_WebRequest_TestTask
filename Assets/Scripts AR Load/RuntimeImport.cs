using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Siccity.GLTFUtility;
using System.IO;
using System.Collections.Generic;



public class RuntimeImport : MonoBehaviour
{
	
	public List<string> files = new List<string>();
	
	public GameObject loadedObject;
	public bool isObjectRotating;
	
    // Start is called before the first frame update
    void Start()
	{
		
		string[] files = Directory.GetFiles(GlobalVariables.directory, "*.glb");
		ImportGLTF(files[0]);
    }

	void ImportGLTF(string filepath) {
		loadedObject = Importer.LoadFromFile(filepath);
		loadedObject .name  = GenerateRandomString(8);
		loadedObject.SetActive(false);
		loadedObject.AddComponent<ResetObjectTransform>();	
		//loadedObject.AddComponent<TouchRotationAndScale>();	


		if (isObjectRotating)
		{
			ObjectRotator objectRotator = loadedObject.AddComponent<ObjectRotator>();	
		}
	}
		
	
	
	private const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

	private string GenerateRandomString(int length)
	{
		char[] randomString = new char[length];

		for (int i = 0; i < length; i++)
		{
			randomString[i] = characters[Random.Range(0, characters.Length)];
		}

		return new string(randomString);
	}


}
