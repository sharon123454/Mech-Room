using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.InputSystem.iOS;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _animationTweaker = 1;

    private void Start()
    {
        Controller.Instance.Interact.started += Controller_Interact;
    }

    void Update()
    {
        Vector3 cache = Controller.Instance.GetMoveDirection(transform) * _speed * Time.deltaTime;
        transform.Translate(cache);
        _animator.SetFloat("Speed", cache.magnitude * _animationTweaker);
    }

    private void Controller_Interact(InputAction.CallbackContext context)
    {
        _animator.SetTrigger("PickUp");
    }

}