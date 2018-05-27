using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour 
{
	public void StartGameClicked()
	{

		LoadingManager.Instance.SetSceneToUnload (SceneNames.TITLE_SCENE);
		LoadingManager.Instance.SetSceneToLoad (SceneNames.GAME_UI + "," + SceneNames.GAME_SCENE);
		LoadingManager.Instance.LoadGameScene ();
	}
}
