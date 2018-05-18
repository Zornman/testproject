<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GoogleAutocompleteAddressesAndSearch.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta charset="utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <style>
      /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
      #map {
        height: 100%;
      }
      /* Optional: Makes the sample page fill the window. */
      html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
    </style>
    <link type="text/css" rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500" />
    <style>
      #locationField, #controls {
        position: relative;
        width: 480px;
      }
      #autocomplete {
        position: absolute;
        top: 0px;
        left: 0px;
        width: 99%;
      }
      .label {
        text-align: right;
        font-weight: bold;
        width: 100px;
        color: #303030;
      }
      #address {
        border: 1px solid #000090;
        background-color: #f0f0ff;
        width: 480px;
        padding-right: 2px;
      }
      #address td {
        font-size: 10pt;
      }
      .field {
        width: 99%;
      }
      .slimField {
        width: 80px;
      }
      .wideField {
        width: 200px;
      }
      #locationField {
        height: 20px;
        margin-bottom: 2px;
      }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row" style="padding: 1% 2% 2% 1%;">
                <div class="col-md-12" style="text-align: center;">
                    <div id="locationField">
                        <%--<input id="autocomplete" placeholder="Enter your address"
                    onfocus="geolocate()" type="text"></input>--%>
                        <asp:TextBox ID="autocomplete" placeholder="Enter your address" onfocus="geolocate()" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row" style="padding: 1% 2% 2% 1%">
                <div class="col-md-5" style="text-align: right;">
                    <asp:Label ID="lblStreetNum" runat="server" Text="Street Number: "></asp:Label>
                </div>
                <div class="col-md-7" style="text-align: left;">
                    <asp:TextBox ID="street_number" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="padding: 1% 2% 2% 1%">
                <div class="col-md-5" style="text-align: right;">
                    <asp:Label ID="lblRoute" runat="server" Text="Street Name: "></asp:Label>
                </div>
                <div class="col-md-7" style="text-align: left;">
                    <asp:TextBox ID="route" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="padding: 1% 2% 2% 1%">
                <div class="col-md-5" style="text-align: right;">
                    <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
                </div>
                <div class="col-md-7" style="text-align: left;">
                    <asp:TextBox ID="locality" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="padding: 1% 2% 2% 1%">
                <div class="col-md-5" style="text-align: right;">
                    <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
                </div>
                <div class="col-md-7" style="text-align: left;">
                    <asp:TextBox ID="administrative_area_level_1" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="padding: 1% 2% 2% 1%">
                <div class="col-md-5" style="text-align: right;">
                    <asp:Label ID="lblZip" runat="server" Text="Zip Code: "></asp:Label>
                </div>
                <div class="col-md-7" style="text-align: left;">
                    <asp:TextBox ID="postal_code" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="padding: 1% 2% 2% 1%">
                <div class="col-md-5" style="text-align: right;">
                    <asp:Label ID="lblCountry" runat="server" Text="Country: "></asp:Label>
                </div>
                <div class="col-md-7" style="text-align: left;">
                    <asp:TextBox ID="country" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>

    <script>
      // This example displays an address form, using the autocomplete feature
      // of the Google Places API to help users fill in the information.

      // This example requires the Places library. Include the libraries=places
      // parameter when you first load the API. For example:
      // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

      var placeSearch, autocomplete;
      var componentForm = {
        street_number: 'short_name',
        route: 'long_name',
        locality: 'long_name',
        administrative_area_level_1: 'short_name',
        country: 'long_name',
        postal_code: 'short_name'
      };

      function initAutocomplete() {
        // Create the autocomplete object, restricting the search to geographical
        // location types.
        autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('autocomplete')),
            {types: ['geocode']});

        // When the user selects an address from the dropdown, populate the address
        // fields in the form.
        autocomplete.addListener('place_changed', fillInAddress);
      }

      function fillInAddress() {
        // Get the place details from the autocomplete object.
        var place = autocomplete.getPlace();

        for (var component in componentForm) {
          document.getElementById(component).value = '';
          document.getElementById(component).disabled = false;
        }

        // Get each component of the address from the place details
        // and fill the corresponding field on the form.
        for (var i = 0; i < place.address_components.length; i++) {
          var addressType = place.address_components[i].types[0];
          if (componentForm[addressType]) {
            var val = place.address_components[i][componentForm[addressType]];
            document.getElementById(addressType).value = val;
          }
        }
      }

      // Bias the autocomplete object to the user's geographical location,
      // as supplied by the browser's 'navigator.geolocation' object.
      function geolocate() {
        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(function(position) {
            var geolocation = {
              lat: position.coords.latitude,
              lng: position.coords.longitude
            };
            var circle = new google.maps.Circle({
              center: geolocation,
              radius: position.coords.accuracy
            });
            autocomplete.setBounds(circle.getBounds());
          });
        }
      }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAirr1xgv2LERgSE3Zzewuh589ZkvFs1kw&libraries=places&callback=initAutocomplete" async defer></script>

</body>
</html>
