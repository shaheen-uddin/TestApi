using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();
}
