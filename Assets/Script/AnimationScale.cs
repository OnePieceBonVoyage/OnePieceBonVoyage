public enum AnimationType
{
	WalkingLeft,
	WalkingRight,
	Jump,
	Dash,
	Crouch
}

public class AnimationScale
{
	public static void SetScale(AnimationType anim)
	{
		switch (anim)
		{
			case (AnimationType.WalkingLeft):
			break;

			case (AnimationType.WalkingRight):
			break;

			case (AnimationType.Jump):
			break;

			case (AnimationType.Dash):
			break;

			case (AnimationType.Crouch):
			break;
		}
	}
}
