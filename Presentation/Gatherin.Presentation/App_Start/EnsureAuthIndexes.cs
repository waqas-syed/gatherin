using AspNet.Identity.MongoDB;

namespace Gatherin.Presentation
{
    /// <summary>
    /// Ensure the indexes are checked in MongoDB for users and roles
    /// </summary>
    public class EnsureAuthIndexes
    {
        /// <summary>
        /// Do indexes exist
        /// </summary>
        public static void Exist()
        {
            var context = ApplicationIdentityContext.Create();
            IndexChecks.EnsureUniqueIndexOnUserName(context.Users);
            IndexChecks.EnsureUniqueIndexOnRoleName(context.Roles);
        }
    }
}