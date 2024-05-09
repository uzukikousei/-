using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;

    private Vector3 temPos;

    [SerializeField]
    private float minX = -86, maxX = 86;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //玩家死亡后返回
        if (!player)
            return;

        temPos = transform.position;
        temPos.x = player.position.x;
        
        // 场景边界值
        if(temPos.x < minX)
        {
            temPos.x = minX;
        }else if (temPos.x > maxX)
        {
            temPos.x = maxX;
        }

        //镜头跟随
        transform.position = temPos;
        
    }
}
