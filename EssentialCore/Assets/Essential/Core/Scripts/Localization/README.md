# Localization

## Observation
I have seen people attaching scripts for localization directly on the gameobjects containing Unity's standard UI Text components,
CrispyText components or TextMeshPro Text components. This can become very confusing depending on the amount of Text components.
Object nesting, especially within Canvas elements, can have a large impact on the implementation time.

## How to avoid this problem?
My favorite strategy is to outsource all scripts related to localization. It does not reduce the amount of nested objects within
Canvas elements. But it centralizes all scripts having an effect on the displayed language.

## Advantages
+ Flattening parts of the scene graph increases readability and refactorability. 
    + So obtaining an overview of all assigned IDs becomes easier.
+ Moreover it will introduce Loose Coupling between localization scripts and UI elements.
    + This means gaining more flexibility.
    + This can become very powerful in combination with a good scene management system.
    + Ideally, localization scripts can be outsourced to another scene.
    + Which would mean that team members can implement features more independently.
    + So the major benefit is an increase in productivity.

## Disadvantages
- Connections can break more easily.
- Debugging can become harder for inexperienced developers.
- Poorly conceived and unfinished solutions can introduce even more problems.

## Structure of custom scripts
- Scripts could check if they are connected to UI elements. This could be done on application start or while still working in the Unity Editor.
- If the type of the UI element is already known, custom scripts can be implemented which do not have to call methods like GetComponent().

## Optimization
- While thinking about scene management, I came to the conclusion, that scripts must (un-)register themself to some kind of localization manager. That gave me the idea to implement the (Object) Adapter Pattern.

![The image shows the benefit of using the adapter pattern for localization](https://github.com/lars-wobus/unity-essential-core/blob/master/resources/custom-adapter-pattern---localization/custom-adapter-pattern.png)
