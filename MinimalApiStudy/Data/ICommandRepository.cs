

using MinimalApiStudy.Models;

namespace MinimalApiStudy.Data
{
    public interface ICommandRepository
    {
        Task SaveChangesAsync();
        Task<Command?> GetCommandById(int id);  
        Task<IEnumerable<Command>> GetAllCommands();
        Task CreateCommand(Command command);

        void DeleteCommand(Command command);

    }
}