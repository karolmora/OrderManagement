using OrderManagement.Shared.Entities;

namespace OrderManagement.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;

        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync(); //si no hay bd la crea
            await dataSeedTypeProduct();
           
        }

        public async Task dataSeedTypeProduct()
        {
            if (!_context.TypeProduct.Any())
            {
                _context.TypeProduct.Add(new TypeProduct { Description = "Pizza" });
                _context.TypeProduct.Add(new TypeProduct { Description = "Hamburguesa" });
                _context.TypeProduct.Add(new TypeProduct { Description = "Lasaña" });
                _context.TypeProduct.Add(new TypeProduct { Description = "Panzerotti" });
                _context.TypeProduct.Add(new TypeProduct { Description = "Agua" });
                _context.TypeProduct.Add(new TypeProduct { Description = "Club dorada" });
                _context.TypeProduct.Add(new TypeProduct { Description = "Mora" });

                await _context.SaveChangesAsync();


            }
        }
    }
}
