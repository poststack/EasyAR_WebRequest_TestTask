using UnityEngine.SceneManagement;



using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
	[SerializeField]
	private Button button;
	
	[SerializeField]
	private string scenenameToGo;

	private void Awake()
	{
		button = GetComponent<Button>();

		button.onClick.AddListener(OnButtonClick);
	}


	public void SetNetworkAvailability(bool isAvailable)
	{
		button.interactable = isAvailable;
	}
	
	

	public void OnButtonClick()
	{
		Debug.Log("Go to next scente");
		SceneManager.LoadScene(scenenameToGo, LoadSceneMode.Single);

	}

}