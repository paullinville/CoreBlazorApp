using Midland.Core.Authorization;
using Midland.Core.Common;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Midland.Core.Tests")]
[assembly: InternalsVisibleTo("Midland.Core.User")]

namespace Midland.Core.User;

public class MidlandTokenUser : MidlandUser, IMidlandTokenUser
{
    public MidlandTokenUser(IMidlandUser values, TokenSubjectType subjectType) : base(values)
    {
        UserType = subjectType;
    }

    public MidlandTokenUser()
    { }

    internal MidlandTokenUser(TokenSubjectType subjectType)
    {
        UserType = subjectType;

        if (subjectType == TokenSubjectType.User) return;
        IsHuman = false;
        UserId = "";
        if (subjectType == TokenSubjectType.Unknown)
        {
            UserRef = -1;
        }
        else
        {
            UserRef = -1 * (int)UserType;
        }
    }

    public TokenSubjectType UserType { get; }
}