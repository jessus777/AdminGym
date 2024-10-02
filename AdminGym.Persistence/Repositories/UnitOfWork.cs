using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using AdminGym.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace AdminGym.Persistence.Repositories;
public class UnitOfWork
    : IUnitOfWork
{
    private readonly ApplicationDbEFContext _context;
    private IDbContextTransaction _transaction;
    public UnitOfWork(
        ApplicationDbEFContext context
        )
    {
        _context = context;
    }

    

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }
    }

    public void Dispose()
    {
        _context.Dispose();
        _transaction?.Dispose();
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
