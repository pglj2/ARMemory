/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;


namespace Vuforia
{
    
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public Text texto;

        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {

            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            a = 2;
            b = 2;
            c = 2;
            d = 2;
            texto.enabled = false;
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        public static int a = 0;
        public static int b = 0;
        public static int c = 0;
        public static int d = 0;
        public static int contador = 0;
        public static Text text;
        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(

                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
                if (mTrackableBehaviour.TrackableName == "coringa")
                {
                    a = a + 1;
                }
                if (mTrackableBehaviour.TrackableName == "Jdiamante")
                {
                    a = a + 1;
                }
                if (mTrackableBehaviour.TrackableName == "Kpreto")
                {
                    b = b + 1;
                }
                if (mTrackableBehaviour.TrackableName == "Kpau")
                {
                    b = b + 1;
                }
                if (mTrackableBehaviour.TrackableName == "Qpreto")
                {
                    c = c + 1;
                }
                if (mTrackableBehaviour.TrackableName == "Qpau")
                {
                    c = c + 1;
                }
                if (mTrackableBehaviour.TrackableName == "Kdiamante")
                {
                    d = d + 1;
                }
                if (mTrackableBehaviour.TrackableName == "Qdiamante")
                {
                    d = d + 1;
                }
                Debug.Log("a: " + a);
                Debug.Log("b: " + b);
                Debug.Log("c: " + c);
                Debug.Log("d: " + d);
                if (a == 2)
                {
                    texto.enabled = true;
                    texto.color = Color.red;
                    contador = contador + 1;
                }
                if (b == 2)
                {
                    texto.enabled = true;
                    texto.color = Color.white;
                    contador = contador + 1;
                }
                if (c == 2)
                {
                    texto.enabled = true;
                    texto.color = Color.black;
                    contador = contador + 1;
                }
                if (d == 2)
                {
                    texto.enabled = true;
                    texto.color = Color.blue;
                    contador = contador + 1;
                }

                if (contador == 4) {
                    texto.enabled = true;
                    texto.text = "Todas as cartas foram encontradas!";
                    texto.color = Color.white;
                    texto.fontSize = 50;

                }

                Debug.Log("contador: " + contador);
            }
            else
            {
                OnTrackingLost();
                if (mTrackableBehaviour.TrackableName == "coringa")
                {
                    a = a - 1;
                }
                if (mTrackableBehaviour.TrackableName == "Jdiamante")
                {
                    a = a - 1;
                }
                if (mTrackableBehaviour.TrackableName == "Kpreto")
                {
                    b = b - 1;
                }
                if (mTrackableBehaviour.TrackableName == "Kpau")
                {
                    b = b - 1;
                }
                if (mTrackableBehaviour.TrackableName == "Qpreto")
                {
                    c = c - 1;
                }
                if (mTrackableBehaviour.TrackableName == "Qpau")
                {
                    c = c - 1;
                }
                if (mTrackableBehaviour.TrackableName == "Kdiamante")
                {
                    d = d - 1;
                }
                if (mTrackableBehaviour.TrackableName == "Qdiamante")
                {
                    d = d - 1;
                }
                Debug.Log("a: " + a);
                Debug.Log("b: " + b);
                Debug.Log("c: " + c);
                Debug.Log("d:" + d);
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }

        #endregion // PRIVATE_METHODS
    }
}
