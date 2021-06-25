using UnityEngine;

public class Player_Time_Move : MonoBehaviour
{
    public float MoveSpeed;                     // 미사일이 날아가는 속도
    public float DestroyYPos;                   // 미사일이 사라지는 지점
    public float TimeSpeed;                     // 떨어지는 불꽃이 빨라지는 속도
    private float AccumulatedTime = 0f;         // 불꽃을 먹어서 누적된 시간
    public float CreateTimeSpeed;               // 불꽃이 생성되는 속도
    private float AccumulatedCreateTime = 0f;   // 불꽃을 생성해서 누적된 시간

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 불꽃이 MoveSpeed 만큼 down방향(Y축 -방향)으로 날라갑니다.
        transform.Translate(Vector2.down * MoveSpeed * Time.deltaTime);
        // 만약에 불꽃의 위치가 DestroyYPos를 넘어서면
        if (transform.position.y <= DestroyYPos)
            // 불꽃 제거
            GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 부딪히는 collision을 가진 객체의 태그가 "Player"일 경우
        if (collision.CompareTag("Player"))
        {
            AccumulatedTime += TimeSpeed;
            MoveSpeed += AccumulatedTime;
           
            AccumulatedCreateTime += CreateTimeSpeed;
            // Play User 태그를 사용하는 오브젝트의 첫번째에 있는 스크립트 변수에 접근
            GameObject.FindWithTag("Play User").GetComponent<Player_Fire>().FireDelay += AccumulatedCreateTime;

            Player_Score.countDown += 10f;
            Debug.Log("시간 추가: " + Player_Score.countDown);

            GetComponent<Collider2D>().enabled = false;
        }
    }
}
