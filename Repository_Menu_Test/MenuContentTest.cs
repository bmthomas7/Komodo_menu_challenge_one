using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository_Komodo_menu_Repository;

namespace Repository_Menu_Test
{
    [TestClass]
    public class MenuContentTest
    {
        [TestMethod]
        public void SetNumber_ShouldSetCorrectInt()
        {
            MenuContent content = new MenuContent();

            content.MealNumber = 7;

            int expected = 7;
            int actual = content.MealNumber;

            Assert.AreEqual(expected, actual);

            
        }
    }
}
