using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DriveCar : MonoBehaviour{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _rotationSpeed = 200f;
    [SerializeField] private float _speed = 120f;
    [SerializeField] public float accelerationSpeed = 30f;
    [SerializeField] public float maxSpeed = 240f;
    [SerializeField] private bool isAccelerating = false;
    private float _moveInput;
    [SerializeField] ParticleSystem thrust;
    [SerializeField] NitroSystem nitroSystem;
    private void Start() {
        nitroSystem = GetComponent<NitroSystem>();
    }
    private void Update(){
        
        if (Input.GetKeyDown(KeyCode.Space) && nitroSystem.GetNitro() > 0){
            nitroSystem.flag = true;
            isAccelerating = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            isAccelerating = false;
            _speed = 120f;
            nitroSystem.flag = false;
            nitroSystem.StartNitroRecover();
        }
        if (isAccelerating){
            StartThrusting();
            _speed += accelerationSpeed * Time.deltaTime;
            _speed = Mathf.Clamp(_speed, 0f, maxSpeed);
        }
        else {
            StopThrusting();
        }
        _moveInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate(){
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }
    private void StartThrusting(){
        if (thrust.isPlaying == false) {
            thrust.Play();
        }
    }

    private void StopThrusting(){
        thrust.Stop();
    }
}
