using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;

namespace Defender.Managers
{
    public class SceneManagerScript : MonoBehaviour
    {
        public TextMeshProUGUI SceneText;
        public TextMeshProUGUI MatchInaRow;

        //public Text SceneText;
        //public Text MatchInaRow;

        //public static SceneManagerScript _instance;

        //AudioSource sound_LevelUp;
        //AudioSource sound_ReloadLevel;
        //AudioSource sound_SpecialBall;

        public void Start()
        {

            //TextMeshProUGUI m_SceneText = gameObject.GetComponent<TextMeshProUGUI>();
            //TextMeshProUGUI m_MatchInaRow = gameObject.GetComponent<TextMeshProUGUI>();

            SceneText.text = LoadManager.Instance.data.Level.ToString();
            MatchInaRow.text = LoadManager.Instance.data.Matches.ToString();

            //SceneText.text = LoadManager.Instance.data.Level.ToString();
            //MatchInaRow.text = LoadManager.Instance.data.Matches.ToString();

            //SceneText = GetComponent<TextMeshProUGUI>();
            //MatchInaRow = GetComponent<TextMeshProUGUI>();

            //SceneText.color = new Color32(255, 255, 255, 255);
            //MatchInaRow.color = new Color32(255, 255, 255, 255);

            //AudioSource[] audios = GetComponents<AudioSource>();
            //sound_LevelUp = audios[0];
            //sound_ReloadLevel = audios[1];
            //sound_SpecialBall = audios[2];

            CameraShake.Shake(0.25f, 4f);
            Handheld.Vibrate();

            //sound_LevelUp.Play();
        }

        public void Update()
        {
            MatchInaRow.text = LoadManager.Instance.data.Matches.ToString(); 

            MatchInaRow.color = GameManager.Instance.tempColor;
            SceneText.color = GameManager.Instance.tempColor;

            if (LoadManager.Instance.data.Matches >= LoadManager.Instance.data.Level)
            {


                //for (int i = 0; i < GameManager.Instance.allBallsArray.Length; i++)
                //{
                //    GameManager.Instance.allBallsArray[i].gameObject.transform.localScale = new Vector3(0, 10F, 0);
                //}

                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "Main")
                {
                    LoadManager.Instance.data.Level++;
                    GameManager.Instance.LoadSameLevel();
                    LoadManager.Instance.data.specialBall = false;
                }
            }
        }
    }
}
