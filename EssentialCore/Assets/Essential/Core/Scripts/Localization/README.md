# Localization

## Observations
I have seen people attaching scripts for localization directly on the gameobjects containing Unity's standard UI Text components,
CrispyText components or TextMeshPro Text components. This can become very confusing depending on the amount of Text components.
Object nesting, especially within Canvas elements, can have a large impact on the implementation time.

## How to avoid this problem?
My favorite strategy is to outsource all scripts related to localization. It does not reduce the amount of nested objects within
Canvas elements. But it centralizes all scripts having an effect on the displayed language.

## Advantages
+ Flattening parts of the scene graph increases readability and refactorability. 
+ So obtaining an overview of all assigned IDs becomes easier.
+ Moreover it introduces Loose Coupling between localization scripts and UI elements, which means one gain more flexibility.

# Disadvantages
- Connections can break more easily

