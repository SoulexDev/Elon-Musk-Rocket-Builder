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