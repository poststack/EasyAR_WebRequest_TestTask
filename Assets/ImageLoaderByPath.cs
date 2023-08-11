using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoaderByPath : MonoBehaviour
{
	public Image image;
	public string imagePath;

	void Start()
	{
		//LoadImageFromFile(imagePath);
	}

	public void LoadImageFromFile(string imagePath)
	{
		// Check if the file exists at the specified path
		if (System.IO.File.Exists(imagePath))
		{
			// Load the image as a texture
			Texture2D texture = new Texture2D(2, 2);
			byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
			texture.LoadImage(imageData);

			// Create a sprite from the texture and assign it to the UI Image
			Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			image.sprite = sprite;
		}
		else
		{
			Debug.LogError("Image file not found at path: " + imagePath);
		}
	}
}
