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
        public static LoadManager instance;
        public Data data;

        string dataFile = "data.dat";

        void Awake()
        {
            if (instance == null)
            {
                DontDestroyOnLoad(this.gameObject);
                instance = this;
            }
            else if (instance != this)
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
    public int test = 0;
}