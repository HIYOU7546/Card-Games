using Rainbows;

namespace Menus
{
    public class MenuInteraction
    {
        /// <summary>
        /// Displays a game choice menu to the user.
        /// </summary>
        /// <param name="MenuTitle">The title of the menu to be displayed.</param>
        /// <param name="MenuOptions">The options to be displayed in the menu.</param>
        /// <returns>The index of the selected menu option.</returns>
        public int MultiMenu(string MenuTitle, string[] MenuOptions)
        {
            Console.WriteLine(MenuTitle);
            for (int i = 0; i < MenuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {MenuOptions[i]}");
            }
            return Console.ReadKey(true).KeyChar - '0';
        }

        /// <summary>
        /// Displays a color selection menu to the user.
        /// </summary>
        /// <param name="MenuTitle">The title of the menu to be displayed in static rainbow text.</param>
        /// <param name="ColorMenuOptions">Predefined color options to be displayed in the menu.</param>
        /// <returns>The index of the selected color option.</returns>
        public int ColorMenu(string MenuTitle, string[] ColorMenuOptions)
        {
            Rainbowify.WriteLine(MenuTitle);
            for (int i = 0; i < ColorMenuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ColorMenuOptions[i]}");
            }
            return Console.ReadKey(true).KeyChar - '0';
        }
    }
}