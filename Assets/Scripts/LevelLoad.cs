using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoad : MonoBehaviour {

	public GameObject loadingScreen;
	public Slider progressSlider;
	public TextMeshProUGUI progressText;

	public void LoadLevel(int sceneIndex){
		StartCoroutine (LoadAsynchronously (sceneIndex));
	}

	IEnumerator LoadAsynchronously(int sceneIndex){
		loadingScreen.SetActive (true);
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneIndex);

		while (!operation.isDone) {
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			Debug.Log (progress);

			progressSlider.value = progress;
			progressText.text = (progress * 100).ToString ("###") + " %";

			yield return null;
		}
	}

}
