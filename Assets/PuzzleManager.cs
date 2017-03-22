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
        
        // Don't try to access element before 0
        if (id - 1 > 0) {
            // If the previous one needed the next one to be completed
            if (buttons[id - 1].doneOnNext && buttons[id - 1].ReachedActivationDistance()) {
                Debug.Log(buttons[id - 1].ReachedActivationDistance());

                buttons[id - 1].active = false;
                buttons[id - 1].done = true;
                buttons[id - 1].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id - 1].GetComponent<MeshRenderer>().material.color = Color.green;

                buttons[id].active = false;
                buttons[id].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id].GetComponent<MeshRenderer>().material.color = Color.green;

                if (id != buttons.Count - 1) {
                    buttons[id + 1].active = true;
                    buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
                    buttons[id + 1].GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
            } else {
                buttons[id].done = false;
            }
        } else {
            if (!buttons[id].doneOnNext) {
                buttons[id].active = false;
                buttons[id].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id].GetComponent<MeshRenderer>().material.color = Color.green;
            }

            if (id != buttons.Count - 1) {
                buttons[id + 1].active = true;
                buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
                buttons[id + 1].GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
        }
    }
}
