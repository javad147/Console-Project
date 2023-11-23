using System;
using System.Collections.Generic;
using System.Linq;

public class GroupServices
{
    private List<Group> groups = new List<Group>();

    public void CreateGroup(Group newGroup)
    {
        if (groups.Any(g => g.Name == newGroup.Name))
        {
            Console.WriteLine("A group with the same name already exists. Please choose a different name.");
            return;
        }

        groups.Add(newGroup);
        Console.WriteLine("Group successfully created. Group ID: " + newGroup.ID);
    }

    public void DeleteGroup(int groupId)
    {
        Group groupToDelete = groups.FirstOrDefault(g => g.ID == groupId);

        if (groupToDelete != null)
        {
            groups.Remove(groupToDelete);
            Console.WriteLine("Group successfully deleted.");
        }
        else
        {
            Console.WriteLine("Group with the specified ID not found.");
        }
    }

    public void EditGroup(int groupId)
    {
        Group groupToEdit = groups.FirstOrDefault(g => g.ID == groupId);

        if (groupToEdit != null)
        {
            Console.WriteLine("What would you like to edit? 1-Name, 2-Capacity, 0-Cancel");
            int editChoice;
            while (!int.TryParse(Console.ReadLine(), out editChoice) || (editChoice < 0 || editChoice > 2))
            {
                Console.WriteLine("Invalid input. Enter 1, 2, or 0:");
            }

            switch (editChoice)
            {
                case 1:
                    Console.WriteLine("Enter new Name:");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName))
                    {
                        groupToEdit.Name = newName;
                        Console.WriteLine("Name successfully updated.");
                    }
                    else
                    {
                        Console.WriteLine("Name cannot be empty. No changes made.");
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter new Capacity:");
                    int newCapacity;
                    while (!int.TryParse(Console.ReadLine(), out newCapacity))
                    {
                        Console.WriteLine("Invalid input. Enter a valid integer for Capacity:");
                    }
                    groupToEdit.Capacity = newCapacity;
                    Console.WriteLine("Capacity successfully updated.");
                    break;

                case 0:
                    Console.WriteLine("Edit operation cancelled.");
                    break;

                default:
                    Console.WriteLine("Invalid edit choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Group with the specified ID not found.");
        }
    }

    public Group GetById(int groupId)
    {
        return groups.FirstOrDefault(g => g.ID == groupId);
    }

    public List<Group> GetAllGroups()
    {
        return groups;
    }

    public List<Group> SearchGroups(string searchKeyword)
    {
        return groups.Where(g => g.ID.ToString().Contains(searchKeyword) || g.Name.Contains(searchKeyword)).ToList();
    }

    public List<Group> SortByCapacity()
    {
        return groups.OrderBy(g => g.Capacity).ToList();
    }

    public void DisplayCommandScreen()
    {
        Console.WriteLine("Group Operations: 1-Create, 2-Delete, 3-Edit, 4-GetById, 5-GetAll, 6-Search, 7-Sorting, 0-Exit");
    }
}
