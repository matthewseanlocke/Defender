using System;
using UnityEngine;
using Defender.Objects;

namespace Defender.Managers
{
    public class BallManager : MonoBehaviour
    {
        public GameObject Ball;
        public Transform target;

        // Use this for initialization of all prefab generation
        void Start()
        {
            StoreBallsInArray();
            InvokeRepeating("InstantiateRandomBalls", 0.0f, 4.5f);
        }

        public void InstantiateRandomBalls()
        {
            float angle = UnityEngine.Random.Range(0, 100) * Mathf.PI * 2 / 15;
            Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * LoadManager.Instance.data.ballStartRadius;

            Instantiate(Ball, GameManager.Instance.target.position + pos, Quaternion.identity); //Level -1 because we start at Level 1 and the array starts at 0 

            //Ball.transform.LookAt(GameManager.Instance.target);
            //Ball.GetComponent<Rigidbody>().velocity = transform.forward;
        }

        public void StoreBallsInArray()
        {
            for (int i = 0; i < GameManager.Instance.allBallsArray.Length; i++)
            {
                GameManager.Instance.allBallsArray[i] = new GameObject (GameManager.Instance.colorNames[i]);
            }
        }
    }
}

