using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public PlayerController controller;
    public bool canMove = false;
    private void Awake()
    {
        Instance = this;
        canMove = false;
    }
    public void SetPlayerMoveState(bool state)
    {
        canMove = state;
    }
}