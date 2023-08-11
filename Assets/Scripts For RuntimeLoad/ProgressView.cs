using UnityEngine;
using UnityEngine.UI;

//using EasyButtons;

public class ProgressView : MonoBehaviour
{
	
	public string urlToDownloadModel;
	[SerializeField]
	private RuntimeImportBehaviour runtimeImportBehaviour;
	
	[SerializeField]
	private Button StartDownloadButton;
	
	public bool LoadOnStart = false;
	

	void Start()
	{
		if (StartDownloadButton != null)
			StartDownloadButton.onClick.AddListener(StartDownload);
		if (LoadOnStart)
		StartDownload();
	}
	
	
	//Start download
	public void StartDownload()
	{
		runtimeImportBehaviour.StartDownload(urlToDownloadModel);
	}
}
