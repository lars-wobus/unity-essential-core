# Localization

## Observation
I have seen people attaching scripts for localization directly onto gameobjects, containing Unity's standard UI Text components,
CrispyText components or TextMeshPro Text components. This can become very confusing depending on the amount of text inside scenes.

Object nesting, especially within Canvas elements, can have a large impact on the implementation time. But how to avoid this problem?
My favorite strategy is to outsource all scripts related to localization. It does not reduce the amount of nested objects within
Canvas elements. But it centralizes all scripts affecting text components.

## Advantages
+ Flattening parts of the scene graph increases readability and refactorability. 
    + So obtaining an overview of all assigned IDs for localization becomes easier.
    + In addition finding unassigned IDs becomes clearer. 
+ Moreover it will introduce Loose Coupling between scripts for localization and UI elements.
    + This can become very powerful in combination with a good scene management system.
    + Ideally, scripts for localization can be outsourced to another scene.
    + Which would mean that team members can implement features more independently.
    + This means gaining more flexibility. Which also means less collisions and less merge conflicts.
    + So the major benefit is an increase in productivity.

## Disadvantages
- Connections can break more easily.
- Debugging can become harder for inexperienced developers.
- Poorly conceived and unfinished solutions can introduce even more problems.

## Structure of custom scripts
- Scripts could check if they are connected to UI elements. This could be done on application start or while still working in the Unity Editor.
- If the type of the UI element is already known, custom scripts can be implemented which do not have to call methods like GetComponent().

## Optimization
- While thinking about scene management, I came to the conclusion, that scripts must (un-)register themself to some kind of localization manager. That gave me the idea to implement the (Object) Adapter Pattern. Later on I came to the conclusion to separate the logic for (un-)registration and the logic to change displayed text depending on the selected language. But the Adapter pattern still exists.

Note that adapter is not really necessary at the moment, because all currently existing adaptees use the same required property. But in the future there might be another Text component not relying on the 'text' property.

![The image shows the benefit of using the adapter pattern for localization](https://github.com/lars-wobus/unity-essential-core/blob/master/resources/custom-adapter-pattern---localization/custom-adapter-pattern.png)
