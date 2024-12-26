using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ActionBasedController _controller;

    private void OnEnable() {
        _controller.selectActionValue.action.performed += SelectPerformed;
        _controller.selectActionValue.action.canceled += SelectPerformed;
    }

    private void OnDisable() {
        _controller.selectActionValue.action.performed -= SelectPerformed;
        _controller.selectActionValue.action.canceled -= SelectPerformed;
    }

    private void SelectPerformed(InputAction.CallbackContext context) {
        _animator.SetFloat("Blend", context.ReadValue<float>());
    }
}