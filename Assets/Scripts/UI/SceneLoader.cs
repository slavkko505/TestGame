using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
	[SerializeField] TextMeshProUGUI levelTextField = null;
	[SerializeField] CanvasGroup mainCanvas = null;
	[SerializeField] CanvasGroup loseCanvas = null;
	public static SceneLoader instance = null;

	private void Awake()
	{
		if (instance == null) 
		{ 
			instance = this; 
		} 
		else if(instance == this)
		{ 
			Destroy(gameObject); 
		}
	}

	private void Start()
	{
		loseCanvas.alpha = 0;
		loseCanvas.blocksRaycasts = false;
		levelTextField.text = $"Level: {GameManager.instance.currLevel}";
	}

	public void OnPlayClick() 
	{
		Hide();
		GameManager.instance.StartGame();
	}

	public void OnRestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void OnLoseGame()
	{
		LeanTween.alphaCanvas(loseCanvas, 1.0f, 0.2f);
		loseCanvas.blocksRaycasts = true;
	}

	public void Hide() 
	{
		LeanTween.alphaCanvas(mainCanvas, 0.0f, 0.2f);
	}
	
	
}
