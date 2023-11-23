using System;

public class GroupController
{
    private GroupServices groupServices;

    public GroupController(GroupServices services)
    {
        groupServices = services;
    }

    public void StartApplication()
    {
        int operation;
        do
        {
            groupServices.DisplayCommandScreen();
            operation = int.Parse(Console.ReadLine());

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
}


