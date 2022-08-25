# MMO-Style-Hotbars
![HotbarDemo](https://user-images.githubusercontent.com/62243708/136672622-acb3ca29-05d6-493b-b73a-2ffef079b5c4.gif)

A side project in Unity made for fun.
This project replicates an MMO's hotbar system, with some customization options.\
All code files are located in [Assets/Scripts](Assets/Scripts).\
For more info, visit my website: https://bryncouvreur.wixsite.com/portfolio

#### Controls
**WASD** - Movement  
**Mouse movement** - Look around character  
**Right click (Hold)** - Camera movement  
**Left click** - UI interaction  
Click on hotbar slots to execute their slotted action (if any).  
Click and drag on the plus icons to move hotbars around.  
Click and drag on hotbar actions to move them to a different slot.  

#### Some notable functions:
- [ClickController::Update](Assets/Scripts/ClickController.cs#L46-L99)
- [ActionSlot::OnDragEnd](Assets/Scripts/ActionSlot.cs#L62-L78)
- [DragButtonBehavior::Start](Assets/Scripts/DragButtonBehavior.cs#L11-L25)

