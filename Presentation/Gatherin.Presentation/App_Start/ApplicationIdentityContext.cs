using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Identity.MongoDB;
using Gatherin.Common;
using Gatherin.Presentation.Models;
using MongoDB.Driver;

namespace Gatherin.Presentation
{
    /// <summary>
    /// DbContext for MongoDB
    /// </summary>
    public class ApplicationIdentityContext : IDisposable
    {
        /// <summary>
        /// Create the MongoDB connection and DbContext
        /// </summary>
        /// <returns></returns>
        public static ApplicationIdentityContext Create()
        {
            var client = new MongoClient(Constants.MongoServer);
            var database = client.GetDatabase(Constants.MongoDatabase);
            var users = database.GetCollection<ApplicationUser>("users");
            var roles = database.GetCollection<IdentityRole>("roles");
            return new ApplicationIdentityContext(users, roles);
        }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="users"></param>
        /// <param name="roles"></param>
        private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
        {
            Users = users;
            Roles = roles;
        }

        /// <summary>
        /// Roles
        /// </summary>
        public IMongoCollection<IdentityRole> Roles { get; set; }

        /// <summary>
        /// Users
        /// </summary>
        public IMongoCollection<ApplicationUser> Users { get; set; }

        /// <summary>
        /// Return all roles
        /// </summary>
        /// <returns></returns>
        public Task<List<IdentityRole>> AllRolesAsync()
        {
            return Roles.Find(r => true).ToListAsync();
        }

        /// <summary>
        /// Dispose off the resources
        /// </summary>
        public void Dispose()
        {
        }
    }
}