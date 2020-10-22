// CGVAK Included this file

//Lising Business//

function ScrollToBottom(elementId) {
    var e = document.getElementById(elementId);
    if (e != null) {
        e.scrollTop = e.scrollHeight;
    }
}

function ValidateBusinessForm() {
    debugger;
    var isValid = true;

    if ($('#ddlCountry').val() == 'country') {
        $('#ddlCountry').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#ddlCountry').removeClass('inputValidation');
    }

    if ($('#txtZipCode').val() == '') {
        $('#txtZipCode').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtZipCode').removeClass('inputValidation');
    }

    if ($('#txtStreetAddress').val() == '') {
        $('#txtStreetAddress').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtStreetAddress').removeClass('inputValidation');
    }

    if ($('#txtBusinessCategories').val() == '') {
        $('#txtBusinessCategories').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtBusinessCategories').removeClass('inputValidation');
    }

    var radioRealEstateValue = $("input[name='Realestates']:checked").val();
    if (radioRealEstateValue != "No Real estate included in sale" && $("#txtTotalBuildingSF").val() == "") {
        $('#txtTotalBuildingSF').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtTotalBuildingSF').removeClass('inputValidation');
    }

    if ($('#txtContactEMail').val() == '') {
        $('#txtContactEMail').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtContactEMail').removeClass('inputValidation');
    }

    if (!isValid) {
        $('#businessErrorAlert').css('display', 'block');
        //$(window).scrollTop($('#businessErrorAlert').offset().top - 150);
        window.scrollTo(0, 0);
    }
    else {
        $('#businessErrorAlert').css('display', 'none');
    }

    return isValid

}

function BusinessFormTextChange() {

    $("#ddlCountry").on("input", function () {
        if ($("#ddlCountry").val() == "country") {
            $('#ddlCountry').addClass('inputValidation');
        }
        else {
            $('#ddlCountry').removeClass('inputValidation');
        }
    });

    $("#txtZipCode").on("input", function () {
        debugger;
        if ($("#txtZipCode").val() == "") {
            $('#txtZipCode').addClass('inputValidation');
        }
        else {
            $('#txtZipCode').removeClass('inputValidation');
        }
    });

    $("#txtStreetAddress").on("input", function () {
        if ($("#txtStreetAddress").val() == "") {
            $('#txtStreetAddress').addClass('inputValidation');
        }
        else {
            $('#txtStreetAddress').removeClass('inputValidation');
        }
    });

    $("#txtBusinessCategories").on("input", function () {
        if ($("#txtBusinessCategories").val() == "") {
            $('#txtBusinessCategories').addClass('inputValidation');
        }
        else {
            $('#txtBusinessCategories').removeClass('inputValidation');
        }
    });

    $("#txtTotalBuildingSF").on("input", function () {
        var radioRealEstateValue = $("input[name='Realestates']:checked").val();
        if (radioRealEstateValue != "No Real estate included in sale" && $("#txtTotalBuildingSF").val() == "") {
            $('#txtTotalBuildingSF').addClass('inputValidation');
        }
        else {
            $('#txtTotalBuildingSF').removeClass('inputValidation');
        }
    });

    $("#txtContactEMail").on("input", function () {
        if ($("#txtContactEMail").val() == "") {
            $('#txtContactEMail').addClass('inputValidation');
        }
        else {
            $('#txtContactEMail').removeClass('inputValidation');
        }
    });
}

//Listing Business//


//Listing Financial//
function ValidateFinancialForm() {
    var isValid = true;

    if ($('#txtAskingPrice').val() == '') {
        $('#txtAskingPrice').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtAskingPrice').removeClass('inputValidation');
    }

    if ($('#txtGrossRevenue').val() == '') {
        $('#txtGrossRevenue').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtGrossRevenue').removeClass('inputValidation');
    }

    if ($('#txtCashFlow').val() == '') {
        $('#txtCashFlow').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtCashFlow').removeClass('inputValidation');
    }

    if (!isValid) {
        $('#financialErrorAlert').css('display', 'block');
        window.scrollTo(0, 0);
    }
    else {
        $('#financialErrorAlert').css('display', 'none');
    }

    return isValid

}


function FinancialFormTextChange() {

    $("#txtAskingPrice").on("input", function () {
        if ($("#txtAskingPrice").val() == "") {
            $('#txtAskingPrice').addClass('inputValidation');
        }
        else {
            $('#txtAskingPrice').removeClass('inputValidation');
        }
    });

    $("#txtGrossRevenue").on("input", function () {
        if ($("#txtGrossRevenue").val() == "") {
            $('#txtGrossRevenue').addClass('inputValidation');
        }
        else {
            $('#txtGrossRevenue').removeClass('inputValidation');
        }
    });

    $("#txtCashFlow").on("input", function () {
        if ($("#txtCashFlow").val() == "") {
            $('#txtCashFlow').addClass('inputValidation');
        }
        else {
            $('#txtCashFlow').removeClass('inputValidation');
        }
    });
}


//Listing Financial


//Listing AdInfo//
function ValidateAdInfoForm() {
    var isValid = true;

    if ($('#txtAdTitle').val() == '') {
        $('#txtAdTitle').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtAdTitle').removeClass('inputValidation');
    }

    if ($('#txtTagLine').val() == '') {
        $('#txtTagLine').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtTagLine').removeClass('inputValidation');
    }

    if ($('#txtDescription').val() == '') {
        $('#txtDescription').addClass('inputValidation');
        isValid = false;
    }
    else {
        $('#txtDescription').removeClass('inputValidation');
    }

    if (!isValid) {
        $('#adInfoErrorAlert').css('display', 'block');
        window.scrollTo(0, 0);
    }
    else {
        $('#adInfoErrorAlert').css('display', 'none');
    }

    return isValid

}


function AdInfoFormTextChange() {

    $("#txtAdTitle").on("input", function () {
        if ($("#txtAdTitle").val() == "") {
            $('#txtAdTitle').addClass('inputValidation');
        }
        else {
            $('#txtAdTitle').removeClass('inputValidation');
        }
    });

    $("#txtTagLine").on("input", function () {
        if ($("#txtTagLine").val() == "") {
            $('#txtTagLine').addClass('inputValidation');
        }
        else {
            $('#txtTagLine').removeClass('inputValidation');
        }
    });

    $("#txtDescription").on("input", function () {
        if ($("#txtDescription").val() == "") {
            $('#txtDescription').addClass('inputValidation');
        }
        else {
            $('#txtDescription').removeClass('inputValidation');
        }
    });
}

//Listing AdInfo//


// Broker Popup Modal 
function BrokerPopupModal() {

    var modal = document.getElementById("myModal");
    var btn = document.getElementById("myBtn");
    var span = document.getElementsByClassName("close")[0];
    btn.onclick = function () {
        modal.style.display = "block";
    }
    span.onclick = function () {
        modal.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

}

// Broker Popup Modal 


// Agent Popup Modal 
function AgentPopupModal() {

    var modal = document.getElementById("myModalAgent");
    var btn = document.getElementById("myBtnAgent");
    var span = document.getElementsByClassName("closeAgent")[0];
    btn.onclick = function () {
        modal.style.display = "block";
    }
    span.onclick = function () {
        modal.style.display = "none";
    }
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }

}
// Agent Popup Modal


// Listing Menu Business Type
function MenuBusinessType() {

    var coll = document.getElementsByClassName("collapsible");
    var i;

    for (i = 0; i < coll.length; i++) {
        coll[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var content = this.nextElementSibling;
            if (content.style.display === "block") {
                content.style.display = "none";
            } else {
                content.style.display = "block";
            }
        });
    }


    $('button.collapsible').click(function () {
        if ($(this).hasClass("active")) {
            $(this).find('input').prop('checked', true);
        } else {
            $(this).find('input').prop('checked', false);
        }
    });

    $('.dropdown-menu').on('click', function (event) {
        event.stopPropagation();
    });

    $('.d-flex-1').click(function () {
        $(this).parent().toggleClass('active');
        $(this).parent().siblings().removeClass('active');
        //$(this).parent().addClass('active');
        if ($(this).parent().hasClass("active")) {
            $(this).find('.form-group input').prop('checked', true);
        } else {
            $(this).find('.form-group input').prop('checked', false);
        }
    });

    $('.select-all input').click(function () {
        if ($(this).is(':checked')) {
            $(this).closest('.main-drp').find('.d-flex-1 .form-group input').prop('checked', true);
            $(this).closest('.main-drp').find('.sub-drp-1 input').prop('checked', true);
        } else {
            $(this).closest('.main-drp').find('.d-flex-1 .form-group input').prop('checked', false);
            $(this).closest('.main-drp').find('.sub-drp-1 input').prop('checked', false);
        }
    });

    $(".unsel_all").hide();
    $(".select-all input").click(function () {

        if ($(this).is(':checked')) {
            $(".sel_all").hide();
            $(".unsel_all").show();
        }
        else {
            $(".sel_all").show();
            $(".unsel_all").hide();
        }
    });
}
// Listing Menu Business Type


function OnUserProfileDocumentReady() {
    $("#openFileDialog").click(function() {
        $("#userImage").click();
    });
   
}

// Listing Activity
function ListingActivityDocumentready() {
   
    $(".btn-group, .dropdown").hover(
        function () {
            $('>.dropdown-menu', this).stop(true, true).fadeIn("fast");
            $(this).addClass('open');
        },
        function () {
            $('>.dropdown-menu', this).stop(true, true).fadeOut("fast");
            $(this).removeClass('open');
        });

}
// Listing Activity