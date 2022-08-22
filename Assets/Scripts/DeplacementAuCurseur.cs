using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAuCurseur : MonoBehaviour
{

    [SerializeField] Texture2D icon_move;
    [SerializeField] Texture2D icon_resize;

    bool move = false;
    bool resize = false;
    Transform activeAreaEffector = null;
    Vector2 radiusOffset;
    float updateMousePos;
    float offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) && move)
        {
            ForceManager typeDeMouv = activeAreaEffector.GetComponent<ForceManager>();
            if (typeDeMouv.yType == true)
            {
                activeAreaEffector.position = new Vector3(activeAreaEffector.transform.position.x, worldMousePos.y, 0); // worldMousePos.y, 0);
            }
            else if (typeDeMouv.xType == true)
            {
                activeAreaEffector.position = new Vector3(worldMousePos.x, activeAreaEffector.transform.position.y, 0); // worldMousePos.y, 0);
            }
            else    activeAreaEffector.position = new Vector3(worldMousePos.x, worldMousePos.y, 0);

        }
        if (Input.GetMouseButtonDown(0) && resize)
        {
            radiusOffset = worldMousePos - new Vector2(activeAreaEffector.position.x, activeAreaEffector.position.y);
            offset = activeAreaEffector.GetComponent<CircleShape>().Radius - radiusOffset.magnitude;
        }
        if (Input.GetMouseButton(0) && resize)
        {
            updateMousePos = (worldMousePos - new Vector2(activeAreaEffector.position.x, activeAreaEffector.position.y)).magnitude;
            if (updateMousePos + offset < 3f || updateMousePos + offset >= 10f) return;
            else activeAreaEffector.GetComponent<CircleShape>().Radius = updateMousePos + offset;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hitRay = Physics2D.GetRayIntersection(ray, 11f);
        GameObject objetPointe;

        if (hitRay.collider != null && hitRay.collider.gameObject.tag != "NonModifiableAreaEff2D")
        {
            objetPointe = hitRay.transform.gameObject;

            if (objetPointe.name == "CercleInt" && !Input.GetMouseButton(0))
            {
                Cursor.SetCursor(icon_move, new Vector2(16, 16), CursorMode.Auto);
                activeAreaEffector = hitRay.transform.parent.transform;
                move = true;
                resize = false;
            }
            else if (objetPointe.CompareTag("AreaEffectors2D") && !Input.GetMouseButton(0))
            {
                Cursor.SetCursor(icon_resize, new Vector2(16, 16), CursorMode.Auto);
                activeAreaEffector = hitRay.transform;
                resize = true;
                move = false;
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            activeAreaEffector = null;
            move = false;
            resize = false;
        }

    }
}
