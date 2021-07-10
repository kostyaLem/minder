using Minder.DAL.Repositories.Base;
using Minder.DomainModels.Models;
using NUnit.Framework;
using System;

namespace Minder.Tests
{
    public class CrudTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var repo = new BaseRepository<EmployeesPosition>(new DomainModels.Context.MinderDbContextFactory());

            repo.Create(new EmployeesPosition()
            {
                Name = "Developer"
            }).Wait();
        }
    }
}