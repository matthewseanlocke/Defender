using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine;

namespace Defender.Managers
{
    public class LoadManager : MonoBehaviour
    {
        //public static LoadManager instance;
        //Load Manager Instance
        public static LoadManager Instance { get; private set; }
        public Data data;

        //public int ballSpeed { get; set; }
        //public int Level { get; set; }
        //public int Matches { get; set; }
        //public int numberOfRackets { get; set; }
        //public float ballStartRadius { get; set; }
        //public bool specialBall;

        string dataFile = "data.dat";

        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                Instance = this;
            }
            else if (Instance != this)
                Destroy(this.gameObject);
        }

        public void Start()
        {


            Load();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S)) Save();
            if (Input.GetKeyDown(KeyCode.L)) Load();

        }

        public void Save()
        {
            string filePath = Application.persistentDataPath + "/" + dataFile;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(filePath);
            bf.Serialize(file, data);
            file.Close();

            Debug.Log("Saved Data");
        }

        public void Load()
        {
            string filePath = Application.persistentDataPath + "/" + dataFile;
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                FileStream file = File.Open(filePath, FileMode.Open);
                Data loaded = (Data)bf.Deserialize(file);
                data = loaded;
                file.Close();

                Debug.Log("Load Data");

            }
        }
    }
}
[System.Serializable]
public class Data
{
    public int ballSpeed = 5;
    public int Level = 1;
    public int Matches = 0;
    public int numberOfRackets = 6;
    public float ballStartRadius = 25;
    public bool specialBall = false;
}