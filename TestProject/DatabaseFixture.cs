
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DatabaseFixture : IDisposable
    {
        public _326134715ShopContext Context { get; private set; }

        public DatabaseFixture()
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<_326134715ShopContext>()
                .UseSqlServer("Server=srv2\\pupils;Database=Tests;Trusted_Connection=True;TrustServerCertificate=true;")
                .Options;
            Context = new _326134715ShopContext(options);
            Context.Database.EnsureCreated(); // create the database
        }

        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}