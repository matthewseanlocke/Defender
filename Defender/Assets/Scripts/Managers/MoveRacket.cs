using UnityEngine;
using System.Collections;

namespace Defender.Managers
{
    public class MoveRacket : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            // Rotate Left        
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 position = this.transform.position;
                this.transform.RotateAround(Vector3.zero, Vector3.forward, 10);
            }

            // Rotate Right        
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 position = this.transform.position;
                this.transform.RotateAround(Vector3.zero, Vector3.back, 10);
            }

            transform.LookAt(Vector3.zero);
        }

        void FixedUpdate()
        {
            // TOUCH ***************************************************************************

            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            //{
            // Get movement of the finger since last frame
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Move object across XYZ plane --> coordinates x=0,y=1,z=0
            //transform.Translate(0, touchDeltaPosition.y * speed, 0);

            //}
            // ***********************************************************************************

            // Accelorometer *********************************************************************
            //transform.Translate(Mathf.Sin(Input.acceleration.x)* speed, Mathf.Cos(Input.acceleration.x)* speed, 0);

            // Rotate
            //transform.RotateAround(Target.transform.position, Vector3.forward, speed * Time.deltaTime);

            //transform.RotateAround(Target.transform.position, Vector3.forward, speed * Input.acceleration.x);

            transform.RotateAround(Vector3.zero, Vector3.forward, speed * Input.acceleration.x);
            //transform.RotateAround(Vector3.zero, Vector3.forward, speed * Input.acceleration.y);

            // ***********************************************************************************
        }
    }
}
