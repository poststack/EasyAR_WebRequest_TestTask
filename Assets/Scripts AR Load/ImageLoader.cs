using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using easyar;

public class ImageLoader : MonoBehaviour
{
	
	public RuntimeImport _runtimeImport;
	
	public List<string> imageNames = new List<string>();
	public List<string> objectsNames = new List<string>();
	//public List<G> objectsFiles = new List<string>();
 

	
	[SerializeField]
	private ImageTargetController TargetPrefab;
	[SerializeField]
	private ImageTargetController TargetObject;
	[SerializeField]
	private ImageTrackerFrameFilter imageTrackerFrameFilter;

	void Start()
	{
		LoadImagesFromStreamingAssets();
		LoadTargetModels();
	}

	void LoadImagesFromStreamingAssets()
	{
		string streamingAssetsPath = Application.streamingAssetsPath;
		string[] imagePaths = Directory.GetFiles(streamingAssetsPath, "*.png");

		foreach (string imagePath in imagePaths)
		{
			string imageName = Path.GetFileNameWithoutExtension(imagePath);
			imageNames.Add(imageName);
		}
	}


	


	
	


	void LoadTargetModels()
	{
		foreach (string imageName in imageNames)
		{
			Debug.Log("Image name: " + imageName);
			TargetObject = Instantiate(TargetPrefab,gameObject.transform);
			TargetObject.ImageFileSource.Path = imageName + ".png";
			TargetObject.Tracker = imageTrackerFrameFilter;
			StartCoroutine(CheckForModel());
			
		}
	}
	
	private IEnumerator CheckForModel()
	{
		while (_runtimeImport.loadedObject == null)
		{
			yield return null; 
			Debug.Log("переменная  null");
		}

		LoadARModel();
	}
	
	void LoadARModel()
	{
		_runtimeImport.loadedObject.transform.parent = TargetObject.transform.GetChild(0).transform;
		_runtimeImport.loadedObject.GetComponent<ResetObjectTransform>().Reset();
		_runtimeImport.loadedObject.SetActive(true);
		

		
	}
}