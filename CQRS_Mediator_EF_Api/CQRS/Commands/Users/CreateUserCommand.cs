using CQRS_Mediator_EF_Api.Data;
using CQRS_Mediator_EF_Api.Model;
using MediatR;

namespace CQRS_Mediator_EF_Api.CQRS.Commands.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private ApplicationContext context;

            public CreateUserCommandHandler(ApplicationContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User();
                user.Username = request.Username;
                user.Password = request.Password;
                user.Level = request.Level;
                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                context.User.Add(user);
                await context.SaveChangesAsync();
                return user.Id;

            }
        }
    }
}
