# Recovery Pattern<sup>1</sup>

* The scripts in this directory allow saving and restoring internal states.
* Some might recognize the similarities to the memento pattern.
* But in contrast to the original pattern, this alternative version is less restrictive.
* Any kind of serialized data can be saved and restored, including primitive data types, strings, structs and classes.
* Right now, I haven't tested enums yet.
* The generic implementation comes with a drawback.
* Internal states of custom scripts must be made public.
* This problem can be avoided by implementing special versions of the Originator class and the Recovery MonoBehaviour.
* But then you will not witness the simplicity and the beauty of this pattern.
* The main goal of this pattern is to provide an easy access to save and restore internal states of existing MonoBehaviours.
* Just as in the case of the Memento pattern saved states will not be exposed.

The general version of this pattern.
![Image of Recovery Pattern](https://github.com/lars-wobus/unity-essential-core/blob/master/resources/custom-memento-pattern/multi-state-recovery-1.png)
To use its full potential, one has to serialize the data for the internal state, implement the owner of the data and 
define a MonoBehaviour to save and restore states. Optionally one can create a MonoBehaviour to monitor events. 
Important note: All MonoBehaviours must be attached to the same gameobject.
![Image describes which interfaces and MonoBehaviours must be used for the general version of the Recovery Pattern](https://github.com/lars-wobus/unity-essential-core/blob/master/resources/custom-memento-pattern/multi-state-recovery-2.png)
The simplified version of this pattern allows to store exactly one internal state.
![Image of simplified version of Recovery Pattern](https://github.com/lars-wobus/unity-essential-core/blob/master/resources/custom-memento-pattern/single-state-recovery-1.png)
To use this version, one has to implement a similar interface and replace a parent class. 
![Image describes which interfaces and MonoBehaviours must be used for the simplified version of the Recovery Pattern](https://github.com/lars-wobus/unity-essential-core/blob/master/resources/custom-memento-pattern/single-state-recovery-2.png)

## FAQ
### How do I know which state is currently in use?
In some implementations of the Memento pattern I have seen additional fields in the Caretaker class for those tasks. Extending the Recovery MonoBehaviours would also be possible. But both strategies would violate the Single Responsible Principle<sup>2</sup>. That's why I have decided to provide interfaces to monitor any changes. So I let the user decide to implement a proper MonoBehaviour to track this data. 
### What's the advantage of the interfaces to monitor changes?
The user can decide if his script should handle or forward incoming events. To forward events he is complete free in choosing c# delegates, actions, UnityEvents or something completely different, I haven't heared yet.

## Footnotes:
1) Preliminary name - if you knows a better name or similar solutions, then please let me know it.
2) Thats also the reason why the Originator and Caretaker are ordinary classes.
