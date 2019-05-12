using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak
{
    public class CharacterInput : MonoBehaviour
    {
        Vector3 inputDir;
        public Vector3 InputDir
        {
            get
            {
                return inputDir;
            }
        }

        Vector3 lookAtPoint;
        public Vector3 LookAtPoint
        {
            get
            {
                return lookAtPoint;
            }
        }

        //ray casting
        Camera playerView;

        private void Awake()
        {
            playerView = Camera.main;
        }

        void Start()
        {

        }

        void Update()
        {
            //input is done here to ensure no input lag
            MovementInput();
            LookInput();
        }

        void MovementInput()
        {
            //normalize the input dir so that it is moving in any direction equally
            inputDir = new Vector3(
                Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")
                ).normalized;
        }

        void LookInput()
        {
            //create a ray from the camera that goes through the mouse position to infinity
            Ray ray = playerView.ScreenPointToRay(Input.mousePosition);

            //create a plane for plane to intersect with
            Plane ground = new Plane(Vector3.up, Vector3.zero);

            //stores ray distance when ray intersects the plane
            float rayDist;

            //check if ray intersects with ground
            if (ground.Raycast(ray, out rayDist))
            {
                //get point of intersection using ray distance
                Vector3 intersectPoint = ray.GetPoint(rayDist);
                //Debug.DrawLine(ray.origin, intersectPoint, Color.red);
                lookAtPoint = intersectPoint;
            }
        }
    }
}