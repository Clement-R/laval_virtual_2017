﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PuzzleManager : MonoBehaviour
{
    public List<VRTK_Button> buttons = new List<VRTK_Button>();

    void Update()
    {
        if (buttons.TrueForAll(e => e.done == true))
        {
            Debug.Log("Job's done");
        }
    }

    public void UpdateButton(VRTK_Button button)
    {
        int id = buttons.FindIndex(e => e.GetInstanceID() == button.GetInstanceID());

        // Don't try to access element before 0
        if (id - 1 > 0)
        {
            // If the previous one needed the next one to be completed
            if (buttons[id - 1].doneOnNext && buttons[id - 1].ReachedActivationDistance())
            {

                // Deactivate previous button
                buttons[id - 1].active = false;
                buttons[id - 1].done = true;
                buttons[id - 1].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id - 1].GetComponent<MeshRenderer>().material.color = Color.green;
                //buttons[id - 1].GetComponent<AudioSource>().Play();

                // Deactivate the button who called the method
                buttons[id].active = false;
                buttons[id].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id].GetComponent<MeshRenderer>().material.color = Color.green;

                ActivateCircle(buttons[id]);

                // Prepare next button of the puzzle
                if (id != buttons.Count - 1)
                {
                    buttons[id + 1].active = true;
                    buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
                    buttons[id + 1].GetComponent<MeshRenderer>().material.color = buttons[id + 1].GetComponent<ActiveColor>().m_activeColor;
                }
            }
            else if (buttons[id - 1].doneOnNext && !buttons[id - 1].ReachedActivationDistance())
            {
                buttons[id].done = false;

                /*
                buttons[id].active = false;
                buttons[id].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id].GetComponent<MeshRenderer>().material.color = Color.green;

                if (id != buttons.Count - 1) {
                    buttons[id + 1].active = true;
                    buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
                    buttons[id + 1].GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
                */
                // If the call wasn't made by a doneOnNext type of button
            }
            else if (!buttons[id].doneOnNext)
            {
                buttons[id].active = false;
                buttons[id].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id].GetComponent<MeshRenderer>().material.color = Color.green;
                buttons[id].GetComponent<AudioSource>().Play();


                ActivateCircle(buttons[id]);

                if (id != buttons.Count - 1)
                {
                    buttons[id + 1].active = true;
                    buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
                    buttons[id + 1].GetComponent<MeshRenderer>().material.color = buttons[id + 1].GetComponent<ActiveColor>().m_activeColor;
                }
                // If the call was made by a doneOnNext button type
            }
            else if (buttons[id].doneOnNext)
            {
                buttons[id + 1].active = true;
                buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
                buttons[id + 1].GetComponent<MeshRenderer>().material.color = Color.yellow;
            }

        }
        else
        {
            if (!buttons[id].doneOnNext)
            {
                buttons[id].active = false;
                buttons[id].GetComponent<VRTK_InteractableObject>().enabled = false;
                buttons[id].GetComponent<MeshRenderer>().material.color = Color.green;
                buttons[id].GetComponent<AudioSource>().Play();


                ActivateCircle(buttons[id]);
            }

            if (id != buttons.Count - 1)
            {
                buttons[id + 1].active = true;
                buttons[id + 1].GetComponent<VRTK_InteractableObject>().enabled = true;
                buttons[id + 1].GetComponent<MeshRenderer>().material.color = buttons[id + 1].GetComponent<ActiveColor>().m_activeColor;
            }
        }
    }

    public void ActivateCircle(VRTK_Button button)
    {
        if (button.circleActivated != null)
        {
            startAnimRotation startAnim = button.circleActivated.GetComponent<startAnimRotation>();
            if (startAnim.firstCircle)
            {
                StartCoroutine(ActivateCircleCoroutine(3f, startAnim, 0));
                button.circleActivated.GetComponent<AudioSource>().PlayDelayed(3f);
            }
            else if (startAnim.secondCircle)
            {
                StartCoroutine(ActivateCircleCoroutine(3f, startAnim, 1));
                button.circleActivated.GetComponent<AudioSource>().PlayDelayed(3f);
            }
            else if (startAnim.thirdCircle)
            {
                StartCoroutine(ActivateCircleCoroutine(3f, startAnim, 2));
                button.circleActivated.GetComponent<AudioSource>().PlayDelayed(3f);
            }
        }
    }

    public IEnumerator ActivateCircleCoroutine(float timeToWait, startAnimRotation startanim, int id)
    {
        yield return new WaitForSeconds(timeToWait);
        switch (id)
        {
            case 0:
                startanim.ActivateFirstCircle = true;
                break;
            case 1:
                startanim.ActivateSecondCircle = true;
                break;
            case 2:
                startanim.ActivateThirdCircle = true;
                break;
        }
    }
}
