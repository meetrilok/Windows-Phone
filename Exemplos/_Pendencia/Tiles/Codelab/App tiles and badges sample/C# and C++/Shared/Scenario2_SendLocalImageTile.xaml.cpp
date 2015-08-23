//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

//
// SendLocalImageTile.xaml.cpp
// Implementation of the SendLocalImageTile class
//

#include "pch.h"
#include "Scenario2_SendLocalImageTile.xaml.h"

using namespace SDKSample::Tiles;

using namespace Windows::UI::Xaml;
using namespace Windows::UI::Xaml::Controls;
using namespace Windows::UI::Xaml::Navigation;
using namespace Windows::UI::Notifications;
using namespace NotificationsExtensions::TileContent;

SendLocalImageTile::SendLocalImageTile()
{
    InitializeComponent();
}

void SendLocalImageTile::OnNavigatedTo(NavigationEventArgs^ e)
{
    rootPage = MainPage::Current;
}

void SendLocalImageTile::UpdateTileWithImage_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    // Note: This sample contains an additional project, NotificationsExtensions.
    // NotificationsExtensions exposes an object model for creating notifications, but you can also
    // modify the strings directly. See UpdateTileWithImageWithStringManipulation_Click for an example

    // Users can resize any app tile to the small (Square70x70 on Windows 8.1, Square71x71 on Windows Phone 8.1) and medium (Square150x150) tile sizes.
    // These are both tile sizes an app must minimally support.
    // An app can additionally support the wide (Wide310x150) tile size as well as the large (Square310x310) tile size.
    // Note that in order to support a large (Square310x310) tile size, an app must also support the wide (Wide310x150) tile size (but not vice versa).

    // This sample application supports all four tile sizes: small, medium, wide and large.
    // This means that the user may have resized their tile to any of these four sizes for their custom Start screen layout.
    // Because an app has no way of knowing what size the user resized their app tile to, an app should include template bindings
    // for each supported tile sizes in their notifications. Only Windows Phone 8.1 supports small tile notifications.
    // We assemble one notification with four template bindings by including the content for each smaller
    // tile in the next size up. Square310x310 includes Wide310x150, which includes Square150x150, which includes Square71x71.
    // If we leave off the content for a tile size which the application supports, the user will not see the
    // notification if the tile is set to that size.

    // Create a notification for the Square310x310 tile using one of the available templates for the size.
    auto tileContent = TileContentFactory::CreateTileSquare310x310Image();
    tileContent->Image->Src = "ms-appx:///purpleSquare310x310.png";
    tileContent->Image->Alt = "Purple image";

    // Create a notification for the Wide310x150 tile using one of the available templates for the size.
    auto wide310x150Content = TileContentFactory::CreateTileWide310x150ImageAndText01();
    wide310x150Content->TextCaptionWrap->Text = "This tile notification uses ms-appx images";
    wide310x150Content->Image->Src = "ms-appx:///redWide310x150.png";
    wide310x150Content->Image->Alt = "Red image";

    // Create a notification for the Square150x150 tile using one of the available templates for the size.
    auto square150x150Content = TileContentFactory::CreateTileSquare150x150Image();
    square150x150Content->Image->Src = "ms-appx:///graySquare150x150.png";
    square150x150Content->Image->Alt = "Gray image";

    auto square71x71Content = TileContentFactory::CreateTileSquare71x71Image();
    square71x71Content->Image->Src = "ms-appx:///graySquare150x150.png";
    square71x71Content->Image->Alt = "Gray image";

    // Attach the Square71x71 template to the Square150x150 template.
    square150x150Content->Square71x71Content = square71x71Content;

    // Attach the Square150x150 template to the Wide310x150 template.
    wide310x150Content->Square150x150Content = square150x150Content;

    // Attach the Wide310x150 to the Square310x310 template.
    tileContent->Wide310x150Content = wide310x150Content;

    // Send the notification to the application’s tile.
    TileUpdateManager::CreateTileUpdaterForApplication()->Update(tileContent->CreateNotification());

    OutputTextBlock->Text = tileContent->GetContent();
    rootPage->NotifyUser("Tile notification with local images sent", NotifyType::StatusMessage);
}

void SendLocalImageTile::UpdateTileWithImageWithStringManipulation_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    // Create a string with the tile template xml.
    // Note that the version is set to "3" and that fallbacks are provided for the Square150x150 and Wide310x150 tile sizes.
    // This is so that the notification can be understood by Windows 8 and Windows 8.1 machines as well.
    auto tileXmlString = "<tile>"
        + "<visual version='3'>"
        + "<binding template='TileSquare71x71Image'>"
        + "<image id='1' src='ms-appx:///graySquare150x150.png' alt='Gray image'/>"
        + "</binding>"
        + "<binding template='TileSquare150x150Image' fallback='TileSquareImage'>"
        + "<image id='1' src='ms-appx:///graySquare150x150.png' alt='Gray image'/>"
        + "</binding>"
        + "<binding template='TileWide310x150ImageAndText01' fallback='TileWideImageAndText01'>"
        + "<image id='1' src='ms-appx:///redWide310x150.png' alt='Red image'/>"
        + "<text id='1'>This tile notification uses ms-appx images</text>"
        + "</binding>"
        + "<binding template='TileSquare310x310Image'>"
        + "<image id='1' src='ms-appx:///purpleSquare310x310.png' alt='Purple image'/>"
        + "</binding>"
        + "</visual>"
        + "</tile>";

    // Create a DOM.
    auto tileDOM = ref new Windows::Data::Xml::Dom::XmlDocument();

    // Load the xml string into the DOM.
    tileDOM->LoadXml(tileXmlString);

    // Create a tile notification.
    auto tile = ref new TileNotification(tileDOM);

    // Send the notification to the application’s tile.
    TileUpdateManager::CreateTileUpdaterForApplication()->Update(tile);

    OutputTextBlock->Text = tileDOM->GetXml();
    rootPage->NotifyUser("Tile notification with local images sent", NotifyType::StatusMessage);
}

void SendLocalImageTile::ClearTile_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    TileUpdateManager::CreateTileUpdaterForApplication()->Clear();
    OutputTextBlock->Text = "";
    rootPage->NotifyUser("Tile cleared", NotifyType::StatusMessage);
}