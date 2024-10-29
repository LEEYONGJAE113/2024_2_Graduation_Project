using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("ViewArea")) { return; }

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 thisPos = transform.position;

        float gapX = playerPos.x - thisPos.x;
        float gapY = playerPos.y - thisPos.y;
        float dirX = gapX < 0 ? -1 : 1; // 플레이어가 왼쪽이면 음, 오른쪽이면 양
        float dirY = gapY < 0 ? -1 : 1;

        gapX = Mathf.Abs(gapX);
        gapY = Mathf.Abs(gapY);

        if ( gapX > gapY )
        {
            transform.Translate(Vector3.right * dirX * 40);
        }
        else if ( gapX < gapY )
        {
            transform.Translate(Vector3.up * dirY * 40);
        }
    }
}
