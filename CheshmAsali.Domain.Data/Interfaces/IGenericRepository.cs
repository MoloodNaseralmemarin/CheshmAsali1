using CheshmAsali.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheshmAsali.Domain.Data.Interfaces
{
    public interface IGenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        void Dispose();
    }
}
