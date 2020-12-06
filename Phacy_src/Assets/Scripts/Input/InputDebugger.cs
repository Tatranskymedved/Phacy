using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputDebugger : MonoBehaviour
{
    public InputReader inputReader;
    public TMPro.TextMeshProUGUI textBox;

    void OnEnable()
    {
        inputReader.attackEvent += OnAttack;
        inputReader.cameraMoveEvent += OnCameraMove;
        inputReader.interactEvent += OnInteract;
        inputReader.jumpEvent += OnJump;
        inputReader.jumpCanceledEvent += OnJumpCancelled;
        inputReader.moveEvent += OnMove;
        inputReader.onConfirmSelectionEvent += OnConfirmSelection;
        inputReader.onCancelSelectionEvent += OnCancelSelection;
        inputReader.pauseEvent += OnPause;
    }

    void OnDisable()
    {
        inputReader.attackEvent -= OnAttack;
        inputReader.cameraMoveEvent -= OnCameraMove;
        inputReader.interactEvent -= OnInteract;
        inputReader.jumpEvent -= OnJump;
        inputReader.jumpCanceledEvent -= OnJumpCancelled;
        inputReader.moveEvent -= OnMove;
        inputReader.onConfirmSelectionEvent -= OnConfirmSelection;
        inputReader.onCancelSelectionEvent -= OnCancelSelection;
        inputReader.pauseEvent -= OnPause;
    }

    private void Show(string text)
    {
        textBox.text = text;
    }

    private void OnPause()
    {
        Show(nameof(OnPause));
    }

    private void OnCancelSelection()
    {
        Show(nameof(OnCancelSelection));
    }

    private void OnConfirmSelection()
    {
        Show(nameof(OnConfirmSelection));
    }

    private void OnMove(Vector2 arg0)
    {
        var onMove = nameof(OnMove) + ": " + arg0.ToString();
        Show(onMove);
    }

    private void OnJumpCancelled()
    {
        Show(nameof(OnJumpCancelled));
    }

    private void OnJump()
    {
        Show(nameof(OnJump));
    }

    private void OnInteract()
    {
        Show(nameof(OnInteract));
    }

    private void OnCameraMove(Vector2 arg0)
    {
        var onCameraMove = nameof(OnCameraMove) + ": " + arg0.ToString();
        //Show(onCameraMove);
    }

    private void OnAttack()
    {
        Show(nameof(OnAttack));
    }
}
