using NuGet.Frameworks;
using NUnit.Framework;
using RestaurantTill;
using System;

namespace UnitTests
{
    [TestFixture]
    public class CheckoutTests
    {
        Menu menu = new Menu();
        Checkout checkout = new Checkout();

        [SetUp]
        public void Setup()
        {
            menu.addStarter("Finger Chicken");
            menu.addStarter("French Fries");
            menu.addMain("Chicken Pizza");
        }
        [TearDown]
        public void Dispose()
        {
            menu.clearMenu();
        }

        [Test]
        public void CheckTheBillWhenNoItems()
        {
            menu.clearMenu();
            Assert.AreEqual(0.00, checkout.totalBill(menu));
        }
        [Test]
        public void CheckTheBillWithOnlyStarters()
        {
            menu.clearMenu();
            menu.addStarter("Finger Chicken");
            menu.addStarter("French Fries");
            Assert.AreEqual(8.80, checkout.totalBill(menu));
        }
        [Test]
        public void CheckTheBillWithOnlyMains()
        {
            menu.clearMenu();
            menu.addMain("Chicken Pizza");
            Assert.AreEqual(7.00, checkout.totalBill(menu));
        }

        [Test]
        public void CheckTheBillWithStartersAndMains()
        {
            Assert.AreEqual(15.80, checkout.totalBill(menu));
        }

        [Test]
        public void CheckTheBillWithNullMenu()
        {
            Assert.Throws<NullReferenceException> (delegate { checkout.totalBill(null); } );
        }

        [Test]
        public void CheckTheOrderAfterAddingItems()
        {
            menu.addStarter("Salad");
            menu.addMain("Curry");
            //After adding one more starter to already existing 2 starters, total starters should be updated to 3
            Assert.AreEqual(3, menu.starter.Count);
            Assert.AreEqual(2, menu.mainCourse.Count);
        }
        [Test]
        public void CheckIfTheItemExistsAfterAdding()
        {
            Assert.IsTrue(menu.starter.Contains("Finger Chicken"));
        }
        
        [Test]
        public void CheckTheOrderAfterDeletingItems()
        {
            menu.deleteStarter("Finger Chicken");
            menu.deleteMain("Chicken Pizza");
            Assert.AreEqual(1, menu.starter.Count);
            Assert.AreEqual(0, menu.mainCourse.Count);
        }

        public void CheckIfTheItemExistsAfterDeleting()
        {
            menu.deleteStarter("Finger Chicken");
            Assert.IsFalse(menu.starter.Contains("Finger Chicken"));
        }
    }
}