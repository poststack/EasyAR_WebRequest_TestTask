using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class ImageLoader : MonoBehaviour
{
	public List<string> imageNames = new List<string>();

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
		}
	}
}