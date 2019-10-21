using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Linq;
using MVC_plenum_2.Controllers;
using MVC_plenum_2.BLL;
using MVC_plenum_2.DAL;
using System.Collections.Generic;
using MVC_plenum_2.Model;

namespace Enhetstest
{
    [TestClass]
    public class KundeControllerTest
    {
        [TestMethod]
        public void Liste()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            // uten test : var controller = new PersonController();
            var forventetResultat = new List<Kunde>();
            var kunde = new Kunde()
            {
                id = 1,
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo"
            };
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);
            forventetResultat.Add(kunde);

            // Act
            var actionResult = (ViewResult)controller.Liste();
            var resultat = (List<Kunde>)actionResult.Model;
            // Assert

            Assert.AreEqual(actionResult.ViewName, "");

            for (var i = 0; i < resultat.Count; i++)
            {
                Assert.AreEqual(forventetResultat[i].id, resultat[i].id);
                Assert.AreEqual(forventetResultat[i].fornavn, resultat[i].fornavn);
                Assert.AreEqual(forventetResultat[i].etternavn, resultat[i].etternavn);
                Assert.AreEqual(forventetResultat[i].adresse, resultat[i].adresse);
                Assert.AreEqual(forventetResultat[i].postnr, resultat[i].postnr);
                Assert.AreEqual(forventetResultat[i].poststed, resultat[i].poststed);
            }
            /*
            Det som kommer under er bare for å vise hva Assert.IsTrue kan gjøre (dvs alt!)
            string forventet1 = "Her er en mulighet";
            string forventet2 = "Her er en mulighet til";
            string virkelig = "Her er en mulighet";
            if (virkelig == forventet1 || virkelig==forventet2)
                test = true;
            else 
                test = false;
            Assert.IsTrue(test);
             
             */
        }
        [TestMethod]
        public void Registrer()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Registrer();

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Registrer_Post_OK()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));

            var innKunde = new Kunde()
            {
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo"
            };
            // Act
            var result = (RedirectToRouteResult)controller.Registrer(innKunde);

            // Assert
            Assert.AreEqual(result.RouteName, "");
            Assert.AreEqual(result.RouteValues.Values.First(), "Liste");
        }
        [TestMethod]
        public void Registrer_Post_Model_feil()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var innKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("fornavn", "Ikke oppgitt fornavn");

            // Act
            var actionResult = (ViewResult)controller.Registrer(innKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Registrer_Post_DB_feil()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var innKunde = new Kunde();
            innKunde.fornavn = "";

            // Act
            var actionResult = (ViewResult)controller.Registrer(innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Detaljer()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var forventetResultat = new Kunde()
            {
                id=1,
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo"
            };
            // Act
            var actionResult = (ViewResult)controller.Detaljer(1);
            var resultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(forventetResultat.id, resultat.id);
            Assert.AreEqual(forventetResultat.fornavn, resultat.fornavn);
            Assert.AreEqual(forventetResultat.etternavn, resultat.etternavn);
            Assert.AreEqual(forventetResultat.adresse, resultat.adresse);
            Assert.AreEqual(forventetResultat.postnr, resultat.postnr);
            Assert.AreEqual(forventetResultat.poststed, resultat.poststed);
        }
        [TestMethod]
        public void Slett()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Slett(1);
            var resultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");


        }
        [TestMethod]
        public void Slettet_funnet_Post()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo"
            };

            // Act
            var actionResult = (RedirectToRouteResult)controller.Slett(1, innKunde);

            // Assert
            Assert.AreEqual(actionResult.RouteName, "");
            Assert.AreEqual(actionResult.RouteValues.Values.First(), "Liste");
        }
        [TestMethod]
        public void Slett_ikke_funnet_Post()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo"
            };

            // Act
            var actionResult = (ViewResult)controller.Slett(0, innKunde);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Endre(1);

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_Ikke_Funnet_Ved_View()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));

            // Act
            var actionResult = (ViewResult)controller.Endre(0);
            var kundeResultat = (Kunde)actionResult.Model;

            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
            Assert.AreEqual(kundeResultat.id, 0);
        }
        [TestMethod]
        public void Endre_ikke_funnet_Post()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                id=0,
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo"
            };

            // Act
            var actionResult = (ViewResult)controller.Endre(0, innKunde);
           
            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_feil_validering_Post()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var innKunde = new Kunde();
            controller.ViewData.ModelState.AddModelError("feil", "ID = 0");

            // Act
            var actionResult = (ViewResult)controller.Endre(0, innKunde);

            // Assert
            Assert.IsTrue(actionResult.ViewData.ModelState.Count == 1);
            Assert.AreEqual(actionResult.ViewData.ModelState["feil"].Errors[0].ErrorMessage, "ID = 0");
            Assert.AreEqual(actionResult.ViewName, "");
        }
        [TestMethod]
        public void Endre_funnet()
        {
            // Arrange
            var controller = new KundeController(new KundeLogikk(new KundeRepositoryStub()));
            var innKunde = new Kunde()
            {
                fornavn = "Per",
                etternavn = "Olsen",
                adresse = "Osloveien 82",
                postnr = "1234",
                poststed = "Oslo"
            };
            // Act
            var actionResultat = (RedirectToRouteResult)controller.Endre(1, innKunde);

            // Assert
            Assert.AreEqual(actionResultat.RouteName, "");
            Assert.AreEqual(actionResultat.RouteValues.Values.First(), "Liste");
        }
    }
}
