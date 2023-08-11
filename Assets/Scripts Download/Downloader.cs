using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

using System;
using System.Text.RegularExpressions;


public class Downloader : MonoBehaviour
{
	public string targetUrl = "https://user74522.clients-cdnnow.ru/static/uploads/mrk6440mark.png";
	public string objectUrl = "https://user74522.clients-cdnnow.ru/static/uploads/mrk6564obj.glb";
	

	
	
	void Start()
	{
		
		StartCoroutine(DownloadAndSaveFile(targetUrl));
		
		StartCoroutine(DownloadAndSaveFile(objectUrl));

	}
	
	

	IEnumerator DownloadAndSaveFile(string url)
	{
		using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
		{
			yield return webRequest.SendWebRequest();

			if (webRequest.result == UnityWebRequest.Result.Success)
			{
				


				
				string savePath = Path.Combine(GlobalVariables.directory, getFilename(url) );

				File.WriteAllBytes(savePath, webRequest.downloadHandler.data);

				Debug.Log("Image downloaded and saved to: " + savePath);
			}
			else
			{
				Debug.Log("Image download failed. Error: " + webRequest.error);
			}
		}
	}
	
	
	private string getFilename(string url)
	{
		string pattern = @"/([^/]+)$";
		
		Match match = Regex.Match(url, pattern);
		
		string fileName = "";
		
		if (match.Success)
		{
			fileName = match.Groups[1].Value;
			Debug.Log(fileName);
		}

		return fileName;
	}
}