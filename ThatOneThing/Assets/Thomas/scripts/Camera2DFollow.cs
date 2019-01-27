using System;
using UnityEngine;


    public class Camera2DFollow : MonoBehaviour
    {
        public Transform target;
        public float damping = 1;
 
        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
       

        // Use this for initialization
        private void Start()
        {
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        // Update is called once per frame
        private void Update()
        {
            
            Vector3 newPos = Vector3.SmoothDamp(transform.position,m_LastTargetPosition, ref m_CurrentVelocity, damping);

            transform.position = newPos + new Vector3 (0,0,m_OffsetZ);

            m_LastTargetPosition = target.position;
        }
    }

