using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Enter new Name (leave empty to keep the current value):");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                groupToEdit.Name = newName;
                Console.WriteLine("Name successfully updated.");
            }

            Console.WriteLine("Enter new Capacity (leave empty to keep the current value):");
            string capacityInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(capacityInput) && int.TryParse(capacityInput, out int newCapacity))
            {
                groupToEdit.Capacity = newCapacity;
                Console.WriteLine("Capacity successfully updated.");
            }

            Console.WriteLine("Group successfully edited.");
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


