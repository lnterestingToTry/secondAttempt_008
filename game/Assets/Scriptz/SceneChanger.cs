using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
	public static void ChangeSceneSt(int scene_index)
	{
		Debug.Log("Scene_changed");
		SceneManager.LoadScene(scene_index);
	}

	public void ChangeScene(int scene_index)
	{
		Debug.Log("Scene_changed");
		SceneManager.LoadScene(scene_index);
	}
	public void Exit()
	{
		Application.Quit();
	}
}
