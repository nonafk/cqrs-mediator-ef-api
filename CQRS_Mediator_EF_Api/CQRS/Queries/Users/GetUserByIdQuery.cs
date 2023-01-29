using CQRS_Mediator_EF_Api.Data;
using CQRS_Mediator_EF_Api.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Mediator_EF_Api.CQRS.Queries.Users
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private ApplicationContext context;

            public GetUserByIdQueryHandler(ApplicationContext context)
            {
                this.context = context;
            }

            public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var user = await context.User.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                return user;
            }
        }
    }
}
