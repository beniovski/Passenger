using System;
using Autofac;
using System.Threading.Tasks;

namespace Passenger.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }
        
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command), $"command {typeof(T).Name} can not be null");
            }
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
            
        }
    }
}