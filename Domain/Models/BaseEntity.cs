public abstract class BaseEntity
{
    private static int counter = 0;

    public int ID { get; }

    public BaseEntity()
    {
        this.ID = ++counter;
    }
}