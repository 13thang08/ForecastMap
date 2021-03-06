﻿using ForecastMap.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using ForecastMap.DataModels;
using Windows.UI.Popups;
using System.Diagnostics;
using System.ComponentModel;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ForecastMap
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class FavoritesList : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        public static string addedFavoriteArea = "この地域は既にお気に入りに追加しました";
        
        ObservableCollection<Area> areas;
        ObservableCollection<Pref> prefs;
        ObservableCollection<FavoritesAreasView> favoriteAreasCollection;
        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public FavoritesList()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            var prefsInfo = await Logics.PrefsInfoLoader.getPrefsInfo();
            prefs = new ObservableCollection<Pref>(prefsInfo.Prefs);
            prefsComboBox.DataContext = prefs;

            var favoriteAreas = FavoritesAreasView.getFavoriteAreasView();
            favoriteAreasCollection = new ObservableCollection<FavoritesAreasView>(favoriteAreas);
            favoriteAreaListView.DataContext = favoriteAreasCollection;
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private void prefsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //pref_infoPref pref = (pref_infoPref)prefsComboBox.SelectedItem;
            //ObservableCollection<pref_infoPrefArea> areas = new ObservableCollection<pref_infoPrefArea>(pref.area);
            //areasComboBox.DataContext = areas;

            Pref pref = (Pref)prefsComboBox.SelectedItem;
            areas = new ObservableCollection<Area>(pref.Areas);
            areasComboBox.DataContext = areas;
        }

        private async void addFavoriteAreaButton_Click(object sender, RoutedEventArgs e)
        {
            var area = (Area)areasComboBox.SelectedItem;
            if (area == null)
            {
                return;
            }
            Debug.WriteLine(area.AreaId);
            bool result = await Logics.DataLogics.addFavorite(area.AreaId);

            if (result)
            {
                var favoriteAreas = FavoritesAreasView.getFavoriteAreasView();
                favoriteAreasCollection = new ObservableCollection<FavoritesAreasView>(favoriteAreas);
                favoriteAreaListView.DataContext = favoriteAreasCollection;
            }
            else
            {
                // aleart dialog
                var messageDialog = new MessageDialog(addedFavoriteArea);
                await messageDialog.ShowAsync();
            }
        }

        private void deleteFavoriteAreaButton_Click(object sender, RoutedEventArgs e)
        {
            FavoritesAreasView deletedArea = (sender as Button).DataContext as FavoritesAreasView;
            if (FavoritesAreasView.deleteFavoriteArea(deletedArea.AreaId))
            {
                favoriteAreasCollection.Remove(deletedArea);
            }
        }

        private void displayFlagCheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            FavoritesAreasView changedArea = checkbox.DataContext as FavoritesAreasView;
            changedArea.DisplayFlag = (bool) checkbox.IsChecked; ;
            FavoritesAreasView.updateFavoriteArea(changedArea);
        }

        private void switchMode_Click(object sender, RoutedEventArgs e)
        {
            ViewMode viewMode = (ViewMode) Resources["viewMode"];
            if (viewMode != null)
            {
                if (viewMode.Mode == ViewMode.EDIT) viewMode.Mode = ViewMode.SELECT;
                else viewMode.Mode = ViewMode.EDIT;
            }
        }

        private void favoriteAreaNameButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedArea = (sender as Button).DataContext as FavoritesAreasView;
            this.Frame.Navigate(typeof(DetailForecast), selectedArea.AreaId);
        }

        

    }


}
