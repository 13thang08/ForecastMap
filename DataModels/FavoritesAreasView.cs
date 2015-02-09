using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastMap.DataModels
{
    class FavoritesAreasView
    {
        public string Name { get; set; }

        public int AreaId { get; set; }

        public static List<FavoritesAreasView> getFavoriteAreasView()
        {
            List<FavoritesAreas> favoriteAreas = Logics.DataLogics.getFavoriteAreas();
            List<FavoritesAreasView> favoriteAreasViewItems = new List<FavoritesAreasView>();
            foreach (var item in favoriteAreas)
            {
                FavoritesAreasView itemView = new FavoritesAreasView();
                itemView.Name = item.PrefectureName + "-" + item.AreaName;
                itemView.AreaId = item.AreaId;
                favoriteAreasViewItems.Add(itemView);
            }
            return favoriteAreasViewItems;
        }
    }
}
