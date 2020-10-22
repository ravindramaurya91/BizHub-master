using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class Constants {

        public const string URL_DELIMIETER_BEGIN = "<~";
        public const string URL_DELIMIETER_END = "~>";
        
        public const Int64 BIZHUB_SYSTEM_ENTITY_OID = 1;


        #region S3
        //BizHub S3
        public const string AWS_S3_5STONES_SERVER_URL = "https://s3-us-west-2.amazonaws.com/";
        public const string AWS_S3_5STONES_ROOT_DIRECTORY = "https://5stones.s3.us-west-2.amazonaws.com/";
        public const string AWS_S3_5STONES_BUCKET = "5stones";
        public const string AWS_S3_5STONES_SECRET = "KxhCe4tEL4/GHHDcowJyEGwAW6Dxcl4Exwoot6PA";
        public const string AWS_S3_5STONES_KEY = "AKIASYF2NNUMNRQSOF3Y";
        //public const string AMAZON_S3_BUCKET_URL_FOR_5STONES = "https://5stones.s3.us-west-2.amazonaws.com/";
        #endregion (S3)

        // ListingStat Events
        public const string LISTINGSTAT_EVENT_VIEW = "VIEW";
        public const string LISTINGSTAT_EVENT_CLICK = "CLICK";
        public const string LISTINGSTAT_EVENT_CONTACT_REQUEST = "CONTACT";

        // Type of Data Sets being stored in the ResultSetCache
        public const int RESULTSET_UNKNOWN = 0;
        public const int RESULTSET_LISTING_SEARCH = 1;
        
        // Listings display views
        public const string LISTINGS_VIEW_STYLE_TILE = "Tile";
        public const string LISTINGS_VIEW_STYLE_LIST = "List";

        #region ServiceQueue Message Types
        // Types of Messages sent to the ServiceQueue in QueableMessage
        public const int QUE_MESSAGE_TYPE_TEST = 0;       
        public const int QUE_MESSAGE_TYPE_VIEW = 1;
        public const int QUE_MESSAGE_TYPE_CLICK = 2;
        public const int QUE_MESSAGE_TYPE_CONTACT = 3;
        public const int QUE_MESSAGE_TYPE_SEARCH_REQUEST = 4;
        #endregion (ServiceQueue Message Types)

        #region LoanCalc
        // Loan Terminology
        public const string TENURE_DURATION_TYPE_MONTH = "Month";
        public const string TENURE_DURATION_TYPE_YEAR = "Year";
        #endregion (LoanCalc)

        // List of available ZipCode distances to search by. Resused on several pages
        public static readonly List<FSVisualItem> ZIPCODE_SEARCH_DISTANCES = new List<FSVisualItem> {
            new FSVisualItem() { Value= "25", Label= "25" },
            new FSVisualItem() { Value= "50", Label= "50" },
            new FSVisualItem() { Value= "100", Label= "100" },
            new FSVisualItem() { Value= "250", Label= "250" },
        };

        // List of available data insert values an email template can utilize
        public static readonly List<FSVisualItem> EMAIL_TEMPLATE_DATA_INSERT_OPTIONS = new List<FSVisualItem> {
            new FSVisualItem() { Value= "Select One", Label= "Select One" },
            new FSVisualItem() { Value= "Recipient Name", Label= "Recipient Name" },
            new FSVisualItem() { Value= "Listing Title", Label= "Listing Title" },
            new FSVisualItem() { Value= "Listing TagLine", Label= "Listing TagLine" },
            new FSVisualItem() { Value= "Listing Price", Label= "Listing Price" },
            new FSVisualItem() { Value= "Listing Agent Name", Label= "Listing Agent Name" },
            new FSVisualItem() { Value= "Listing Price", Label= "Listing Price" },
        };

        // Modal Button Values
        public const string BUTTON_OK = "OK";
        public const string BUTTON_YES = "Yes";
        public const string BUTTON_NO = "No";
        public const string BUTTON_CANCEL = "Cancel";
        public const string BUTTON_SAVE = "Save";
        public const string BUTTON_SAVE_NEW = "Save New";
        public const string BUTTON_UPDATE = "Update";

        // Formatters
        public const string FULL_CURRENCY = "#,##0.00";
        public const string SHORT_CURRENCY = "#,##0";

        //Keydown Key string values
        public const string KEYPRESS_ENTER = "Enter";
        public const string KEYPRESS_NUMPAD_ENTER = "NumpadEnter";
        public const string KEYPRESS_SPACE = "Space";
        public const string KEYPRESS_COMMA = "Comma";
        public const string KEYPRESS_TAB = "Tab";

        //List of keydown keys that separate email addresses
        public static readonly List<string> EMAIL_SEPARATOR_KEY_VALUES = new List<string>() {
            KEYPRESS_COMMA,KEYPRESS_ENTER,KEYPRESS_SPACE,KEYPRESS_NUMPAD_ENTER,KEYPRESS_TAB
        };


        #region Avatars
        public const string DEFAULT_UNKNOWN_INDIVIDUAL_AVATAR = "avatar url";
        public const string DEFAULT_MULTI_RECIPIENT_AVATAR = "avatar url";

        #endregion (Avatars)

    }


}
