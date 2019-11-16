using AutoService.Abstractions;
using AutoService.Models;
using AutoService.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class AutopartsServiceTest
    {
        [Fact]
        public async Task AddTest()
        {
            var fake = Mock.Of<IAutopartsRepo>();
            var autopartsService = new AutopartsServices(fake);

            var autoparts = new Autoparts() { car_id = 1, typesautopart_id = 1, name = "somebody", price = 1000 };
            await autopartsService.AddAndSave(autoparts);
        }
        [Fact]
        public async Task UpdateTest()
        {
            var fake = Mock.Of<IAutopartsRepo>();
            var autopartsService = new AutopartsServices(fake);

            var autoparts = new Autoparts() { car_id = 1, typesautopart_id = 2, name = "anybody", price = 500 };
            await autopartsService.Update(autoparts);
        }
        [Fact]
        public async Task RemoveTest()
        {
            var fake = Mock.Of<IAutopartsRepo>();
            var autopartsService = new AutopartsServices(fake);
            var autoparts = new Autoparts() { car_id = 2, typesautopart_id = 2, name = "somebody2", price = 1500 };
            await autopartsService.Delete(autoparts);
        }
        [Fact]
        public async Task DetailTest()
        {
            var fake = Mock.Of<IAutopartsRepo>();
            var autopartsService = new AutopartsServices(fake);
            var id = 2;
            await autopartsService.DetailsAutoparts(id);
        }
        [Fact]
        public async Task GetAutopartsTest()
        {
            var autoparts = new List<Autoparts>
            {
                new Autoparts() { car_id = 3, typesautopart_id = 3, name = "somebody3", price = 1501 },
                new Autoparts() { car_id = 4, typesautopart_id = 4, name = "somebody4", price = 1503 },
        };

            var fakeRepositoryMock = new Mock<IAutopartsRepo>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(autoparts);


            var autopartsService = new AutopartsServices(fakeRepositoryMock.Object);

            var resultAutoparts = await autopartsService.GetAutoparts();

            Assert.Collection(resultAutoparts, autoparts =>
            {
                Assert.Equal(3, autoparts.car_id);
                Assert.Equal(3, autoparts.typesautopart_id);
                Assert.Equal("somebody3", autoparts.name);
                Assert.Equal(1501, autoparts.price);

            },
            autoparts =>
            {
                Assert.Equal(4, autoparts.car_id);
                Assert.Equal(4, autoparts.typesautopart_id);
                Assert.Equal("somebody4", autoparts.name);
                Assert.Equal(1503, autoparts.price);

            });
        }
    }
}
