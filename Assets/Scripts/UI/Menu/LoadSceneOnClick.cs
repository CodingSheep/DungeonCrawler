using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
    /*! \class LoadSceneOnClick
     * Handles differenct scenes
     */

    /*!
     * Loads a scene by index
     * @param SceneIndex is the value of the scene assigned by build order
     */
	public void LoadByIndex(int SceneIndex)
	{
		SceneManager.LoadScene (SceneIndex);
	}
}