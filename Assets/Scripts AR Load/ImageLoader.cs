using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using easyar;
using System.Linq;



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
		LoadImagesFromMemory();
		LoadTargetModels();
	}

	void LoadImagesFromMemory()
	{
		
		string[] imagePng = Directory.GetFiles(GlobalVariables.directory, "*.png");
		string[] imagejpg = Directory.GetFiles(GlobalVariables.directory, "*.jpg");
		string[] imagejpeg = Directory.GetFiles(GlobalVariables.directory, "*.jpeg");

		string[] imagePaths = imagePng.Concat(imagejpg).ToArray().Concat(imagejpeg).ToArray();


		foreach (string imagePath in imagePaths)
		{
			string imageName = Path.GetFileName(imagePath);
			imageNames.Add(imageName);
		}
	}



	void LoadTargetModels()
	{
		foreach (string imageName in imageNames)
		{
			Debug.Log("Image name: " + imageName);
			TargetObject = Instantiate(TargetPrefab,gameObject.transform);
			
			TargetObject.ImageFileSource.PathType = PathType.Absolute;
			TargetObject.ImageFileSource.Path = Path.Combine(GlobalVariables.directory, imageName );
			TargetObject.ImageFileSource.Name = imageName;

			TargetObject.Tracker = imageTrackerFrameFilter;
			StartCoroutine(CheckForModel( TargetObject.gameObject));
			
		}
	}
	
	private IEnumerator CheckForModel(GameObject targetToStickModel)
	{
		while (_runtimeImport.loadedObject == null)
		{
			yield return null; 
			Debug.Log("переменная  null");
		}

		LoadARModel(targetToStickModel);
	}
	
	
	//приделывает модель торта к префабу
	void LoadARModel(GameObject targetToStickModel)
	{
		GameObject CakeClone = Instantiate(_runtimeImport.loadedObject, targetToStickModel.transform.GetChild(0).transform);
		CakeClone.GetComponent<ResetObjectTransform>().Reset();
		CakeClone.SetActive(true);
				
	}
}