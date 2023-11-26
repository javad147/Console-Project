public class Group : BaseEntity
{
    public string Name { get; set; }
    public int Capacity { get; set; }

    public Group(int id, string name, int capacity)
    {
        ID = id;
        Name = name;
        Capacity = capacity;
    }
}
