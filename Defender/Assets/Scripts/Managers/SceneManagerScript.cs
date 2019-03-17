using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Defender.Managers
{
    public class SceneManagerScript : MonoBehaviour
    {
        public Text SceneText;
        public Text MatchInaRow;

        //public static SceneManagerScript _instance;

        //AudioSource sound_LevelUp;
        //AudioSource sound_ReloadLevel;
        //AudioSource sound_SpecialBall;

        public void Start()
        {
            SceneText.text = GameManager.Instance.Level.ToString();
            MatchInaRow.text = GameManager.Instance.Matches.ToString();

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
            MatchInaRow.text = GameManager.Instance.Matches.ToString(); 

            MatchInaRow.color = GameManager.Instance.tempColor;
            SceneText.color = GameManager.Instance.tempColor;

            if (GameManager.Instance.Matches >= GameManager.Instance.Level)
            {


                //for (int i = 0; i < GameManager.Instance.allBallsArray.Length; i++)
                //{
                //    GameManager.Instance.allBallsArray[i].gameObject.transform.localScale = new Vector3(0, 10F, 0);
                //}

                Scene scene = SceneManager.GetActiveScene();
                if (scene.name == "Main")
                {
                    GameManager.Instance.Level++;
                    GameManager.Instance.LoadSameLevel();
                    GameManager.Instance.specialBall = false;
                }
            }
        }
    }
}
