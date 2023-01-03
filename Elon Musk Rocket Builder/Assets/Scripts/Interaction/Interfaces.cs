using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Interact();
}
public interface IGrabbable
{
    public void Grab(Transform followTransform);
    public void Drop();
}
public interface ISocket
{
    public void Plug(ISource source);
}
public interface ISource
{
    public bool IsPowered();
}