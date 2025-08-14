<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128653698/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T534664)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Grid – Display Scrollbar Annotations

This example adds scrollbar annotations to a DevExpress WPF [`GridControl`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl). Annotations help users find important information faster (for example, search hits, validation issues, selected ranges, and user‑defined markers on the scrollbar).

![Display Scrollbar Annotations](./Images/annotation-scrollbar.jpg)

## Implementation Details

### Built-in Annotations

When the grid loads, search results and selected cells appear as markers on the scrollbar. Users can immediately see where matches and selections are located, even if they are outside the visible area.

The example configures the following:

* a search string: `view.SearchString = "Element2"`
* a selected range: `view.SelectCells(15, view.Grid.Columns[0], 25, view.Grid.Columns[1])`

### User‑Defined Annotations

The example adds custom markers to the scrollbar for specific rows:

* Light-coral marker for rows with `Number` between 10 and 15.

* Green marker for rows with `Number` between 2 and 4.

Custom markers use [`ScrollBarAnnotationInfo`](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ScrollBarAnnotationInfo) class properties to set alignment, color, width, and height:

```csharp
private void MyScrollBarCustomRowAnnotationEventHandler(object sender, ScrollBarCustomRowAnnotationEventArgs e) {
    var data = e.Row as TestData;
    if (data == null) return;

    if (data.Number > 10 && data.Number < 15)
        ShowCustomScrollAnnotation(e, Brushes.LightCoral);
    if (data.Number > 2 && data.Number < 4)
        ShowCustomScrollAnnotation(e, Brushes.Green);
}

private void ShowCustomScrollAnnotation(ScrollBarCustomRowAnnotationEventArgs e, SolidColorBrush brush) {
    e.ScrollBarAnnotationInfo = new ScrollBarAnnotationInfo {
        Alignment = ScrollBarAnnotationAlignment.Right,
        Brush = brush,
        MinHeight = 3,
        Width = 10
    };
}
```

## Files to Review

* [MainWindow.xaml](./CS/WpfApplication25/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication25/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/WpfApplication25/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication25/MainWindow.xaml.vb))&#x20;
* [ViewModel.cs](./CS/WpfApplication25/ViewModel.cs) (VB: [ViewModel.vb](./VB/WpfApplication25/ViewModel.vb))&#x20;

## Documentation

* [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl)
* [TableView](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView)
* [ListBoxEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.ListBoxEdit)
* [ScrollBarAnnotationInfo](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.ScrollBarAnnotationInfo)
* [Scrollbar Annotations](https://documentation.devexpress.com/WPF/18068/Controls-and-Libraries/Data-Grid/Data-Scrolling/Scrollbar-Annotations)

## More Examples

* [WPF Data Grid – Specify Custom Content for Column Chooser Headers](https://github.com/DevExpress-Examples/wpf-data-grid-custom-content-for-column-chooser-headers)
* [WPF Data Grid – Handle Drag and Drop Operations](https://github.com/DevExpress-Examples/wpf-grid-handle-drag-and-drop)
* [WPF Data Grid – Bind to Dynamic Data](https://github.com/DevExpress-Examples/wpf-bind-gridcontrol-to-dynamic-data)


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-use-scrollbar-annotations-t534664&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=how-to-use-scrollbar-annotations-t534664&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
