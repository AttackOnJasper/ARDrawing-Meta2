# ARDrawing
Augmented Reality Research Project on drawing on a blank paper with a wacom pen and see the drawing from Hololens.
Spring 2018 URA project (University of Waterloo)

## Setup
### System requirements
* Unity 2017.3 / 2017.4 (Meta 2 only supports 2017)
* Microsoft Visual Studio
* Meta2
* Vuforia
* Wacom tablet 
  *  Make sure 'Use Windows Ink' is unchecked: Go to 'Wacom Tablet Properties' app (download if needed) -> 'Calibrate'
  
### Instructions
1. Folk repo to your own github account **Do not change the original repo!**
2. Create a Vuforia account and get your own Vuforia app key
3. Change Vuforia app key to your own key in Vuforia configuration in ARCamera in this project
4. Click the 'Play' button on the top to run the program in external camera AR view

## Process to add new marker-image mapping
1. add the new marker as a vuforia image game object under main scene
2. add the new image as a 3D plane game object under 'MetaCameraRig' -> 'Images'
3. attach 'offset' script to the image object created in step 2 and set 'Marker' field to the game object created in step 1
4. attach another 'Drawing Manager' script to DrawingManager game object; set 'Drawing prefab' field to 'DrawGM' from 'Assets' -> 'Resources', then set 'canvas' field to the image object created in step 2
