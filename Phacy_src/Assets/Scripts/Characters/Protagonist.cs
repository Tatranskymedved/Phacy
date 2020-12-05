using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Protagonist : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [Range(2, 10)]
    [SerializeField]
    private float speed = default;

    private Rigidbody2D _rb;
    private Vector2 _movementInput;

    void OnEnable()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _inputReader.moveEvent += OnMove;
    }

    private void OnDisable()
    {
        _inputReader.moveEvent -= OnMove;
    }

    private void OnMove(Vector2 movement)
    {
        _movementInput = movement;
    }

    void Update()
    {
        //TODO: check movement, if & how works
        if (_rb != null)
            _rb.velocity = _movementInput * Time.deltaTime * speed;

    }
}
