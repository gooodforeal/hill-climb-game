using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Zombie : MonoBehaviour
{
    [SerializeField] private Animator _zombieAnim;
    [SerializeField] private GameObject _car;
    void Update()
    {
        if (_car.transform.position.x >= 212) {
            _zombieAnim.SetBool("Finish", true);
        }
        else {
            _zombieAnim.SetBool("Finish", false);
        }
    }
}
