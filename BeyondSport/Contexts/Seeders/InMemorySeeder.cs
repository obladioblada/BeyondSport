using beyondsports.models;

namespace beyondsports.dbContext {

     public class InMemorySeeder(ApplicationContext context) : ISeeder {
        
         void ISeeder.Seed()
        {
            

            context.Team.AddRange(
                new Team { id = 1, name = "SSC Napoli", country = "Italy" },
                new Team { id = 2, name = "FC Barcelona",  country = "Spain"}
            );

            context.Player.AddRange(
                new Player {id = 1, name = "Diego Armando Maradona",  age = 32, team_id = 1 },
                new Player {id = 2,name = "Lionel Messi",age = 33,team_id = 2 }
            );

            context.SaveChanges();
        
        }
    }
}