using Midland.Core.Authorization;

namespace Midland.Core.Common;

public interface IMidlandTokenUser : IMidlandUser
{
	TokenSubjectType UserType { get; }

	public string Identifier()
	{
		if (UserType == TokenSubjectType.User)
		{
			return UserRef.ToString();
		}
		else if (UserType == TokenSubjectType.Api)
		{
			return FullName;
		}
		else if (UserType == TokenSubjectType.Service)
		{
			return FullName;
		}
		return UserRef.ToString();
	}
}