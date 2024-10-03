﻿namespace UniSelector.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IUniversityRepository University { get; }
        IFacultyRepository Faculty { get; }
        IStandardFacultyRepository StandardFaculty { get; }
        void Save();
    }
}
