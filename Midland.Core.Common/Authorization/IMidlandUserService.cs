using Midland.Core.Common;

namespace Midland.Core.User
{
    public interface IMidlandUserService
    {
        /// <summary>
        /// this will not always return an employee because APIs will not always be called by users.
        /// (think services) If it is not an employee the UserRef of the IMidlandUser returned will
        /// be null and IsHuman will be false.
        /// </summary>
        IMidlandTokenUser CurrentUser { get; }

        List<string> Actions();

        string AllClaims();

        List<string> ClaimValue(string claimName);

        IReadOnlyCollection<IMidlandUser> GetActiveUsers();

        IMidlandUser GetUser(int userRef);

        IReadOnlyCollection<IMidlandUser> GetUsers();

        bool HasAction(string actionName);

        bool HasApplicationPermission();

        bool HasClaim(string claimType, string claimName, bool ignoreValueCase = false);
    }
}