using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InternetConnectivityChecker : MonoBehaviour
{
	
	public GameObject HaveInternetObject;
	public GameObject NoInternetObject;

	
	void Start()
	{
		CheckInternetConnectivity();
	}

	void CheckInternetConnectivity()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			Debug.Log("No internet connection");
			NoInternetObject.SetActive(true);
		}
		else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
		{
			Debug.Log("Connected using mobile data");
			HaveInternetObject.SetActive(true);

		}
		else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
		{
			Debug.Log("Connected using Wi-Fi or LAN");
			HaveInternetObject.SetActive(true);

		}
	}
	
	
}