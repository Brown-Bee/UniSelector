using UniSelector.DataAccess.Repository.IRepository;

public interface IApplicationRepository : IRepository<Application>
{

    void Update(Application application);
    void UpdateStatus(int id, string status, string? feedback);
    IEnumerable<Application> GetUserApplications(string userId);
    List<Application> GetUniversityApplications(string uniEmail);
}