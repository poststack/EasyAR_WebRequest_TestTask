	using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEngine;
using TMPro;

using System.Linq;


public class ARStatusUpdater : MonoBehaviour
{
	public TextMeshProUGUI statusTextObject;
	[SerializeField]
	private string stringToCheck = "StatusUI";
	
	public void Awake()
	{
		//TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
		// string[] textnames; 

		//	textnames = new string[texts.Length];

		//	for (int i = 0; i < texts.Length; i++)
		//	{
		//		textnames[i] = texts[i].name;
		//	}

		//	foreach (string name in textnames)
		//	{
		//		Debug.Log(name);
		//	}

		//if(textnames.Any(stringToCheck.Contains))
		//{
		//	statusTextObject = GameObject.Find(textnames.First(stringToCheck.Contains)).GetComponent<TextMeshProUGUI>();
		//}
		
		statusTextObject = GameObject.Find(stringToCheck).GetComponent<TextMeshProUGUI>();


	}
	
	
	

	private void OnEnable()
	{
		if (statusTextObject != null)
		{
			statusTextObject.text = "Enabled status";
		}
	}

	private void OnDisable()
	{
		if (statusTextObject != null)
		{
			statusTextObject.text = "Disabled status";
		}
	}
	
	

	
}