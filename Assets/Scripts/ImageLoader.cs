using UnityEngine;
using System.IO;
using System.Collections.Generic;
using easyar;

public class ImageLoader : MonoBehaviour
{
	public List<string> imageNames = new List<string>();
	
	[SerializeField]
	private ImageTargetController TargetPrefab;
	[SerializeField]
	private ImageTrackerFrameFilter imageTrackerFrameFilter;

	void Start()
	{
		LoadImagesFromStreamingAssets();
		PrintImageNames();
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

	void PrintImageNames()
	{
		foreach (string imageName in imageNames)
		{
			Debug.Log("Image name: " + imageName);
			var targetPrefab = Instantiate(TargetPrefab,gameObject.transform);
			targetPrefab.ImageFileSource.Path = imageName + ".png";
			targetPrefab.Tracker = imageTrackerFrameFilter;
		}
	}
}