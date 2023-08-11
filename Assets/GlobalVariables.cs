using UnityEngine;
using System.IO;


public class GlobalVariables : MonoBehaviour
{
	private static GlobalVariables instance;

	[SerializeField]
	public static int score;
	[SerializeField]
	public static string directory;

	[SerializeField]
	private  int _score;
	[SerializeField]
	private  string _directory;


	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(this.gameObject);
		Initilize();
	}
	
	
	private void Initilize()
	{
		directory = Path.Combine(Application.persistentDataPath, "TargetOnTheFly");
		if (!Directory.Exists(directory))
			Directory.CreateDirectory(directory);
		_directory = directory;
	}
}
