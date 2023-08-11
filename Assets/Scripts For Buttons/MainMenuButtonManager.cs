


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
	public Button button1;
	public Button button2;
	public Button button3;

	
	[SerializeField]
	private string Scene1Name, Scene2Name,Scene3Name;

	private void Start()
	{
		button1.onClick.AddListener(delegate{_LoadScene(Scene1Name);});
		button2.onClick.AddListener(delegate{_LoadScene(Scene2Name);});
		button3.onClick.AddListener(delegate{_LoadScene(Scene3Name);});
	}

	public void _LoadScene(string input)
	{
		SceneManager.LoadScene(input);
	}


}
