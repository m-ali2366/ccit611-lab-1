using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Backend.Service.Common.Views;
using Backend.Service.Features.Authentication.Login.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Configurations.Jwt;
using System;

namespace Backend.Service.Features.Authentication.Login.Commands
{
    public record LoginOrchestrator(string UserName, string Password) : IRequest<Result<LoginResult,Error>>;
    public class LoginOrchestratorHandler : IRequestHandler<LoginOrchestrator, Result<LoginResult, Error>>
    {
        private readonly IMediator _mediator;
        private readonly JwtProvider _jwtProvider;
        public LoginOrchestratorHandler(IMediator mediator, JwtProvider jwtProvider)
        {
            _mediator = mediator;
            _jwtProvider = jwtProvider;
        }
        public async Task<Result<LoginResult, Error>> Handle(LoginOrchestrator request, CancellationToken cancellationToken)
        {
            Result<LoginResult, Error> result = null;
            var userName = await _mediator.Send(new GetEncryptedStringQuery(request.UserName));
            var password = await _mediator.Send(new GetEncryptedStringQuery(request.Password));

            var logingUser = await _mediator.Send(new GetLogingUserQuery(userName, password));
            if (logingUser is null)
            {
                result = LoginErrors.InvalidUserNameOrPassword;
                return result;
            }
            var expirationDate = DateTime.Now.AddDays(100);
            string Token = _jwtProvider.GenerateJwtToken(new() { { "ByPass", "ByPass" }, { "UserID", logingUser.UserID }, { "Role", logingUser.Role.ToString() },{ "ExpirationDate" , expirationDate.Ticks.ToString()} });
            await _mediator.Send(new LoginCommand(logingUser.UserID));
             await _mediator.Send(new AddTokenCommand(new TokenCreateRequest(logingUser.UserID,  Token, expirationDate )));

            LoginResult loginResult = new LoginResult()
            {
               
                Token = Token,
                Message="Logged-in"
            };
            result = loginResult;
            return result;
        }
    }
}
