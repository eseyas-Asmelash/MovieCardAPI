using MovieInfrustructure.Data;
using MovieModels.Entities;

public class SeedData
{
    internal static async Task InitAsync(MovieCardAPIContext context)
    {
      
        await context.Database.EnsureCreatedAsync();

       
        if (context.Movies.Any()) return;

   
        var directors = new List<Director>
        {
            new Director
            {   
                Name = "Christopher Nolan",
                DateOfBirth = new DateTime(1970, 7, 30),
                ContactInfo = new ContactInformation
                {
      
                    Email = "nolan@example.com",
                    PhoneNumber = "123-456-7890"
                }
            },
            new Director
            {
            
                Name = "Lana Wachowski",
                DateOfBirth = new DateTime(1965, 6, 21),
                ContactInfo = new ContactInformation
                {
                  
                    Email = "wachowski@example.com",
                    PhoneNumber = "321-654-0987"
                }
            }
        };
        await context.Directors.AddRangeAsync(directors);

       
        var actors = new List<Actor>
        {
            new Actor
            {
             
                Name = "Leonardo DiCaprio",
                DateOfBirth = new DateTime(1974, 11, 11)
            },
            new Actor
            {
                
                Name = "Joseph Gordon-Levitt",
                DateOfBirth = new DateTime(1981, 2, 17)
            },
            new Actor
            {
              
                Name = "Keanu Reeves",
                DateOfBirth = new DateTime(1964, 9, 2)
            }
        };
        await context.Actors.AddRangeAsync(actors);

       
        var genres = new List<Genre>
        {
            new Genre
            {
            
                Name = "Action"
            },
            new Genre
            {
            
                Name = "Sci-Fi"
            }
        };
        await context.Genres.AddRangeAsync(genres);

        
        var movies = new List<Movie>
        {
            new Movie
            {
                
                Title = "Inception",
                Rating = 8.8M,
                ReleaseDate = new DateTime(2010, 7, 16),
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                DirectorId = 1,
                Actors = new List<Actor> { actors[0], actors[1] },  
                Genres = new List<Genre> { genres[0], genres[1] } 
            },
            new Movie
            {
                
                Title = "The Matrix",
                Rating = 8.7M,
                ReleaseDate = new DateTime(1999, 3, 31),
                Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                DirectorId = 2,
                Actors = new List<Actor> { actors[0], actors[2] },  
                Genres = new List<Genre> { genres[0], genres[1] }  
            },
            new Movie
            {
            
                Title = "The Dark Knight",
                Rating = 9.0M,
                ReleaseDate = new DateTime(2008, 7, 18),
                Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                DirectorId = 1,
                Actors = new List<Actor> { actors[0] }, 
                Genres = new List<Genre> { genres[0] }  
            },
            new Movie
            {
                
                Title = "Interstellar",
                Rating = 8.6M,
                ReleaseDate = new DateTime(2014, 11, 7),
                Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                DirectorId = 1,
                Actors = new List<Actor> { actors[0] }, 
                Genres = new List<Genre> { genres[1] }  
            }
        };
        await context.Movies.AddRangeAsync(movies);

        await context.SaveChangesAsync();
    }
}
