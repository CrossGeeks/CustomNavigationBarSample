# CustomNavigationBarSample
Navigation Bar Customization in Xamarin Forms


<p align="center">
<img width="300" height:"700" src="https://github.com/CrossGeeks/CustomNavigationBarSample/blob/master/gifs/android/android_full_video.gif" title="Android"/>
</p>

### Features

- Title/Subtitle positioning
- Subtitle
- Bar Gradient Background
- Title Font Customization
- Subtitle Font Customization
- Formatted Title
- Formatted Subtitle
- Image title
- Bar Background
- Bar Shadow
- Bar Opacity
- Title Margin
- Title Padding
- Title Border
- Title Background

<p align="center">
<img width="300" height:"700" src="https://github.com/CrossGeeks/CustomNavigationBarSample/blob/master/gifs/ios/gradient_iOS.gif" title="iOS"/>
<img width="300" height:"700" src="https://github.com/CrossGeeks/CustomNavigationBarSample/blob/master/gifs/ios/opacity_ios.gif" title="iOS"/>
</p>


<p align="center">
<img width="300" height:"700" src="https://github.com/CrossGeeks/CustomNavigationBarSample/blob/master/gifs/ios/titleFontPosition_iOS.gif" title="iOS"/>
<img width="300" height:"700" src="https://github.com/CrossGeeks/CustomNavigationBarSample/blob/master/gifs/ios/title_customization_.iOS.gif" title="iOS"/>
</p>

### Usage on a Xamarin Forms page

```cs
//Sets the title position to end

CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.End);

//Sets shadow for bar bottom

CustomNavigationPage.SetHasShadow(this,true);

//Gets if has shadow or not

bool hasShadow = CustomNavigationPage.GetHasShadow(this);

//Sets the title text font to Micro
CustomNavigationPage.SetTitleFont(this, Font.SystemFontOfSize(NamedSize.Micro));
```

### Future

- UWP and other platforms support
- Support Badges
- Kerning
- Back Button Customization
- Toolbar Items Customization
- Buttons/Picker as title
- Rotated Title
- Animations
- Traslucent Bar
- Collapsable Bar
- Bar Templates
