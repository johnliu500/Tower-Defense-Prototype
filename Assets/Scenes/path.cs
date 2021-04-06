    // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class path : MonoBehaviour {

        public GameObject[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;

        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;


            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;
            if (destPoint>=points.Length){
                Destroy(gameObject);
                return;
            }

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].transform.position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1);
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            //if (agent.position == goal.position){
            //    Destroy(gameObject);
             //   return;
            //}
            if (!agent.pathPending && agent.remainingDistance < 0.5f){
                GotoNextPoint();
            }
        }
    }
