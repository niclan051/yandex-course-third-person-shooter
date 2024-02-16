using UnityEngine;

public static class AnimationConstants
{
    public static readonly int TriggerJump = Animator.StringToHash("Jump"); // am fast
    public static readonly int BoolFalling = Animator.StringToHash("Falling");
    public static readonly int FloatInputVertical = Animator.StringToHash("Input Vertical");
    public static readonly int FloatInputHorizontal = Animator.StringToHash("Input Horizontal");
    public static readonly int BoolOnGround = Animator.StringToHash("On Ground");
    public static readonly int BoolInputVerticalZero = Animator.StringToHash("Input Vertical Zero");
    public static readonly int BoolInputHorizontalZero = Animator.StringToHash("Input Horizontal Zero");
}