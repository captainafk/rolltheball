namespace RollTheBall
{
    public class OnGroundSelectCommand : GameEventBase
    {
        public EGroundType GroundType;

        public OnGroundSelectCommand(EGroundType groundType)
        {
            GroundType = groundType;
        }
    }
}