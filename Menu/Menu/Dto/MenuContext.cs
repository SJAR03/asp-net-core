using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Dto
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> opt ) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { 
                    di.DishId, 
                    di.IngredientId 
                });
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Pizza", Price = 10.0, imageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.foodandwine.com%2Frecipes%2Fclassic-cheese-pizza&psig=AOvVaw11tFt_aiBX5dfITNbX7e6P&ust=1711230633112000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKC3h-DsiIUDFQAAAAAdAAAAABAE" },
                new Dish { Id = 2, Name = "Pasta", Price = 8.0, imageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.bonviveur.es%2Frecetas%2Fone-pot-pasta&psig=AOvVaw3aEcFQASquDeFSWM1wFQ8o&ust=1711230658834000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCKCSmezsiIUDFQAAAAAdAAAAABAE" }
                );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Cheese" },
                new Ingredient { Id = 2, Name = "Tomato" },                            
                new Ingredient { Id = 3, Name = "Pasta" },                                                         
                new Ingredient { Id = 4, Name = "Basil" }                                                                               
                );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 2, IngredientId = 3 },
                new DishIngredient { DishId = 2, IngredientId = 4 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }

    }
}
