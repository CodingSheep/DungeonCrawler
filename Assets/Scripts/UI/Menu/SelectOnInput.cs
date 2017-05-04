using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
    /* \class SelectOnInput
     *Handles button selection in menus
     */
	public EventSystem eventSystem; //!< Unity EventSystem caller (used in menus)
	public GameObject selectedObject; //!< object that has been selected

	private bool buttonSelected; //!< boolean handler for if a button has been selected

	//!< updates for when buttons are clicked
	void Update ()
	{
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false)
		{
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		}
	}

    //!< resets buttonSelected value
	private void OnDisable()
	{
		buttonSelected = false;
	}
}
