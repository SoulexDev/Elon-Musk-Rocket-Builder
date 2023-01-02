using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public PlayerController controller;
    public bool canMove = true;
    private void Awake()
    {
        Instance = this;
    }
}