using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InternetConnectivityChecker : MonoBehaviour
{
	
	public GameObject HaveInternetObject;
	public GameObject NoInternetObject;
	private bool isNetworkAvailable = false;

	
	void Start()
	{
		InvokeRepeating("CheckInternetConnectivity", 1f, 1f);
		//CheckInternetConnectivity();
	}

	void CheckInternetConnectivity()
	{
		if (Application.internetReachability == NetworkReachability.NotReachable)
		{
			Debug.Log("No internet connection");
			NoInternetObject.SetActive(true);
			isNetworkAvailable = false;

		}
		else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
		{
			Debug.Log("Connected using mobile data");
			HaveInternetObject.SetActive(true);
			NoInternetObject.SetActive(false);

			isNetworkAvailable = true;


		}
		else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
		{
			Debug.Log("Connected using Wi-Fi or LAN");
			HaveInternetObject.SetActive(true);
			NoInternetObject.SetActive(false);

			isNetworkAvailable = true;

		}
		
		SendMessage("SetNetworkAvailability", isNetworkAvailable, SendMessageOptions.DontRequireReceiver);
	}
	
	
}