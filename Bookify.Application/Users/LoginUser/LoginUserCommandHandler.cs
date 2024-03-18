using Bookify.Application.Abstraction.Authentication;
using Bookify.Application.Abstraction.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users;

namespace Bookify.Application.Users.LoginUser
{
    internal sealed class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, AccessTokenResponse>
    {
        private readonly IJwtService _jwtSevice;

        public LoginUserCommandHandler(IJwtService jwtSevice)
            => _jwtSevice = jwtSevice;

        public async Task<Result<AccessTokenResponse>> Handle(
            LoginUserCommand request, 
            CancellationToken cancellationToken)
        {
            var result = await _jwtSevice.GetAccessTokenAsync(
                request.Email,
                request.Password,
                cancellationToken);

            if ( result.IsFailure)
                return Result.Failure<AccessTokenResponse>(UserErrors.InvalidCredentials);

            return new AccessTokenResponse(result.Value);
        }
    }
}
