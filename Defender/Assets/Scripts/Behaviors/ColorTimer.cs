using UnityEngine;
using System.Collections;
using Defender.Managers;

namespace Defender.Behaviors
{
    public class RandomColorTimer : MonoBehaviour
    {
        void Start()
        {
            InvokeRepeating("RandomColor", 0f, 0.05f);
        }

        void RandomColor()
        {
            this.GetComponent<Renderer>().material.color = GameManager.Instance.colors[Random.Range(0, GameManager.Instance.colors.Length)];
        }
    }
}
