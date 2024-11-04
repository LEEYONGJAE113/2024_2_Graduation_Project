using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D _collider;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("ViewArea")) { return; }

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 thisPos = transform.position;

        switch(transform.tag)
        {
            case "Background":
                GroundRepos(playerPos, thisPos);
                break;
            case "Enemy":
                EnemyRepos(playerPos, thisPos);
                break;
        }

    }

    void GroundRepos(Vector3 playerPos, Vector3 myPos)
    {
        float gapX = playerPos.x - myPos.x;
        float gapY = playerPos.y - myPos.y;
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

    void EnemyRepos(Vector3 playerPos, Vector3 myPos)
    {
        if (_collider.enabled)
        {
            Vector3 dist = playerPos - myPos;

            Vector3 ran = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0f);
            transform.Translate(ran + dist * 2);
        }
    }
}
