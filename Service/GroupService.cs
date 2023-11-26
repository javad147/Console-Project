using Service.Helpers.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
public class GroupService
{
    public List<Group> Groups { get; set; } = new List<Group>();
    public void CreateGroup()
    {
        Console.WriteLine(Message.GroupName);
        string name = Console.ReadLine();

      
        if (Groups.Any(g => g.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine($"Group with name '{name}' already exists. Cannot create duplicate groups.");
            return;
        }

        Console.WriteLine(Message.GroupCapacity);
        int capacity = Convert.ToInt32(Console.ReadLine());

        Group newGroup = new Group(Groups.Count + 1, name, capacity);
        Groups.Add(newGroup);

        Console.WriteLine(Message.GroupCapacityCreated);
    }
    public void DeleteGroup()
    {
        Console.WriteLine(Message.GroupDelete);
        string groupName = Console.ReadLine();

        Group groupToDelete = Groups.Find(g => g.Name == groupName);

        if (groupToDelete != null)
        {
            Groups.Remove(groupToDelete);
            Console.WriteLine(Message.GroupDeleteSuccessfull);
        }
        else
        {
            Console.WriteLine(Message.NotFoundGroup);
        }
    }
    public void EditGroup()
    {
        Console.WriteLine(Message.GroupEdit);
        string groupName = Console.ReadLine();

        Group groupToEdit = Groups.Find(g => g.Name == groupName);

        if (groupToEdit != null)
        {
            Console.WriteLine(Message.EnterGroupName);
            groupToEdit.Name = Console.ReadLine();

            Console.WriteLine(Message.GroupCapacityNew);
            groupToEdit.Capacity = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(Message.GroupEdited);
        }
        else
        {
            Console.WriteLine(Message.GroupNtFound);
        }
    }
    public void GetAllGroups()
    {
        foreach (var group in Groups)
        {
            Console.WriteLine($"Group ID: {group.ID}, Name: {group.Name}, Capacity: {group.Capacity}");
        }
    }
    public void SearchGroups()
    {
        Console.WriteLine(Message.GroupNameLetter);
        char firstLetter = Console.ReadKey().KeyChar;

        if (firstLetter == '\n')
        {
            Console.WriteLine("Please enter a valid character.");
            return;
        }

        Console.WriteLine();

        List<Group> searchResults = Groups
            .Where(g => g.Name.StartsWith(firstLetter.ToString(), StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (searchResults.Any())
        {
            foreach (var group in searchResults)
            {
                Console.WriteLine($"Group ID: {group.ID}, Name: {group.Name}, Capacity: {group.Capacity}");
            }
        }
        else
        {
            Console.WriteLine($"No groups found with names starting with the letter '{firstLetter}'.");
        }
    }
    public void SortingGroups()
    {
        Groups = Groups.OrderBy(g => g.Capacity).ToList();
        Console.WriteLine(Message.GroupSortCapacity);
        GetAllGroups();
    }
    public Group GetById()
    {
        Console.WriteLine(Message.GroupIdEnter);
        int groupId = Convert.ToInt32(Console.ReadLine());

        Group group = Groups.FirstOrDefault(g => g.ID == groupId);

        if (group != null)
        {
            Console.WriteLine($"Group ID: {group.ID}, Name: {group.Name}, Capacity: {group.Capacity}");
        }
        else
        {
            Console.WriteLine(Message.NewGroupNotFound);
        }

        return group;
    }
}
