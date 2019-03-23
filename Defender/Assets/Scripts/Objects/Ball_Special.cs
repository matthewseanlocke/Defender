using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Defender.Managers;

namespace Defender.Objects
{
    [System.Serializable]
    public class Ball_Special : MonoBehaviour
    {
        public GameObject target;

        public int ballSpeed;

        void Start()
        {
            ballSpeed = 10;
            MoveBall();

            //for (int i = 0; i < GameManager.Instance.allBallsArray.Length; i++)
            //{
            //    GameManager.Instance.allBallsArray[i] = new Ball(GameManager.Instance.colorNames[i], ballSpeed, i);
            //}
        }

        //Balls initial velocity
        public void MoveBall()
        {
            this.transform.LookAt(GameManager.Instance.target);
            this.GetComponent<Rigidbody>().velocity = transform.forward * LoadManager.Instance.data.ballSpeed;
        }

        // Destorys object when it's no longer in the view on the camera and scene viewer
        public void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}
