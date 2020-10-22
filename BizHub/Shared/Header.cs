using System;
using System.Collections.Generic;
using Syncfusion.Blazor.Navigations;
using Microsoft.AspNetCore.Components.Web;

using Model;
using System.Diagnostics;

namespace BizHub.Shared {
    public partial class Header {

        #region Fields
        private BasePageController _controller = new BasePageController();
        private string ActiveNavClass = "active-nav-tab";
        private System.Uri uri;
        private List<MenuItem> menuItems = new List<MenuItem> {
            new MenuItem {Text = "Buy", Id = "/Listings"},
            new MenuItem {Text = "Sell",  Id = "/Listing-Setup"},
            new MenuItem {Text = "Agent Finder",  Id = "/Agent-Finder"},
            new MenuItem {Text = "Funding",  Id = "/Financial-Info"},
            new MenuItem {Text = "Help",  Id = "/Help"}
        };

        private Int64? _listingId = null;

        public void ItemClicked(MenuEventArgs<MenuItemModel> e) {
            Controller.NavigateTo(e.Item.Id);
        }

        private List<MenuItem> UserDropDownItems = new List<MenuItem> {
            new MenuItem{Text = "Administration", Id = "/Admin-Setup/1"},
            new MenuItem{Text = "Account Management", Id = "/Account-Setup/1"},
            new MenuItem{Text = "TransitionPlanner", Id = "/TransitionPlanner"},
            //new MenuItem{Text = "Listing Management", Id = "/Account-Setup/6"},
            new MenuItem{Text = "Listing Management", Id = "/Listing-Management/1"},
            new MenuItem{Text = "Saved Searches", Id = "/Saved-Search"},
            new MenuItem{Text = "My Favorites", Id = "/Favorited-Listings"},
            new MenuItem{Text = "Email Center", Id = "/Email-Center"},
        };
        #endregion(Fields)

        #region Methods

        public void NavigateTOListingDetailsPage()
        {
            bool ListingExists = false;
            if (ListingId != null) {
                Listing CheckListing = SQL.GetListingByOid((Int64)ListingId);
                if(CheckListing != null) {
                    ListingExists = true;
                }
            }
            if (ListingExists) {
                Controller.NavigateTo("/ListingDetail/" + ListingId);
                ListingId = null;
                StateHasChanged();
            } else {
                Controller.ShowPopupDialog($"No Listing Exists with Oid [{ListingId}]", "Error");
            }
        }
        public void CheckForListingIdEnter(KeyboardEventArgs e) {
            if(e.Key.Equals("Enter")) {
                NavigateTOListingDetailsPage();
            }
        }
        private void NavigateToNewPage(string activeUrl) {
            Controller.NavigateTo(activeUrl);
        }
        #endregion(Methods)

        #region Properties
        public BasePageController Controller { get => _controller; set => _controller = value; }
        public Int64? ListingId { get => _listingId; set => _listingId = value; }
        #endregion (Properties)

    }
}
