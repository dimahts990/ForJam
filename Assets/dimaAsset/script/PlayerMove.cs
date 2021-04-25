using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput _input;

    Animator anim;
    bool moveOn, torchOn;
    GrabTorch grabTorch;
    
    public float moveSpeed;
    public bool torchInChildReady;

    #region подключение системы ввода, метод Awake и Start
    private void Awake()
    {
        _input = new PlayerInput();
        _input.Player.Action.performed += context => Action();
        moveOn = true;
    }

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private void Start()
    {
        anim = GetComponent<Animator>();
        grabTorch = GetComponent<GrabTorch>();
    }
    #endregion

    private void Update()
    {
        if (moveOn)
        {
            Vector3 direction = new Vector3(_input.Player.Move.ReadValue<Vector2>().x, 0, _input.Player.Move.ReadValue<Vector2>().y);
            if (direction != Vector3.zero)
            {
                Move(direction);
            }
            else anim.SetBool("walk", false);
        }
    }

    private void Action()
    {
        if (!torchOn)
        {
            if (torchInChildReady)
            {
                moveOn = false;
                grabTorch.GrabTourchStart();
            }
        }
        else
        {
            //действия факела
        }
    }

    #region реализация передвижения игрока
    void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        anim.SetBool("walk", true);

        if (direction != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5 * Time.deltaTime);
    }
    #endregion

    public void ActivateMove()
    {
        moveOn = true;
        torchOn = true;
    }
}
