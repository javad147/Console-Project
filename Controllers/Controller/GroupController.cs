using System;


    public class GroupController
{
    private GroupServices groupServices;
    public GroupController(GroupServices services)
    {
        groupServices = services;
    }

    private List<Group> groups = new List<Group>();
    public void StartApplication()
    {
        int operation;
        do
        {
            groupServices.DisplayCommandScreen();
            string operationInput = Console.ReadLine();

            if (!int.TryParse(operationInput, out operation))
            {
                Console.WriteLine("Invalid input. Please enter a valid operation number.");
                continue;
            }

            switch (operation)
            {
                case 1:
                    Console.WriteLine("Enter Group Name:");
                    string groupName = Console.ReadLine();

                    Console.WriteLine("Enter Group Capacity:");
                    int groupCapacity;
                    while (!int.TryParse(Console.ReadLine(), out groupCapacity))
                    {
                        Console.WriteLine("Invalid input. Enter a valid integer for Capacity:");
                    }

                    Group newGroup = new Group { Name = groupName, Capacity = groupCapacity };
                    groupServices.CreateGroup(newGroup);
                    break;

                case 2:
                    Console.WriteLine("Enter Group ID to delete:");
                    int groupIdToDelete;
                    while (!int.TryParse(Console.ReadLine(), out groupIdToDelete))
                    {
                        Console.WriteLine("Invalid input. Enter a valid integer for Group ID:");
                    }
                    groupServices.DeleteGroup(groupIdToDelete);
                    break;

                case 3:
                    Console.WriteLine("Enter Group ID to edit:");
                    int groupIdToEdit;
                    while (!int.TryParse(Console.ReadLine(), out groupIdToEdit))
                    {
                        Console.WriteLine("Invalid input. Enter a valid integer for Group ID:");
                    }
                    groupServices.EditGroup(groupIdToEdit);
                    break;

                case 4:
                    Console.WriteLine("Enter Group ID to get:");
                    int groupIdToGet;
                    while (!int.TryParse(Console.ReadLine(), out groupIdToGet))
                    {
                        Console.WriteLine("Invalid input. Enter a valid integer for Group ID:");
                    }
                    Group groupById = groupServices.GetById(groupIdToGet);
                    Console.WriteLine($"Group ID: {groupById.ID}, Name: {groupById.Name}, Capacity: {groupById.Capacity}");
                    break;

                case 5:
                    var allGroups = groupServices.GetAllGroups();
                    foreach (var group in allGroups)
                    {
                        Console.WriteLine($"Group ID: {group.ID}, Name: {group.Name}, Capacity: {group.Capacity}");
                    }
                    break;

                case 6:
                    Console.WriteLine("Enter search keyword:");
                    string searchKeyword = Console.ReadLine();
                    var searchResults = groupServices.SearchGroups(searchKeyword);
                    foreach (var group in searchResults)
                    {
                        Console.WriteLine($"Group ID: {group.ID}, Name: {group.Name}, Capacity: {group.Capacity}");
                    }
                    break;

                case 7:
                    var sortedGroups = groupServices.SortByCapacity();
                    foreach (var group in sortedGroups)
                    {
                        Console.WriteLine($"Group ID: {group.ID}, Name: {group.Name}, Capacity: {group.Capacity}");
                    }
                    break;

                case 0:
                    Console.WriteLine("Exiting the application.");
                    break;

                default:
                    Console.WriteLine("Invalid operation number. Please try again.");
                    break;
            }
        } while (operation != 0);
    }

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

