<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128628309/12.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4117)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [MyGridControl.cs](./CS/MyGridControl/MyGridControl.cs) (VB: [MyGridControl.vb](./VB/MyGridControl/MyGridControl.vb))
* [MyGridView.cs](./CS/MyGridControl/MyGridView.cs) (VB: [MyGridView.vb](./VB/MyGridControl/MyGridView.vb))
* [MyGridViewInfoRegistrator.cs](./CS/MyGridControl/MyGridViewInfoRegistrator.cs) (VB: [MyGridViewInfoRegistrator.vb](./VB/MyGridControl/MyGridViewInfoRegistrator.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to edit merged cells in GridView


<p>By default, GridView does not support editing of merged cells. Instead, we recommend using our <a href="https://documentation.devexpress.com/windowsforms/12063/controls-and-libraries/spreadsheet">Spreadsheet</a> that supports this feature out of the box:<br><br><a href="https://documentation.devexpress.com/windowsforms/15416/controls-and-libraries/spreadsheet/examples/cells/how-to-merge-cells-or-split-merged-cells">How to: Merge Cells or Split Merged Cells</a> <br>

## ***If the Spreadsheet control does not suit you, we will be happy to find the most appropriate solution for you if you describe your real-life scenario. Just click <a href="https://www.devexpress.com/Support/Center/Question/Create">here</a> to submit a ticket to our Support Center.***
  
  
  
This example demonstrates how to create a custom GridView that supports this functionality. </p><p>The saving logic is implemented in the PostEditor method. If you wish, you can change the implementation as your needs dictate.</p>

<br/>


