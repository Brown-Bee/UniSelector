namespace UniSelector.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUniversityRepository University { get; }
        IFacultyRepository Faculty { get; }
        IStandardFacultyRepository StandardFaculty { get; }
        IStandardMajorRepository StandardMajor { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IStudentRequestRepository StudentRequest { get; }
        IMajorRepository Major { get; }
        void Save();
    }
}
