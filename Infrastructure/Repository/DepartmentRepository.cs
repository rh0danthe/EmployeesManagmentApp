﻿using Application.Abstractions.FactoryInterfaces;
using Application.Abstractions.RepositoryInterfaces;
using Dapper;
using Domain.Entities;

namespace Infrastructure.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnectionFactory _factory;

    public DepartmentRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }
    
    public async Task<Department> CreateAsync(Department department)
    {
        using var connection = await _factory.CreateAsync();
        var query = "INSERT INTO \"Departments\" (\"Name\", \"Phone\", \"CompanyId\") VALUES(@Name, @Phone, @CompanyId) RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<Department>(query, department);
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        using var connection = await _factory.CreateAsync();
        string query = "SELECT * FROM \"Departments\" WHERE \"Id\" = @Id";
        return await connection.QueryFirstOrDefaultAsync<Department>(query, new {Id = id});
    }

    public async Task<Department> UpdateAsync(Department department, int id)
    {
        using var connection = await _factory.CreateAsync();
        var query =
            "UPDATE \"Departments\" SET \"Name\" = @Name, \"Phone\" = @Phone, \"CompanyId\" = @CompanyId WHERE \"Id\" = @Id RETURNING *";
        return await connection.QueryFirstOrDefaultAsync<Department>(query, new { Id = id });
    }
}