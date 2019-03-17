using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Defender.Managers;

namespace Defender.Behaviors
{
    public class DestroyBallOnMatch : MonoBehaviour
    {
        void OnCollisionEnter(Collision col)
        {
            var myColor = this.gameObject.GetComponent<Renderer>().material.color;
            var otherColor = col.gameObject.GetComponent<Renderer>().material.color;

            if ((myColor == otherColor) && (col.gameObject.name != "Target"))
            {
                Destroy(gameObject, 0f);   //destory ball        
                CameraShake.Shake(0.2f, 0.5f); //change these values for more/less shake
                Handheld.Vibrate();
                //this.GetComponent<TrailRenderer>().startColor = this.GetComponent<Renderer>().material.color;  //trail color should be equal to the actual object color which is random
                
                //GameManager.Instance.tempColor = myColor; //text color
            }

            if (myColor != otherColor) 
            {
                Debug.Log("Ball Match");
                Destroy(gameObject, 0f);
                //GameManager.Instance.tempColor = myColor; //text color
            }
        }
    }
}
