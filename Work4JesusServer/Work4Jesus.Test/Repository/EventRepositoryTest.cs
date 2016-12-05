using System;
using System.IO;
using NUnit.Framework;
using Work4Jesus.Domain;
using Work4Jesus.ValueModels;
using WorkForJesus.RepoServiceImplementation.Repository;

namespace Work4Jesus.Test.Repository
{
    [TestFixture]
    public class EventRepositoryTest
    {
        public void CreateANewEventStoreItAndRecoverIt()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "");
            var newEvent = new Cevent()
            {
                Adress  = "8 allée émile roux. 77700 CHAMPS SUR MARNE",
                Title = "House of disciple",
                AdressComplement = "Pour y accéder passer devant la maison de JUDE",
                ChurchLink = "http://eglise.champs-sur-marne.com",
                Description = "Cette maison sert l'éternel ^^",
                KeyWord = "Jésus;Maison de Dieu;",
                StartOfEvent = new DateTime(2016,12, 24),
                EndOfEvent =  new DateTime(2016, 12, 30),
                CreatedOn = new DateTime(2016, 12, 5),
                ModifiedOn = DateTime.Now,
                Price = 0,
                Owner = 1,
                YoutubeLink = "http://youtube.com",
                Id = 1
            };
            newEvent.SetGpsPosition(2, 2.9f);
            newEvent.Save();
            var repo = new EventRepository(path);
            repo.Add(newEvent);

            repo = new EventRepository(path);
             newEvent = repo.Get(1);
            Assert.NotNull(newEvent);
            Assert.AreEqual(newEvent.Owner, 1);
            Assert.AreEqual(newEvent.GetGpsPosition(), new GpsPosition(2, 2.9f));
        }
    }
}