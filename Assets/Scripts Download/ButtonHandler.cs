using UnityEngine.SceneManagement;

using System.Collections;


using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
	[SerializeField]
	private Button button;
	
	[SerializeField]
	private string scenenameToGo;



	private Coroutine coroutine;
	
	



	public void SetNetworkAvailability(bool isAvailable)
	{
		button.interactable = isAvailable;
		if (isAvailable)
		{
			GoToARScene();
		}
	}
	
	

	public void OnButtonClick()
	{
		Debug.Log("Go to next scente");
		SceneManager.LoadScene(scenenameToGo, LoadSceneMode.Single);

	}
	
	
	public void GoToARScene()
	{
		if (coroutine == null)
		{
			coroutine = StartCoroutine(ChangeButtonName());
		}
		
	}



	IEnumerator ChangeButtonName()
	{
		int count = 10;
		while (count >= 1)
		{
			button.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();
			yield return new WaitForSeconds(0.3f);
			count--;
		}

		OnButtonClick();
	}


}