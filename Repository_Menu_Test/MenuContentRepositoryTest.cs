using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository_Komodo_menu_Repository;

namespace Repository_Menu_Test
{
    [TestClass]
    public class MenuContentRepositoryTest
    {
        private MenuContentRepository _repo;
        private MenuContent _content;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuContentRepository();
            _content = new MenuContent(1, "Burger", "beef, lettuce, tomato, onion, bun", 7.99);

            _repo.AddContentToList(_content);

               
        }


        //add method

        [TestMethod]
        public void AddToList_ShouldGetNotNull()
        {
            //arrange

            MenuContent content = new MenuContent();
            content.MealNumber = 7;
            MenuContentRepository repository = new MenuContentRepository();

            //act

            repository.AddContentToList(content);
            MenuContent contentFromDirectory = repository.GetContentByNumber(7);

            //assert

            Assert.IsNotNull(contentFromDirectory);

        }

        //update
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //arrange
            //testinitialize
            MenuContent newContent = new MenuContent(1, "Burger", "beef, lettuce, tomato, onion, bun", 7.99);

            //act
            bool updateResult = _repo.UpdateExistingContent(1, newContent);

            //assert
            Assert.IsTrue(updateResult);
                
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(11, false)]
        public void UpdateExistingContent_ShouldMatchGivenBool(int originalNumber, bool shouldUpdate)
        {
            //arrange
            //testinitialize
            MenuContent newContent = new MenuContent(1, "Burger", "beef, lettuce, tomato, onion, bun", 7.99);

            //act
            bool updateResult = _repo.UpdateExistingContent(originalNumber, newContent);

            //assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteContent_ShouldReturnTrue()
        {
            //arrange

            //act
            bool deleteResult = _repo.RemoveContentFromList(_content.MealNumber);

            //assert
            Assert.IsTrue(deleteResult);


        }        


    }
}
