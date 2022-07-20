using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed; //ẩn với inspector tab nhưng có thể thay đổi truy cập bằng các script khác
    private Rigidbody2D myBody;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        //speed = 7;
        //để speed tạm thời cho ghost -> sau khi tao spawner thì xóa đi
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(speed, myBody.velocity.y); 
        //vận tốc tuyến tính tính theo đơn vị mỗi giây 
        //thêm speed value vào x velocity cái sẽ đẩy player sang trái và phải
        //k thay đổi y do di chuyển trên một đường thằng 
        //-> move enemy
    }
}
