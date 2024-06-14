﻿using Domain.Entities;

namespace Application.Abstractions.RepositoryInterfaces;

public interface IDepartmentRepository
{
    public Task<Department> CreateAsync(Department department);
    
    public Task<Department> GetByIdAsync(int id);
    public Task<Department> UpdateAsync(Department department, int id);
}