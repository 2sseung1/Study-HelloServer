using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviourPun
{
    [SerializeField]
    private float moveSpeed;

    private float _inputX = 0f;
    private float _inputY = 0f;

    void Awake()
    {

    }

    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }

        _inputX = 0f;
        _inputY = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _inputX = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _inputX = 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _inputY = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _inputY = -1;
        }

        Move();
    }

    private void Move()
    {
        float movePositionX = _inputX * moveSpeed * Time.deltaTime;
        float movePositionZ = _inputY * moveSpeed * Time.deltaTime;
        Vector3 newPosition = new Vector3(movePositionX, 0f, movePositionZ);
        transform.position += newPosition;
    }
}