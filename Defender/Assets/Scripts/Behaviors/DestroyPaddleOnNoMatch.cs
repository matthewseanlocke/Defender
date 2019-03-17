using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Defender.Managers;

namespace Defender.Behaviors
{
    public class DestroyPaddleOnNoMatch : MonoBehaviour
    {
        public Renderer rendTemp;
        public BoxCollider colliderTemp;

        public void Start()
        {
            rendTemp = this.gameObject.GetComponent<Renderer>();
            colliderTemp = this.gameObject.GetComponent<BoxCollider>();
        }

        void OnCollisionEnter(Collision col)
        {
            var myColor = this.gameObject.GetComponent<Renderer>().material.color;
            var otherColor = col.gameObject.GetComponent<Renderer>().material.color;

            if (myColor != otherColor) // && (col.gameObject.name != "Target"))
            {
                rendTemp.enabled = false;
                colliderTemp.enabled = false;
                
                CameraShake.Shake(0.25f, 0.5f); //change these values for more/less shake
                Handheld.Vibrate();
            }

            if (myColor == otherColor)
            {
                //Debug.Log("Paddle Match");
                GameManager.Instance.Matches++;
                Debug.Log(GameManager.Instance.Matches);
                //GameManager.Instance.tempColor = myColor;
            }

        }
    }
}
