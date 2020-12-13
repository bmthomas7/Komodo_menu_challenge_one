using Repository_Komodo_menu_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Menu_Console
{
    class ProgramUI
    {
        private MenuContentRepository _contentRepo = new MenuContentRepository();
        public void Run()
        {
            
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Content\n" +
                    "2. View All Content\n" +
                    "3. View Content By Title\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //create new content
                        CreateNewContent();
                        break;
                    case "2":
                        //view all content
                        DisplayAllContent();
                        break;
                    case "3":
                        //view content by title
                        DisplayContentByNumber();
                        break;
                    case "4":
                        //update existing content
                        UpdateExistingContent();
                        break;
                    case "5":
                        //delete existing content
                        DeleteExistingContent();
                        break;
                    case "6":
                        //exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("please press any key to continue....");
                Console.ReadKey();
                Console.Clear();

            }
        
        }

        private void CreateNewContent()
        {
            MenuContent newContent = new MenuContent();

            Console.WriteLine("Enter the number for your meal:");
            string menuNumberAsString = Console.ReadLine();
            newContent.MealNumber = int.Parse(menuNumberAsString);

            Console.WriteLine("Enter what the meal name is:");
            newContent.MealName = Console.ReadLine();

            //description
            Console.WriteLine("Enter what is on your Meal:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Enter what your meal cost");
            string priceAsString = Console.ReadLine();
            newContent.Price = double.Parse(priceAsString);

        }

        private void DisplayAllContent()
        {
            Console.Clear();

            List<MenuContent> listOfContent = _contentRepo.GetContentList();
            
            foreach (MenuContent content in listOfContent)
            {
                Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Price: {content.Price}");
            }
        }

        private void DisplayContentByNumber()
        {
            Console.Clear();

            Console.WriteLine("enter a meal number you woud like to display");

            int menuNumber = Console.ReadLine();

            MenuContent content = _contentRepo.GetContentByNumber(menuNumber);

            if (content != null)
            {
                Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Price: {content.Price}");
            }
            else
            {
                Console.WriteLine("No Content by that number");
            }
        }

        private void UpdateExistingContent()
        {
            DisplayAllContent();

            //ask for number to update
            Console.WriteLine("enter the Meal Number you would like to update");
            string oldContent = Console.ReadLine();
            

            MenuContent newContent = new MenuContent();

            Console.WriteLine("Enter the number for your meal:");
            string menuNumberAsString = Console.ReadLine();
            newContent.MealNumber = int.Parse(menuNumberAsString);

            Console.WriteLine("Enter what the meal name is:");
            newContent.MealName = Console.ReadLine();

            //description
            Console.WriteLine("Enter what is on your Meal:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Enter what your meal cost");
            string priceAsString = Console.ReadLine();
            newContent.Price = double.Parse(priceAsString);

            // verify update worked
            bool wasUpdated = _contentRepo.UpdateExistingContent(oldContent, newContent);
            
            if (wasUpdated)
            {
                Console.WriteLine("content successfully updated.");
            }
            else
            {
                Console.WriteLine("could not update");
            }
        
        }

        private void DeleteExistingContent()
        {
            DisplayAllContent();

            Console.WriteLine("\nEnter the meal number you would like to delete");

            string input = Console.ReadLine();

            bool wasDeleted = _contentRepo.RemoveContentFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("content was successfully deleted");
            }
            else
            {
                Console.WriteLine("content could not be deleted");
            }


        }
        private void seedContentList()
        {
            MenuContent numberOne = new MenuContent(1, "Burger", "bun, burger, onions, pickles, ketchup, mustard", 7.99);
            MenuContent numberTwo = new MenuContent(2, "Cheese fries", "potato, cheese", 2.99);
            MenuContent numberThree = new MenuContent(3, "salad", "lettuce, tomato, salad dressing, crutons, cheese, bacon", 5.99);

            _contentRepo.AddContentToList(numberOne);
            _contentRepo.AddContentToList(numberTwo);
            _contentRepo.AddContentToList(numberThree);

        }
    }
}
