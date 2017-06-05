# DotNet47Test
Test project to demonstrate a bug in .net 4.7

## Repro Steps
* Set the project to build on .Net 4.6.2
* Launch the application
* Resize the window to a small square (about 300x300)
* Paste a large amount of text in the bottom textbox (labled Private Key in the "Import Existing Private Key" groupbox)
* Continue to use the application and observe as it behaves normally.
* Close the application
* Re-target the application to .Net 4.7
* Launch the application
* Resize the window to a small square (about 300x300)
* Notice the application hangs.
* If it's still working, try pasting a large amount of text in the Privake Key box
* Notice the application hangs.
