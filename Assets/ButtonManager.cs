using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void StartGameBtn(){
		SceneManager.LoadScene ("Main Scene");	//Change to what your scene is named
	}

	public void MainMenuBtn(){
		SceneManager.LoadScene ("Main Menu");
	}

}
