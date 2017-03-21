using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PuzzleManager : MonoBehaviour {
    public List<VRTK_Button> buttons = new List<VRTK_Button>();
	
	void Update () {
		if(buttons.TrueForAll(e => e.done == true)) {
            Debug.Log("Job's done");
        }
	}

    public void UpdateButton(VRTK_Button button) {
        int id = buttons.FindIndex(e => e.GetInstanceID() == button.GetInstanceID());
        Debug.Log(buttons.Find(e => e.GetInstanceID() == button.GetInstanceID()));

        buttons[id].active = false;
        buttons[id].GetComponent<VRTK_InteractableObject>().enabled = false;
        Debug.Log(buttons[id].GetInstanceID());
        Debug.Log(button.GetInstanceID());
        buttons[id].GetComponent<MeshRenderer>().material.color = Color.green;

        if (id != buttons.Count - 1) {
            buttons[id + 1].active = true;
            buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
            Debug.Log(id + 1);
            buttons[id + 1].GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
}
