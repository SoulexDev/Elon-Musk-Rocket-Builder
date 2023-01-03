using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    IGrabbable grabbable;
    [SerializeField] private Transform grabTransform;
    private ISocket socket;
    private ISource source;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootRay();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootConnectRay();
        }
    }
    void ShootRay()
    {
        bool rayReturned;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit hit, 4))
        {
            if (hit.transform.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
            rayReturned = true;
        }
        else
            rayReturned = false;

        if (grabbable == null)
        {
            if (rayReturned && hit.transform.TryGetComponent(out grabbable))
            {
                grabbable.Grab(grabTransform);
            }
        }
        else
        {
            grabbable.Drop();
            grabbable = null;
        }
    }
    void ShootConnectRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        if (Physics.Raycast(ray, out RaycastHit hit, 999))
        {
            hit.transform.TryGetComponent(out socket);
            hit.transform.TryGetComponent(out source);
        }
        if (socket != null && source != null)
        {
            socket.Plug(source);
            socket = null;
            source = null;
        }
    }
}