using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float Speed = 3f;

	// Update is called once per frame
	void Update ()
    {
        // 매 프레임마다 메소드 호출
        Move();
	}

    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        if(Input.GetKey(KeyCode.RightArrow))  // → 방향키를 누를 때
            transform.Translate(Vector2.right * Speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftArrow))  // ← 방향키를 누를 때
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}
