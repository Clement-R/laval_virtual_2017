namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class S_ButtonReactor : MonoBehaviour
    {
        public MeshRenderer m_ButtonDown;

        private VRTK_Button_UnityEvents buttonEvents;

        private void Start()
        {
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }

        private void handlePush(object sender, Control3DEventArgs e)
        {
            Debug.Log("Pushed");
            if(m_ButtonDown)
            {
                m_ButtonDown.material.color = Color.yellow;
                m_ButtonDown.GetComponent<VRTK_Button>().enabled = true;
            }
            GetComponent<VRTK_Button>().enabled = false;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}