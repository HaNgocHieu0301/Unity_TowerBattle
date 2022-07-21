using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    [SerializeField]
    private float minX, maxX;//dùng để hạn chế khi người chơi di chuyển đến hết bg

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //nếu nhân vật bị phá hủy hay k tồn tại thì return ngay
        //có thể để là if(player) hay if(!player) 
        if(player == null)
        {
            return;
        }
        tempPos = transform.position; //vị trí hiện tại của máy ảnh x,y,z -> lưu trữ vị trí hiện tại của cam
        tempPos.x = player.position.x; //set x của cam = toa do x cua player
        if(tempPos.x < minX)
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
        //khi camera di chuyển đến các giới hạn thì k di chuyển theo nhân vật nữa
        transform.position = tempPos; //gán ngược lại vị trí ban đầu của camera, lúc này cam sẽ có vị trí y,z như ban đầu và vị trí x lúc này đã đc lấy theo người chơi
    }
    //chuyển thành LateUpdate để được gọi sau cùng sau update, fixedupdate
}
