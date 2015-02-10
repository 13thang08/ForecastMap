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

        public bool DisplayFlag { get; set; }

        public static List<FavoritesAreasView> getFavoriteAreasView()
        {
            List<FavoritesAreas> favoriteAreas = Logics.DataLogics.getFavoriteAreas();
            List<FavoritesAreasView> favoriteAreasViewItems = new List<FavoritesAreasView>();
            foreach (var item in favoriteAreas)
            {
                FavoritesAreasView itemView = new FavoritesAreasView();
                itemView.Name = item.PrefectureName + "-" + item.AreaName;
                itemView.AreaId = item.AreaId;
                itemView.DisplayFlag = item.DisplayFlag;
                favoriteAreasViewItems.Add(itemView);
            }
            return favoriteAreasViewItems;
        }

        public static bool deleteFavoriteArea(int areaId)
        {
            return Logics.DataLogics.deleteFavoriteArea(areaId);
        }

        public static bool updateFavoriteArea(FavoritesAreasView favoriteAreaView)
        {
            FavoritesAreas favoriteArea = Logics.DataLogics.getFavoriteArea(favoriteAreaView.AreaId);
            if (favoriteArea != null)
            {
                favoriteArea.DisplayFlag = favoriteAreaView.DisplayFlag;
                return Logics.DataLogics.updateFavoriteArea(favoriteArea);
            }
            else
            {
                return false;
            }
            
        }
    }
}
