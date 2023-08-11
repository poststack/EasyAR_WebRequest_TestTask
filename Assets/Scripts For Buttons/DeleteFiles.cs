using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;


public class DeleteFiles : MonoBehaviour
{
	
	[SerializeField]
	private Button ButtonDeleteFiles;
	
	[SerializeField]
	private TextMeshProUGUI StatusUI;

	void Start()
	{

		ButtonDeleteFiles.onClick.AddListener(DeleteAllFiles);
	}

	public void DeleteAllFiles()
	{
		string[] files = Directory.GetFiles(GlobalVariables.directory);

		string text = "Status:" + "\n";
		
		foreach (string file in files)
		{
			File.Delete(file);

			Debug.Log("Deleted file: " + file);
			text += "Deleted file: " + getFilename(file);
			text += "\n";
		}
		
		StatusUI.text = text;
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
