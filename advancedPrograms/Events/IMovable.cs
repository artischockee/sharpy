namespace Events
{
    internal interface IMovable
    {
        void MoveOnAxisX(float distance);
        void MoveOnAxisY(float distance);
        void MoveOnAxisZ(float distance);
    }
}