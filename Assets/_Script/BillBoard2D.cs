using UnityEngine;

/// <summary>
/// 2Dスプライトをカメラに向けるビルボード（現在は木のみ）　のちのちに処理構造を見直す可能性あり
/// </summary>
public class BillBoard2D : MonoBehaviour
{
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }
    void LateUpdate()
    {

        if (_mainCam == null) return;
        Vector3 cameraPos = _mainCam.transform.position;
        Vector3 offsetPos = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z - 20);

        Vector3 toCam =
            (offsetPos - transform.position).normalized;

        // カメラが「かなり上」から見ているか？
        // Yが大きい = 上から見ている
        if (toCam.y > 0.999f)
        {
            // 回転させない（向き固定）
            return;
        }

        offsetPos.y = transform.position.y;
        
        transform.LookAt(offsetPos);
        transform.Rotate(0f, 180f, 0f);
        Vector3 euler = transform.rotation.eulerAngles;
        euler.x = 7f;              // X軸だけ変更
        transform.rotation = Quaternion.Euler(euler);
    }


}
