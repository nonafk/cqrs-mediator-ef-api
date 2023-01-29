using CQRS_Mediator_EF_Api.Data;
using CQRS_Mediator_EF_Api.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Mediator_EF_Api.CQRS.Queries.Users
{
    public class GetAllUserQuery : IRequest<IEnumerable<User>>
    {
        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
        {
            private ApplicationContext context;
            public GetAllUserQueryHandler(ApplicationContext context)
            {
                this.context = context;
            }

            public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var users = await context.User.ToListAsync();
                return users;
            }
        }
    }
}
