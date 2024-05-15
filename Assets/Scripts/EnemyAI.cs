using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HillClimb.Utils;
using Unity.VisualScripting;
using System.Numerics;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamimgDistanceMin = 3f;
    [SerializeField] private float roamimgTimerMax = 2f;
    [SerializeField] private GameObject _player;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private UnityEngine.Vector3 roamPosition;
    private UnityEngine.Vector3 startingPosition;
    private UnityEngine.Vector3 directionOfTravel;
    private float _birdSpeed = 3.5f;
    


    private enum State {
        Roaming,
        Hunting
    }

    private void Awake() {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
    }


    private void Update() {
        //UnityEngine.Vector3 direction = _player.transform.position - transform.position;
        //if (UnityEngine.Vector3.Distance(_player.transform.position, transform.position) < 35f) {
           //state = State.Hunting;
       //}
        switch (state) {
            default:
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0) {
                    Roaming();
                    roamingTime = roamimgTimerMax;
                }
                Debug.Log(gameObject.name);
                break;
            case State.Hunting:
                navMeshAgent.SetDestination(_player.transform.position);
                break;
        }
    }

    private void Roaming() {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
        ChangeFacingDirection(startingPosition, roamPosition);
        navMeshAgent.SetDestination(roamPosition);
    }

    private UnityEngine.Vector3 GetRoamingPosition() {
        return startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamimgDistanceMin, roamingDistanceMax);
    }

    private void ChangeFacingDirection(UnityEngine.Vector3 sourcePosition, UnityEngine.Vector3 targetPosition) {
        if (sourcePosition.x > targetPosition.x) {
            transform.rotation = UnityEngine.Quaternion.Euler(0, -180, 0);
        } else {
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
        }
    }

}
