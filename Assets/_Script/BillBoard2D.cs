using UnityEngine;

public class BillBoard2D : MonoBehaviour
{
    private Camera _mainCam;

    private void Start()
    {
        //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        _mainCam = Camera.main;
    }
    void LateUpdate()
    {
        if (_mainCam == null) return;

        Vector3 toCam =
    (_mainCam.transform.position - transform.position).normalized;

        // カメラが「かなり上」から見ているか？
        // Yが大きい = 上から見ている
        if (toCam.y > 0.99f)
        {
            // 回転させない（向き固定）
            return;
        }

        // ここから下は「見せていい角度」だけ回す
        Vector3 camPos = _mainCam.transform.position;
        camPos.y = transform.position.y;

        transform.LookAt(camPos);
        transform.Rotate(0f, 180f, 0f);
    }

}
