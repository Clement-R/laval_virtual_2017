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

            m_ButtonDown.material.color = Color.yellow;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}