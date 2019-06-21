using System.Collections.Generic;
using System.Threading.Tasks;
using FeatureToggle.Models;
using Refit;

namespace FeatureToggle.Service
{
    public interface IGithubAPIService
    {
        [Get("/users/{user}/repos")]
        Task<List<Repository>> GetRepositories(string user);
    }
}