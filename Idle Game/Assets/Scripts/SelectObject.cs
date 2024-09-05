using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectObject : MonoBehaviour
{
    public static SelectObject instance;
    public Camera cam;

    [SerializeField] private LayerMask mask;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 20f, mask))
        {

            if (hit.transform.gameObject.GetComponent<Clickable>() != null)
            {
                Clickable click = hit.transform.gameObject.GetComponent<Clickable>();

                if (Input.GetMouseButtonDown(0))
                {
                    click.Click();

                }

            }
        }

    }
}
