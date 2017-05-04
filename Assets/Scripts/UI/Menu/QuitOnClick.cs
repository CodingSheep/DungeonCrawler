using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {
    /*! \class QuitOnClick
     * Handles how unity will quit the application
     */

    /*!
     * Checks the application if its in editor, the changes how quiting the game runs
     * @note Application.Quit() will not work inside editor, only build
     */
	public void Quit()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
