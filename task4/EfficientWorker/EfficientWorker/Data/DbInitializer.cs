using System;
using EfficientWorker.Models;
using System.Linq;

namespace EfficientWorker.Data {
    public static class DbInitializer {
        public static void Initialize(EfficientWorkerContext context) {
            // context.Database.EnsureCreated();

            // Look for any students.
            if (context.Worker.Any()) {
                return;   // DB has been seeded
            }

            var workers = new Worker[]
            {
            new Worker{FirstName="Carson",LastName="Alexander"},
            new Worker{FirstName="Meredith",LastName="Alonso"},
            new Worker{FirstName="Arturo",LastName="Anand"},
            new Worker{FirstName="Gytis",LastName="Barzdukas"},
            new Worker{FirstName="Yan",LastName="Li"},
            new Worker{FirstName="Peggy",LastName="Justice"},
            new Worker{FirstName="Laura",LastName="Norman"},
            new Worker{FirstName="Nino",LastName="Olivetto"}
            };
            foreach (Worker s in workers) {
                context.Worker.Add(s);
            }
            context.SaveChanges();

            var projects = new Project[]
            {
                //ProjectID ProjectName WorkerID ProjectCost
            new Project{WorkerID=workers[0].ID,ProjectName="proj1",ProjectCost=1000},
            new Project{WorkerID=workers[1].ID,ProjectName="proj2",ProjectCost=1020},
            new Project{WorkerID=workers[2].ID,ProjectName="proj3",ProjectCost=10000},
            new Project{WorkerID=workers[3].ID,ProjectName="proj4",ProjectCost=2000},
            new Project{WorkerID=workers[3].ID,ProjectName="proj5",ProjectCost=2000},
            new Project{WorkerID=workers[4].ID,ProjectName="proj6",ProjectCost=2000},
            new Project{WorkerID=workers[5].ID,ProjectName="proj7",ProjectCost=3000},
            new Project{WorkerID=workers[6].ID,ProjectName="proj8",ProjectCost=20005},
            new Project{WorkerID=workers[7].ID,ProjectName="proj9",ProjectCost=3500},
            new Project{WorkerID=workers[2].ID,ProjectName="proj10",ProjectCost=35000},
            new Project{WorkerID=workers[1].ID,ProjectName="proj11",ProjectCost=200},
            new Project{WorkerID=workers[0].ID,ProjectName="proj12",ProjectCost=4400},
            };
            foreach (Project e in projects) {
                context.Project.Add(e);
            }
            context.SaveChanges();
        }
    }
}
