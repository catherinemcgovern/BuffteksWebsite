using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BuffteksWebsite.Models
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BuffteksWebsiteContext(serviceProvider.GetRequiredService<DbContextOptions<BuffteksWebsiteContext>>()))
            {

                // CLIENTS
                if (context.Clients.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var clients = new List<Client>
                {
                    new Client { FirstName="Tina", LastName="Fey", CompanyName="funny.com", Email="funny.com", Phone="265-369-8875" },
                    new Client { FirstName="Marion", LastName="Spikes", CompanyName="Unicron Limited", Email="unicronomicon@limiyrf.com", Phone="209-668-3258" },
                    new Client { FirstName="Samuel", LastName="Compton", CompanyName="trees are us", Email="compton@lunnovk.com", Phone="123-587-4171" }
                };
                context.AddRange(clients);
                context.SaveChanges();


                // CLIENTS
                if (context.Members.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var members = new List<Member>
                {
                    new Member { FirstName="Vera", LastName="Wang", Major="CIS", Email="verawang@buffs.wtamu.edu", Phone="658-211-8756" },
                    new Member { FirstName="Andy", LastName="Warhol", Major="CIS", Email="andywarhol@buffs.wtamu.edu", Phone="809-699-1166" },
                    new Member { FirstName="Roz", LastName="Chast", Major="CIS", Email="RozChast@buffs.wtamu.edu", Phone="206-234-8877" },
                    new Member { FirstName="Maury", LastName="Povich", Major="CIS", Email="MauryPovich@buffs.wtamu.edu", Phone="209-935-3336" },
                    new Member { FirstName="Dena", LastName="Batrice", Major="CIS", Email="denabatrice@buffs.wtamu.edu", Phone="107-020-2008" },
                    new Member { FirstName="Myra", LastName="Kalman", Major="CIS", Email="myrakalman@buffs.wtamu.edu", Phone="225-598-4007" },
                    new Member { FirstName="Cheryl", LastName="Swopes", Major="CIS", Email="cherylswopes@buffs.wtamu.edu", Phone="339-205-9779" },
                    new Member { FirstName="Juno", LastName="Harrington", Major="CIS", Email="Juno@buffs.wtamu.edu", Phone="663-020-2008" },
                    new Member { FirstName="Dayton", LastName="Harmon", Major="CIS", Email="dayton@buffs.wtamu.edu", Phone="389-598-4007" },
                    new Member { FirstName="Merna", LastName="Tina", Major="CIS", Email="merna@buffs.wtamu.edu", Phone="336-205-9779" }
                };
                context.AddRange(members);
                context.SaveChanges();

                // PROJECTS
                if (context.Projects.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                var projects = new List<Project>
                {
                    new Project { ProjectName="Taquito Tavern", ProjectDescription="Taquito's Rule" },
                    new Project { ProjectName="Awesome Possom", ProjectDescription="Possums are the new cats on the Interwebs" },
                    new Project { ProjectName="Unicorns Unite", ProjectDescription="Because, Unicorns" }
                };
                context.AddRange(projects);
                context.SaveChanges();

                //PROJECT ROSTER BRIDGE TABLE - THERE MUST BE PROJECTS AND PARTICIPANTS MADE FIRST
                if (context.ProjectRoster.Any())
                {
                    //leave, there is already data in the database
                    return; 
                }

                

                //quickly grab the recent records added to the DB to get the IDs
                var projectsFromDb = context.Projects.ToList();
                var clientsFromDb = context.Clients.ToList();
                var membersFromDb = context.Members.ToList();

                var projectroster = new List<ProjectRoster>
                {
                    //take the first project from above, the first client from above, and the first three students from above.
                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = clientsFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = clientsFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(0).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(0) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(1).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(1) },

                    new ProjectRoster { ProjectID = projectsFromDb.ElementAt(0).ID.ToString(), 
                                        Project = projectsFromDb.ElementAt(0), 
                                        ProjectParticipantID = membersFromDb.ElementAt(2).ID.ToString(),
                                        ProjectParticipant = membersFromDb.ElementAt(2) },                                        
                };
                context.AddRange(projectroster);
                context.SaveChanges();                

            }
        }
    }
}