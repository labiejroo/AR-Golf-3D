using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManagerScript : MonoBehaviour {

	public void StartGame()
	{
		SceneManager.LoadScene ("lvl01");
	
	}

}
