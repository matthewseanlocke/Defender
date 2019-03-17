using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Defender.Managers;

namespace Defender.Objects
{
    [System.Serializable]
    public class Ball : MonoBehaviour
    {
        public GameObject target;

        public string ballName;
        public int ballSpeed;
        public int ballID;

        void Start()
        {
            ballSpeed = 10;
            RandomColor();
            MoveBall();

            //for (int i = 0; i < GameManager.Instance.allBallsArray.Length; i++)
            //{
            //    GameManager.Instance.allBallsArray[i] = new Ball(GameManager.Instance.colorNames[i], ballSpeed, i);
            //}
        }

        //Constructor
        public Ball(string name, int speed, int id)
        {
            this.ballName = name;
            this.ballSpeed = speed;
            this.ballID = id;
        }

        //Balls initial velocity
        public void MoveBall()
        {
            this.transform.LookAt(GameManager.Instance.target);
            this.GetComponent<Rigidbody>().velocity = transform.forward * GameManager.Instance.ballSpeed;
        }

        // Destorys object when it's no longer in the view on the camera and scene viewer
        void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        void RandomColor()
        {
            this.GetComponent<Renderer>().material.color = GameManager.Instance.colors[UnityEngine.Random.Range(0, GameManager.Instance.colors.Length)];
            //this.GetComponent<TrailRenderer>().startColor = this.GetComponent<Renderer>().material.color;  //trail color should be equal to the actual object color which is random

            GameManager.Instance.tempColor = this.GetComponent<Renderer>().material.color;

        }
    }
}
