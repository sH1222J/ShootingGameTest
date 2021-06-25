using UnityEngine;

public class Player_Missile_Move : MonoBehaviour
{
    public float MoveSpeed;     // 미사일이 날라가는 속도
    public float DestroyYPos;   // 미사일이 사라지는 지점

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 미사일이 MoveSpeed 만큼 down방향(Y축 +방향)으로 날라갑니다.
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        // 만약에 미사일의 위치가 DestroyYPos를 넘어서면
        if (transform.position.y <= DestroyYPos)
            // 미사일을 제거
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪히는 collision을 가진 객체의 태그가 "Player"일 경우
        if (collision.CompareTag("Player"))
        {
            Player_Score.countDown += 10f;
            Debug.Log("시간 추가: " + Player_Score.countDown);

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
