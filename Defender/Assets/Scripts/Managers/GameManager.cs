using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

using Defender.Objects;

namespace Defender.Managers
{
    public class GameManager : MonoBehaviour
    {
        //Manager Instance
        public static GameManager Instance { get; private set; }

        public Transform target;

        //Private variables should have an underscore before the name _example
        //Properties names are PascalCase 
        public int Level { get; set; }
        public int ballSpeed { get; set; }
        public int Matches { get; set; }
        public int numberOfRackets { get; set; }
        public float ballStartRadius { get; set; }

        public Color32 tempColor;
        
        //public Text SceneText;
        //public Text MatchInaRow;

        public Color32[] colors = new Color32[6];
        public string[] colorNames = new string[6];

        //public GameObject[] racketArray = new GameObject[6];

        public GameObject[] allBallsArray = new GameObject[6];
        //public Ball[] allBallsArray = new Ball[6]; // I need this array here, because I can't attach it to the Balls because they get destroyed

        public bool specialBall;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            //initialize global variables
            ballSpeed = 5;
            Level = 1;
            Matches = 0;
            numberOfRackets = 6;
            ballStartRadius = 25;
            specialBall = false;

            tempColor = new Color32(255,255,255,255);

            //Colors we are using
            colors[0] = new Color32(255, 0, 0, 255);
            colors[1] = new Color32(0, 255, 0, 255);
            colors[2] = new Color32(0, 0, 255, 255);
            colors[3] = new Color32(255, 255, 0, 255);
            colors[4] = new Color32(0, 255, 255, 255);
            colors[5] = new Color32(255, 0, 255, 255);

            //Color Names we are using
            colorNames[0] = "Red";
            colorNames[1] = "Green";
            colorNames[2] = "Blue";
            colorNames[3] = "Yellow";
            colorNames[4] = "Sky";
            colorNames[5] = "Pink";

            // Keep the screen locked in Portrait
            Screen.orientation = ScreenOrientation.Landscape;
        }

        public void Update()
        {
            this.GetComponent<Renderer>().material.color = tempColor; // Set Target color equal to next ball
        }

        public void OnCollisionEnter(Collision col)
        {
            LoadSameLevel();
        }

        public void LoadSameLevel()
        {
            SceneManager.LoadScene("Main");
            GameManager.Instance.Matches = 0;
            GameManager.Instance.specialBall = false;
            // you can also write the following line to reload the level
            //Application.LoadLevel(Application.loadedLevel);
        }

        public void LoadNextLevel()
        {
            GameManager.Instance.ballSpeed += 1;
            SceneManager.LoadScene("Main");
            GameManager.Instance.Matches = 0;
            GameManager.Instance.specialBall = false;
        }
    }
}
