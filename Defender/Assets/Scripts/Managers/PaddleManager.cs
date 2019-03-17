using UnityEngine;

namespace Defender.Managers
{
    public class PaddleManager : MonoBehaviour
    {
        public static PaddleManager Instance { get; private set; }
        public GameObject Paddle;
        public GameObject[] racketArray = new GameObject[6];
        public int NumberOfPaddles { get; private set; }
        public float paddleRadius { get; set; }
        public Transform target;
        
        //private bool _isActive = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                //DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }            
        }

        private void Start()
        {
            NumberOfPaddles = 6;
            paddleRadius = 3;
            CreatePaddles(NumberOfPaddles);
        }

        public void CreatePaddles(int numberOfPaddles)
        {
            //this._isActive = true;

            for (int i = 0; i < racketArray.Length; i++)
            {
                float angle = i * Mathf.PI * 2 / GameManager.Instance.numberOfRackets;
                Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * paddleRadius;
                GameObject temp = Instantiate(Paddle, target.position + pos, Quaternion.identity);
                temp.transform.LookAt(GameManager.Instance.target);
                temp.GetComponent<Renderer>().material.color = GameManager.Instance.colors[i];
                temp.gameObject.name = GameManager.Instance.colorNames[i];
                racketArray[i] = temp; 
            }
        }
    }
}

