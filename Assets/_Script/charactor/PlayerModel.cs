using UnityEngine;

/// <summary>
/// プレイヤーの情報を管理するモデルクラス(ピュア)
/// </summary>
public class PlayerModel
{
    /// <summary>/// プレイヤー移動速度を管理・設定するプロパティ/// </summary>
    public float MoveSpeed { get; set; }

    public float Gravity { get; set; }
    /// <summary>/// プレイヤーの現在の入力を管理・設定するプロパティ/// </summary>
    public Vector2 CurrentInput { get; set; }

    public PlayerModel(float moveSpeed, float gravity)
    {
        MoveSpeed = moveSpeed;
        Gravity = gravity;
    }
}
