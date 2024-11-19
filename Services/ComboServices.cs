
namespace EnmanuelGomez_AP1_P2.Services
{
    public class ComboServices
    {
        public class ComboService
        {
            private readonly IRepository<Combo> _comboRepository;

            public ComboService(IRepository<Combo> comboRepository)
            {
                _comboRepository = comboRepository;
            }

            public async Task<List<Combo>> GetCombosAsync()
            {
                return await _comboRepository.GetAllAsync();
            }

            public async Task AddComboAsync(Combo combo)
            {
                await _comboRepository.AddAsync(combo);
            }

            // Método Create
            public async Task<Combo> CreateComboAsync(string name, decimal price)
            {
                var newCombo = new Combo
                {
                    Name = name,
                    Price = price,
                    CreatedAt = DateTime.Now
                };

                await _comboRepository.AddAsync(newCombo);
                return newCombo;
            }
        }
    }

    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync();
    }

    public class Combo
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
