using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class BackButtonScript : MonoBehaviour
{
	[SerializeField]
	private Button BackButton;
	
	[SerializeField]
	private string Scene1Name;
	//"MenuScene"


	void Start()
	{

		BackButton.onClick.AddListener(LoadScene1);
	}
	
	
		


	private void LoadScene1()
	{
		SceneManager.LoadScene(Scene1Name);
	}
}
