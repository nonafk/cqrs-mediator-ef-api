using CQRS_Mediator_EF_Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Mediator_EF_Api.CQRS.Commands.Users
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Level { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private ApplicationContext context;
            public UpdateUserCommandHandler(ApplicationContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await context.User.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return default;
                }
                else
                {
                    user.Password= request.Password;
                    user.Level= request.Level;
                    user.CreatedAt= request.CreatedAt;
                    user.UpdatedAt= request.UpdatedAt;
                    await context.SaveChangesAsync();
                    return user.Id;
                }
            }
        }
    }
}
