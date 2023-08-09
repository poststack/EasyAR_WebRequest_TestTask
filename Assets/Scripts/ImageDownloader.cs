using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class ImageDownloader : MonoBehaviour
{
	public string imageUrl = "https://user74522.clients-cdnnow.ru/static/uploads/mrk6440mark.png";

	void Start()
	{
		StartCoroutine(DownloadAndSaveImage(imageUrl));
	}

	IEnumerator DownloadAndSaveImage(string url)
	{
		using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
		{
			yield return webRequest.SendWebRequest();

			if (webRequest.result == UnityWebRequest.Result.Success)
			{
				string savePath = Path.Combine(Application.streamingAssetsPath, "mrk6440mark.png");

				// Save the downloaded image to the StreamingAssets folder
				File.WriteAllBytes(savePath, webRequest.downloadHandler.data);

				Debug.Log("Image downloaded and saved to: " + savePath);
			}
			else
			{
				Debug.Log("Image download failed. Error: " + webRequest.error);
			}
		}
	}
}