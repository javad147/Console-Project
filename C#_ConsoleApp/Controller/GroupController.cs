public class GroupController
{
    private GroupService groupService;

    public GroupController(GroupService groupService)
    {
        this.groupService = groupService;
    }

    public void CreateGroup()
    {
        groupService.CreateGroup();
    }

    public void DeleteGroup()
    {
        groupService.DeleteGroup();
    }

    public void EditGroup()
    {
        groupService.EditGroup();
    }

    public void GetAllGroups()
    {
        groupService.GetAllGroups();
    }

    public void SearchGroups()
    {
        groupService.SearchGroups();
    }

    public void SortingGroups()
    {
        groupService.SortingGroups();
    }

    public void GetById()
    {
        groupService.GetById();
    }
}
