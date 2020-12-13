using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Komodo_menu_Repository
{
    public class MenuContentRepository
    {
        private List<MenuContent> _ListOfContent = new List<MenuContent>();

        //create
        public void AddContentToList(MenuContent content)
        {
            _ListOfContent.Add(content);
        }

        //read
        public List<MenuContent> GetContentList()
        {
            return _ListOfContent;
        }


        //update
        public bool UpdateExistingContent(int originalNumber, MenuContent newContent)
        {
            MenuContent oldContent = GetContentByNumber(originalNumber);

            if(oldContent != null)
            {
                oldContent.MealNumber = newContent.MealNumber;
                oldContent.Description = newContent.Description;
                oldContent.MealName = newContent.MealName;
                oldContent.Price = newContent.Price;

                return true;
            }
            else
            {
                return false;
            }

        }



        //delete
        public bool RemoveContentFromList(int MealNumber)
        {
            MenuContent content = GetContentByNumber(MealNumber);
            
            if (content == null)
            {
                return false;
            }

            int initialCount = _ListOfContent.Count;
            _ListOfContent.Remove(content);

            if(initialCount > _ListOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


        }






        //helper method
        //turn back to the projectui instead of menu content
        public MenuContent GetContentByNumber(int MealNumber)
        {
            foreach(MenuContent content in _ListOfContent)
            {
                if (content.MealNumber == MealNumber )
                {
                    return content;

                }
            }

            return null;

        } 

    }
}
