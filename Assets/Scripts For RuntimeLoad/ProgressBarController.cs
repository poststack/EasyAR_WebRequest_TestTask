using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
	public float progress = 0f;
	private Image progressBarImage;
	[SerializeField]
	private Slider progressSlider;

	private void Awake()
	{
		progressBarImage = GetComponent<Image>();
	}

	private void UpdateProgressBar()
	{
		//progressBarImage.fillAmount = progress;
		progressSlider.value = progress;
	}

	public void SetProgress(float newProgress)
	{
		progress = Mathf.Clamp01(newProgress);
		UpdateProgressBar();
	}
}
