using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PuzzleManager : MonoBehaviour {
    public List<VRTK_Button> buttons = new List<VRTK_Button>();

	void Start () {
		
	}
	
	void Update () {
		if(buttons.TrueForAll(e => e.done == true)) {
            Debug.Log("Job's done");
        }
	}

    public void UpdateButton(VRTK_Button button) {
        int but = buttons.FindIndex(e => e.GetInstanceID() == button.GetInstanceID());
        buttons[but].active = false;
    }
}
