namespace RollTheBall
{
    public class OnBallSelectCommand : GameEventBase
    {
        public EBallType BallType;

        public OnBallSelectCommand(EBallType ballType)
        {
            BallType = ballType;
        }
    }
}