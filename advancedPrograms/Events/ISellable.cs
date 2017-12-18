namespace Events
{
    public interface ISellable
    {
        double Sell();
        object Pledge(); // отдать под залог
    }
}