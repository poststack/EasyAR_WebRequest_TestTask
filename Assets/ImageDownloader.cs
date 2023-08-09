using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;




public class ImageDownloader : MonoBehaviour
{
	public string imageUrl = "https://user74522.clients-cdnnow.ru/static/uploads/mrk6440mar" +
		"k.png";
	public Image imageComponen;
	void Start()
	{
		StartCoroutine(DownloadImage(imageUrl));
	}

	IEnumerator DownloadImage(string url)
	{
		using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
		{
			yield return webRequest.SendWebRequest();

			if (webRequest.result == UnityWebRequest.Result.Success)
			{
				// Get the downloaded texture
				Texture2D downloadedTexture = DownloadHandlerTexture.GetContent(webRequest);

				// Create a sprite from the downloaded texture
				Sprite sprite = Sprite.Create(downloadedTexture, new Rect(0, 0, downloadedTexture.width, downloadedTexture.height), Vector2.zero);

				// Use the sprite to display the downloaded image
				// For example, assign it to a UI Image component
				imageComponen.sprite = sprite;
			}
			else
			{
				Debug.Log("Image download failed. Error: " + webRequest.error);
			}
		}
	}
}