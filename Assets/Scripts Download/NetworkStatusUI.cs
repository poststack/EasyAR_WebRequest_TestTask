using UnityEngine;
using UnityEngine.UI;

public class NetworkStatusUI : MonoBehaviour
{
	public Text networkStatusText;

	private void Start()
	{
		networkStatusText.text = "Initializing...";
	}

	private void SetNetworkAvailability(bool isAvailable)
	{
		if (isAvailable)
		{
			networkStatusText.text = "Network is ON";
		}
		else
		{
			networkStatusText.text = "Network is OFF";
		}
	}
}