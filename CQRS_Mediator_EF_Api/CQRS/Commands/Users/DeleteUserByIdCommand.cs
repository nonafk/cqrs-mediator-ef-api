using CQRS_Mediator_EF_Api.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Mediator_EF_Api.CQRS.Commands.Users
{
    public class DeleteUserByIdCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, int>
        {
            private ApplicationContext context;

            public DeleteUserByIdCommandHandler(ApplicationContext context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
            {
                var user = await context.User.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                context.User.Remove(user);
                await context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}
